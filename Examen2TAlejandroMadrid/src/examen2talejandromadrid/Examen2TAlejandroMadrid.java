/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen2talejandromadrid;

import java.io.InputStream;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.fxml.JavaFXBuilderFactory;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 *
 * @author corpex
 */
public class Examen2TAlejandroMadrid extends Application {
    Stage stage;
    LoginController Login;
    ListaPController ListaP;
    NuevaPController NuevaP;
    EstadistController Estad;
    public String codUsuario;
    
    @Override
    public void start(Stage st) throws Exception {
        stage = st;
        stage.initStyle(StageStyle.UNDECORATED);
        reemplazarContenido(Helper.LOGIN);
        stage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
    
    
    //Cargamos un  contenido u otro
    public void reemplazarContenido(int i) throws Exception {
       switch(i){
           case 1:
               Login = (LoginController) replaceSceneContent("Login.fxml");
               Login.setApp(this);
               break;
           case 2:
               ListaP = (ListaPController) replaceSceneContent("ListaP.fxml");
               ListaP.setApp(this);
               break;
           case 3:
               NuevaP = (NuevaPController) replaceSceneContent("NuevaP.fxml");
               NuevaP.setApp(this);
               break;
           case 4:
               Estad = (EstadistController) replaceSceneContent("Estadist.fxml");
               Estad.setApp(this);
               break;
               
       }
    }
    
    //Reemplazamos el contenido del stage dependiendo del String que se le pase por parametro
    private Initializable replaceSceneContent(String fxml) throws Exception {
        FXMLLoader loader = new FXMLLoader();
        
        InputStream in = getClass().getResourceAsStream(fxml);
        loader.setBuilderFactory(new JavaFXBuilderFactory());
        loader.setLocation(getClass().getResource(fxml));
        
        AnchorPane page;
        try {
            page = (AnchorPane) loader.load(in);
        } finally {
            in.close();
        }
        
        Scene scene = new Scene(page);
        stage.setScene(scene);
        
        
        stage.sizeToScene();
        stage.centerOnScreen();
        return (Initializable) loader.getController();
    }
    
}
