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
import java.util.ArrayList;
import java.util.Date;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListView;
import javafx.scene.control.RadioButton;

/**
 *
 * @author corpex
 */
public class FXMLDocumentController implements Initializable {
    ArrayList codProfLista;
    
    @FXML
    private ComboBox<?> cbProfesor;
    @FXML
    private RadioButton rbDiario;
    @FXML
    private RadioButton rbSemanal;
    @FXML
    private ListView<?> lvHorario;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        getProfesores();
    }
    
    private void getProfesores() {
        //hacer que en getprofesor se obtenga el codigo del profesor tambien.
        //usar ese codigo para no tener que tocar la tabla profesor
       ObservableList data = FXCollections.observableArrayList();
       codProfLista = new ArrayList<>();
        String nombre;
        String codProf;
	try{
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355");Statement sentencia = conexion.createStatement()) {
                ResultSet rs = sentencia.executeQuery("SELECT nombre, CodProf FROM Profesor");
                ResultSetMetaData rsmd = rs.getMetaData();
                while(rs.next()){
                    nombre = rs.getString("nombre");
                    codProf = rs.getString("CodProf");
                    data.add(nombre);
                    codProfLista.add(codProf);
                }
                cbProfesor.setItems(data);
            }
        }catch(ClassNotFoundException cn){} catch (SQLException ex) {
           System.out.printf("Error Excepcion");
        }   
    }
    
    private void getHorarioDiario(String codProf) {
        ObservableList data = FXCollections.observableArrayList();
        
        Date d = new Date();
        SimpleDateFormat formato = new SimpleDateFormat("EEEE");
        String dia = formato.format(d);
        
        String horaInicio;
        String horaFin;
        String codAsig;
        String query;
       
        query = "SELECT th.HoraInicio, th.HoraFin, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodProf = '"+codProf+"' && th.dia = '"+dia+"'";

        try{
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355");Statement sentencia = conexion.createStatement()) {
               ResultSet rs = sentencia.executeQuery(query);
                ResultSetMetaData rsmd = rs.getMetaData();
                while(rs.next()){
                    horaInicio = rs.getString("HoraInicio");
                    horaFin = rs.getString("HoraFin");
                    codAsig = rs.getString("codAsignatura");
                    data.add(horaInicio+"-"+horaFin+"   "+codAsig);
                }
                lvHorario.setItems(data);
            }
        }catch(ClassNotFoundException cn){} catch (SQLException ex) {
           System.out.printf("Error Excepcion");
        }   
    }
    
    private void getHorarioSemanal(String codProf) {
        ObservableList data = FXCollections.observableArrayList();
        
        
        String horaInicio;
        String horaFin;
        String codAsig;
        String query;
       
        query = "SELECT th.dia, th.HoraInicio, th.HoraFin, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodProf = '"+codProf+"' order by th.dia";

        try{
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355");Statement sentencia = conexion.createStatement()) {
               ResultSet rs = sentencia.executeQuery(query);
                ResultSetMetaData rsmd = rs.getMetaData();
                while(rs.next()){
                    horaInicio = rs.getString("HoraInicio");
                    horaFin = rs.getString("HoraFin");
                    codAsig = rs.getString("codAsignatura");
                    data.add(horaInicio+"-"+horaFin+"   "+codAsig);
                }
                lvHorario.setItems(data);
            }
        }catch(ClassNotFoundException cn){} catch (SQLException ex) {
           System.out.printf("Error Excepcion");
        }   
    }

    @FXML
    private void cbProfesorSelectedItemChanged(ActionEvent event) {
        int opcionRB;
        if(rbDiario.isSelected())
           opcionRB = 1;
        else if(rbSemanal.isSelected())
           opcionRB = 2;
        else
           opcionRB = 3;
        
        String selectedProfesor = cbProfesor.getSelectionModel().getSelectedItem().toString();
        switch(opcionRB){
            case 1://diario
                getHorarioDiario(""+codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
                break;
            case 2://semanal
                getHorarioSemanal(""+codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));//NO SIRVE, PORQUE HAY QUE USAR UNA TABLE/GRIDVIEW
                break;
            case 3://ninguno seleccionado
                ObservableList data = FXCollections.observableArrayList();
                data.add("No se ha seleccionado RadioButton");
                lvHorario.setItems(data);
                break;
        }
    }

    

    


   

    
    
}
