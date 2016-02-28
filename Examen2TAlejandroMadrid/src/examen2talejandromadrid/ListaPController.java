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
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.TextArea;
import javafx.scene.input.MouseEvent;

/**
 * FXML Controller class
 *
 * @author corpex
 */
public class ListaPController implements Initializable {
    Examen2TAlejandroMadrid app;
    @FXML
    private Button btnVotarP;
    @FXML
    private Button btnNuevaP;
    @FXML
    private Button btnVerVot;
    @FXML
    private ListView<String> lvLista;
    @FXML
    private TextArea tbDatos;
    @FXML
    private Button btnCerrarSesion;
    @FXML
    private Button btnCerrar;
    
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        cargarLista();
        
    }    

    void setApp(Examen2TAlejandroMadrid app) {
       this.app = app;
       if(!comprobarVotoRestante())
           btnVotarP.setDisable(true);
    }

    @FXML
    private void votarPClick(ActionEvent event) {
        if(comprobarVoto()){ //comprueba que le queden votos y que no haya mas votaciones
            //restar 1 voto al usuario
            restarVoto();
            //crear entrada en vota con la eleccion del usuario
            registrarVotacion();
        }else{
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Voto");
            alert.setHeaderText(null);
            alert.setContentText("No quedan Votos o Intenta votar dos veces en la misma propuesta");
            alert.showAndWait();
        }
        
    }

    @FXML
    private void nuevaPClick(ActionEvent event) throws Exception {
        //Crear nueva ventana
        app.reemplazarContenido(Helper.NUEVAP);
    }

    @FXML
    private void estadoVClick(ActionEvent event) throws Exception {
        //Crea ventana estadisticas
        app.reemplazarContenido(Helper.ESTADIST);
    }

    private void cargarLista() {
        ObservableList datosAsignaturas = FXCollections.observableArrayList();
        String query = "SELECT Titulo FROM Propuesta";
        String nombreP;

        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                nombreP = rs.getString("Titulo");
                datosAsignaturas.add(nombreP);
            }
            lvLista.setItems(datosAsignaturas);

        } catch (SQLException | ClassNotFoundException ex) {
        }
    }

    @FXML
    private void lvItemClick(MouseEvent event) {
        cargarInfo(lvLista.getSelectionModel().getSelectedItem());
    }

    private void cargarInfo(String selectedItem) {
        String query = "SELECT Descripcion FROM Propuesta WHERE Titulo = '"+selectedItem+"'";
        String descripcion;

        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                descripcion = rs.getString("Descripcion");
                tbDatos.setText(descripcion);
            }

        } catch (SQLException | ClassNotFoundException ex) {
        }
    }

    private void restarVoto() {
       String usuario = app.codUsuario;
       String query1 = "SELECT VotosDisponibles FROM usuario WHERE NIF = '"+usuario+"';";
       int votos =0;
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query1);
            ResultSet rs = sentencia.executeQuery(query1);
            while (rs.next()) {
                votos = rs.getInt("VotosDisponibles");
            }

        } catch (SQLException | ClassNotFoundException ex) {
        }
       votos = votos-1;
       String query2 = "UPDATE usuario SET VotosDisponibles='"+votos+"' WHERE NIF='"+usuario+"';";
        try {
            Connection connection = Helper.conexion();
            Statement sentencia = (Statement) connection.createStatement(); 
            sentencia.executeUpdate(query2);
        } catch (SQLException | ClassNotFoundException ex) {}  
    }

    private void registrarVotacion() {
        String usuario = app.codUsuario;
        String nombreP = lvLista.getSelectionModel().getSelectedItem();
        
        String query = "SELECT Id FROM Propuesta WHERE Titulo = '"+nombreP+"'";
        String idP ="";

        try {//cogemos el id de la propuesta
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                idP = rs.getString("Id");
            }

        } catch (SQLException | ClassNotFoundException ex) {
        }
        
        
        String query2 = "INSERT INTO vota (NIF, Id) VALUES ('"+usuario+"', '"+idP+"');";
        try {
            Connection connection = Helper.conexion();
            Statement sentencia = (Statement) connection.createStatement(); 
            sentencia.executeUpdate(query2);
        } catch (SQLException | ClassNotFoundException ex) {}  
        
        
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Voto");
        alert.setHeaderText(null);
        alert.setContentText("VOTO REGISTRADO");
        alert.showAndWait();
        
    }

    private boolean comprobarVoto() {//comprobamos si ya voto la propuesta y que le quedan votos
        boolean result = true;
        String query = "SELECT VotosDisponibles FROM alumno_examen.usuario WHERE NIF = '"+app.codUsuario+"';";
        int votosRestantes = 0;

        try {//obtenemos los votos restantes
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                votosRestantes = rs.getInt("VotosDisponibles");
            }

        } catch (SQLException | ClassNotFoundException ex) {
        }
        
        if(votosRestantes<=0){
            result = false;
        }
        
        //Obtenemos el id de la propuesta
        String nombreP = lvLista.getSelectionModel().getSelectedItem();
        
        String query2 = "SELECT Id FROM Propuesta WHERE Titulo = '"+nombreP+"'";
        String idP ="";

        try {//cogemos el id de la propuesta
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query2);
            ResultSet rs = sentencia.executeQuery(query2);
            while (rs.next()) {
                idP = rs.getString("Id");
            }

        } catch (SQLException | ClassNotFoundException ex) {
        }
        
        //Obtenemos si ya existe algun registro con esos datos
        String query3 = "SELECT NIF FROM alumno_examen.vota WHERE NIF = '"+app.codUsuario+"' AND Id = '"+idP+"';";
        String nif = "";
         try {//cogemos el id de la propuesta
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query3);
            ResultSet rs = sentencia.executeQuery(query3);
            while (rs.next()) {
                nif = rs.getString("NIF");
            }
            
        } catch (SQLException | ClassNotFoundException ex) {
        }
        if(!nif.matches(""))
           result = false;
        
        
        return result;
    }

    @FXML
    private void cerrarSesionClick(ActionEvent event) throws Exception {
        app.reemplazarContenido(Helper.LOGIN);
    }

    private boolean comprobarVotoRestante() {
        int votosRestantes=0;
        boolean result = true;
        String query = "SELECT VotosDisponibles FROM alumno_examen.usuario WHERE NIF = '"+app.codUsuario+"';";
        try {//obtenemos los votos restantes
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                votosRestantes = rs.getInt("VotosDisponibles");
            }

        } catch (SQLException | ClassNotFoundException ex) {
        }
        
        if(votosRestantes<=0){
            result = false;
        }
        
        return result;
    }

    @FXML
    private void cerrarClick(ActionEvent event) {
        Platform.exit();
        System.exit(0);
    }
    
}
