/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen;

import java.net.URL;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.ResourceBundle;
import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;

/**
 * FXML Controller class
 *
 * @author corpex
 */
public class FXMLVentana2Controller implements Initializable {

    Application app;
    @FXML
    private Label lblTexto;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        String query = "SELECT nombre FROM usuario WHERE password = 'pepe'";
        String nombre="";
        
        try {
            Connection connection = Helper1.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
               nombre = rs.getString("nombre");              
            }
            lblTexto.setText(nombre);
            
        } catch (SQLException | ClassNotFoundException ex) {}  
    }    
    
}
