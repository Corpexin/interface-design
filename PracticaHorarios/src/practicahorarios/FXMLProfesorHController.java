/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package practicahorarios;

import java.net.URL;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.Event;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ListView;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.layout.AnchorPane;

/**
 * FXML Controller class
 *
 * @author corpex
 */
public class FXMLProfesorHController extends AnchorPane implements Initializable {

    @FXML
    private Tab tabLunes;
    @FXML
    private ListView<?> lvLunes;
    @FXML
    private Tab tabMartes;
    @FXML
    private ListView<?> lvMartes;
    @FXML
    private Tab tabMiercoles;
    @FXML
    private ListView<?> lvMiercoles;
    @FXML
    private Tab tabJueves;
    @FXML
    private ListView<?> lvJueves;
    @FXML
    private Tab tabViernes;
    @FXML
    private ListView<?> lvViernes;
    @FXML
    private TabPane tabPanel;

    String idAnt = "Lunes";
    String codProf;
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {

    }    

    @FXML
    private void cambioTab(Event event) {
        String id = ((Tab)event.getSource()).getText();
        if(!id.matches(idAnt)){
            getHorarioDiario(id);
            idAnt = id;
        }
    }

    
    private void getHorarioDiario(String dia) {
        ObservableList datosDiario = FXCollections.observableArrayList();

        String horaInicio;
        String horaFin;
        String codAsig;
        String query;

        query = "SELECT th.HoraInicio, th.HoraFin, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodProf = '" + codProf + "' && th.dia = '" + dia + "'";

        try {
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355"); Statement sentencia = conexion.createStatement()) {
                ResultSet rs = sentencia.executeQuery(query);
                ResultSetMetaData rsmd = rs.getMetaData();
                while (rs.next()) {
                    horaInicio = rs.getString("HoraInicio");
                    horaFin = rs.getString("HoraFin");
                    codAsig = rs.getString("codAsignatura");
                    datosDiario.add(horaInicio + "-" + horaFin + "   " + codAsig);
                }
                switch (dia) {
                    case "Lunes":
                        lvLunes.setItems(datosDiario);
                        break;
                    case "Martes":
                        lvMartes.setItems(datosDiario);
                        break;
                    case "Miercoles":
                        lvMiercoles.setItems(datosDiario);
                        break;
                    case "Jueves":
                        lvJueves.setItems(datosDiario);
                        break;
                    case "Viernes":
                        lvViernes.setItems(datosDiario);
                        break;
                }
            }
        } catch (ClassNotFoundException cn) {
        } catch (SQLException ex) {
            System.out.printf("Error Excepcion");
        }
    }
    
}
