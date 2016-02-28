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
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

/**
 *
 * @author corpex
 */
public class LoginController implements Initializable {
    Examen2TAlejandroMadrid app;
    @FXML
    private TextField tbUsuario;
    @FXML
    private TextField tbPassword;
    @FXML
    private Button btnCrear;
    @FXML
    private Button btnEntrar;
    @FXML
    private Label lblMens;
    @FXML
    private Button btnCerrar;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    void setApp(Examen2TAlejandroMadrid app) {
       this.app = app;
    }

    @FXML
    private void crearClick(ActionEvent event) throws Exception {
        comprobarEntrada(2);
    }

    @FXML
    private void entrarClick(ActionEvent event) throws Exception {
        comprobarEntrada(1);
    }

    private void comprobarEntrada(int tipo) throws Exception {
        String query = "SELECT NIF, Contrasenha FROM alumno_examen.usuario WHERE NIF = '"+tbUsuario.getText()+"' AND Contrasenha = '"+tbPassword.getText()+"';";
        String alumno = "";
        String password ="";
        
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
               alumno = rs.getString("NIF");
               password = rs.getString("Contrasenha");
            }
        if(!alumno.matches("") && !password.matches("")){
            if(tipo == 1)
                entrar(); 
            else
                crear(); //si no hay usuarios con esos credenciales los crea
        }
        else{
            if(tipo==2)
                crear();
            else
                lblMens.setText("Usuario o contraseña Invalidos");
        }
            
        } catch (SQLException | ClassNotFoundException ex) {}  
    }

    private void entrar() throws Exception {
        app.codUsuario = tbUsuario.getText();
        app.reemplazarContenido(Helper.LISTAP);
    }

    private void crear() {
        //Comprobamos si el usuario y cntraseña existen primero
        String query  = "SELECT NIF, Contrasenha FROM alumno_examen.usuario WHERE NIF = '"+tbUsuario.getText()+"' AND contrasenha = '"+tbPassword.getText()+"';";
        String user = null, password = null;
        boolean existe = false;
        
         try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                user = rs.getString("NIF");
                password = rs.getString("Contrasenha");
            }
            
            if(user != null || password != null){
                lblMens.setText("El usuario ya existe");
                existe = true;
            }
            
        } catch (SQLException | ClassNotFoundException ex) {
            
        }
        if(existe == false){ //si no existe, lo inserta
            try {
                Connection connection = Helper.conexion();
                Statement sentencia = (Statement) connection.createStatement(); 
                sentencia.executeUpdate("INSERT INTO usuario (NIF, Contrasenha, VotosDisponibles) VALUES ('"+tbUsuario.getText()+"', '"+tbPassword.getText()+"', 3)");
                lblMens.setText("Usuario Creado");
            } catch (SQLException | ClassNotFoundException ex) {}  
        }
        
    }

    @FXML
    private void cerrarClick(ActionEvent event) { //salir del programa
        Platform.exit();
        System.exit(0);
    }
    
}
