/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen2talejandromadrid;

import java.net.URL;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;

/**
 * FXML Controller class
 *
 * @author corpex
 */
public class NuevaPController implements Initializable {
    Examen2TAlejandroMadrid app;
    @FXML
    private TextField tbTituloP;
    @FXML
    private TextArea tbDatosP;
    @FXML
    private Button btnProponer;
    @FXML
    private Button btnCancelar;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @FXML
    private void proponerClick(ActionEvent event) throws Exception {
        if(!tbTituloP.getText().matches("") && !tbDatosP.getText().matches("")){
            //cojo el id mayor
            String query = "SELECT MAX(Id) maxI FROM alumno_examen.propuesta;";
            int idM = 0;

            try {
                Connection connection = Helper.conexion();
                PreparedStatement sentencia = connection.prepareStatement(query);
                ResultSet rs = sentencia.executeQuery(query);
                while (rs.next()) {
                    idM = rs.getInt("maxI");
                }
                idM = idM + 1;
            } catch (SQLException | ClassNotFoundException ex) {
            }

            //insert
            String query2 = "INSERT INTO propuesta (Id, Titulo, Descripcion, NIFu) VALUES ('" + idM + "', '" + tbTituloP.getText() + "', '" + tbDatosP.getText() + "', '" + app.codUsuario + "');";

            try {
                Connection connection = Helper.conexion();
                Statement sentencia = (Statement) connection.createStatement();
                sentencia.executeUpdate(query2);
            } catch (SQLException | ClassNotFoundException ex) {
            }
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Voto");
            alert.setHeaderText(null);
            alert.setContentText("Propuesta añadida");
            alert.showAndWait();
            //volver a la lista
            app.reemplazarContenido(Helper.LISTAP);
        }else{ //sino le mostramos mensaje de error
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Voto");
            alert.setHeaderText(null);
            alert.setContentText("Error. Campos Vacios");
            alert.showAndWait();
        }
        
    }

    @FXML
    private void cancelarClick(ActionEvent event) throws Exception {
        app.reemplazarContenido(Helper.LISTAP);
    }

    void setApp(Examen2TAlejandroMadrid app) {
       this.app = app;
    }
    
}
