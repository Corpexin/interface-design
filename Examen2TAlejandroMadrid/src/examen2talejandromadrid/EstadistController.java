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
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;

/**
 * FXML Controller class
 *
 * @author corpex
 */
public class EstadistController implements Initializable {
    Examen2TAlejandroMadrid app;
    @FXML
    private TableView<Propuesta> tvTabla;
    @FXML
    private TableColumn<Propuesta, String> tcPropuestas;
    @FXML
    private TableColumn<Propuesta, String> tcVotos;
    @FXML
    private Button btnVolver;
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        rellenarColumnas();
        cargarDatos();
    }    
    
    private void rellenarColumnas() {
        tcPropuestas.setCellValueFactory(cellData -> cellData.getValue().propuestaProperty());
        tcVotos.setCellValueFactory(cellData -> cellData.getValue().votosProperty());
    }

    void setApp(Examen2TAlejandroMadrid app) {
        this.app =app;
    }

    @FXML
    private void volverClick(ActionEvent event) throws Exception {
        app.reemplazarContenido(Helper.LISTAP);
    }

    private void cargarDatos() {
        String query = "SELECT DISTINCT p.Titulo titulo, (SELECT COUNT(v.Id) FROM vota v WHERE v.Id = p.Id ) votos FROM vota v, propuesta p WHERE v.Id = p.Id ;";
        String propuesta, votos;
        ObservableList<Propuesta> propuestas = FXCollections.observableArrayList();
        
        
         try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
               propuesta = rs.getString("titulo");
               votos = rs.getString("votos");
               propuestas.add(new Propuesta(propuesta, votos));
            }
            tvTabla.setItems(propuestas);
            tvTabla.getSortOrder().add(tcVotos); //Ordenamos por votos

        } catch (SQLException | ClassNotFoundException ex) {}  
    }
    
}
