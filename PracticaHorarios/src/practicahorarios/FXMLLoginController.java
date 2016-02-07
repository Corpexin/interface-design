package practicahorarios;
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.net.URL;
import java.util.ResourceBundle;
import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;

import javafx.util.Duration;

/**
 * FXML Controller class
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

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {

    }

    @FXML
    private void btnEnviar(ActionEvent event) {
        if (!application.userLogging(tbUsuario.getText(), tbPassword.getText())) {
            lblError.setVisible(true);
            timer();
        }
    }

    public void setApp(PracticaHorarios application) {
        this.application = application;
    }
    
    public String getCodProf(){
        return tbUsuario.getText();
    }

    private void timer() {
        Timeline t = new Timeline(new KeyFrame(Duration.seconds(3), (ActionEvent event) -> {
            lblError.setVisible(false);
        }));
        t.setCycleCount(1);
        t.play();
    }

}
