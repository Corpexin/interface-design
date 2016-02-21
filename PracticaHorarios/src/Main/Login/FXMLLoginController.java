package Main.Login;

import Main.Helper;
import Main.PracticaHorarios;
import java.net.URL;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.control.Tooltip;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;

import javafx.util.Duration;

/**
 * FXML Controller class
 *
 * Controlador del Login
 * 
 * @author corpex
 */
public class FXMLLoginController extends AnchorPane implements Initializable {

    @FXML
    private TextField tbUsuario;
    @FXML
    private TextField tbPassword;
    @FXML
    private Label lblUsuario;
    @FXML
    private Label lblPassword;
    @FXML
    private Button btnEnviar;
    @FXML
    private Label lblError;

    private PracticaHorarios application;
    @FXML
    private ImageView ivCerrar;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        //Configuramos un tooltip de advertencia para el usuario
        tbUsuario.setTooltip(new Tooltip("Para acceder como profesor, el usuario y contraseña es el codProf de la base de datos"));
    }
    
    //Vincular la referencia de la aplicacion principal al login para que actue de listener
    public void setApp(PracticaHorarios application) {
        this.application = application;
    }
    
    //Getter del texto del textbox Usuario que devuelve el codigo del profesor
    public String getCodProf() {
        return tbUsuario.getText();
    }

    @FXML //Evento que se alcanza al pulsar el boton Enviar
    private void btnEnviar(ActionEvent event) {
        comprobarEntrar();
    }

    @FXML //Evento de salida del programa si se pulsa en la imagen de cerrar
    private void cerrarClick(MouseEvent event) {
        Platform.exit();
        System.exit(0);
    }

    @FXML //Atajo que al presionar Enter pulsa el boton Enviar
    private void pressKeyPass(KeyEvent event) {
        if (event.getCode().equals(KeyCode.ENTER)) {
           comprobarEntrar();
        }
    }

    //Comprueba con consulta a BD si el usuario y contrase;a coinciden
    private void comprobarEntrar() {
        if (!userLogging(tbUsuario.getText(), tbPassword.getText())) {
            lblError.setVisible(true);
            timer();
        }
    }
    
    //Temporizador de 3 segundos para hacer desaparecer el texto de error de acceso
    private void timer() {
        Timeline t = new Timeline(new KeyFrame(Duration.seconds(3), (ActionEvent event) -> {
            lblError.setVisible(false);
        }));
        t.setCycleCount(1);
        t.play();
    }
    
    //Hace una consulta para comprobar que el usuario y contraseña estan en la base de datos
    public boolean userLogging(String userId, String password) {
        boolean result = true;
        String query;
        int tipoUsuario = 99;
        query = "SELECT tipousuario FROM horario.login WHERE usuario='"+userId+"' AND password = '"+password+"'";

        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            if (rs.next()) {
                tipoUsuario = rs.getInt("tipousuario");
            }  
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
           
        switch (tipoUsuario) {
            case 0: //Si la consulta devuelve un 0, es que es un usuario normal
                application.cambiarEscenario(Helper.ID_USUARIO);
                break;
            case 1://Si devuelve un 1, es que es un profesor
                application.cambiarEscenario(Helper.ID_PROFESOR);
                break;
            default:// si no es ninguno, es que el usuario no existe
                result = false;
                break;
        }
        
        return result;
    }
}
