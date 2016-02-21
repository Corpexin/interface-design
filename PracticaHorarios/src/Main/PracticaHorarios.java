package Main;

import Main.Usuario.FXMLUsuarioController;
import Main.Profesor.FXMLProfesorController;
import Main.Login.FXMLLoginController;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.fxml.JavaFXBuilderFactory;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 * @author corpex
 */
//Actividad principal de control general del programa
public class PracticaHorarios extends Application {
    
    private Stage stage;
    FXMLLoginController login; //FXML para el login
    FXMLUsuarioController horarioU; //FXML de horario para usuarios normales
    FXMLProfesorController horarioP; //FXML de horario para profesores
    
    @Override
    public void start(Stage primaryStage) throws Exception {
        //Proceso para iniciar por primera vez la aplicacion. Se ejecuta el login
        primaryStage.initStyle(StageStyle.UNDECORATED);
        stage = primaryStage;
        cambiarEscenario(Helper.ID_LOGIN);
        primaryStage.show();
        stage.setTitle("Horarios");
        stage.centerOnScreen();
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);

    }

    //Metodo que carga una escena u otra dependiendo del parametro pasado
    public void cambiarEscenario(int esc){
        try {
            switch(esc){
                    case 1:
                        login = (FXMLLoginController) replaceSceneContent("Login/FXMLLogin.fxml");
                        login.setApp(this);
                        break;
                    case 2:
                        horarioU = (FXMLUsuarioController) replaceSceneContent("Usuario/FXMLUsuario.fxml");
                        horarioU.setApp(this);
                        break;
                    case 3:
                        horarioP = (FXMLProfesorController) replaceSceneContent("Profesor/FXMLProfesor.fxml");                        
                        horarioP.codProf = login.getCodProf();
                        horarioP.setApp(this);
                        break;
            }
        } catch (Exception ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
        
    //Funcion general para reemplazar una escena dependiendo de la ruta que se le pase por parametro
    private Initializable replaceSceneContent(String fxml) throws Exception {
        FXMLLoader loader = new FXMLLoader();
        
        InputStream in = getClass().getResourceAsStream(fxml);
        loader.setBuilderFactory(new JavaFXBuilderFactory());
        loader.setLocation(getClass().getResource(fxml));
        
        AnchorPane page;
        try {
            page = (AnchorPane) loader.load(in);
            if (fxml.matches("Profesor/FXMLProfesor.fxml")) { //condicion para que si es un profesor cargue el horario del lunes directamente
                ((FXMLProfesorController) loader.getController()).codProf = login.getCodProf();
                 ((FXMLProfesorController) loader.getController()).getHorarioDiario("Lunes");
            }
        } finally {
            in.close();
        }
        
        //Creamos la escena con el page y la cambiamos en el stage
        Scene scene = new Scene(page);
        stage.setScene(scene);
        
        //Condiciones para cargar los css de cada FXML
        if(fxml.matches("Usuario/FXMLUsuario.fxml"))
            scene.getStylesheets().add(PracticaHorarios.class.getResource("Usuario/Usuario.css").toExternalForm());
        else if(fxml.matches("Profesor/FXMLProfesor.fxml"))
            scene.getStylesheets().add(PracticaHorarios.class.getResource("Profesor/Profesor.css").toExternalForm());
        else
            scene.getStylesheets().add(PracticaHorarios.class.getResource("Login/Login.css").toExternalForm());
        stage.sizeToScene();
        stage.centerOnScreen(); //la escena siempre aparecera centrada en pantalla
        return (Initializable) loader.getController();
    }

    

}