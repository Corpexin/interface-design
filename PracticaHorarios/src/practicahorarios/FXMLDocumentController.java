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
import javafx.application.Platform;
import javafx.beans.binding.Bindings;
import javafx.beans.binding.StringBinding;
import javafx.beans.property.ObjectProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ContextMenu;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.control.MenuItem;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;

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
    private ListView<String> lvHorario;

    @FXML
    private TableView<Horario> tbHorarioSemanal;
    @FXML
    private TableColumn<Horario, String> clHora;
    @FXML
    private TableColumn<Horario, String> clLunes;
    @FXML
    private TableColumn<Horario, String> clMartes;
    @FXML
    private TableColumn<Horario, String> clMiercoles;
    @FXML
    private TableColumn<Horario, String> clJueves;
    @FXML
    private TableColumn<Horario, String> clViernes;
    @FXML
    private AnchorPane btnAtras;
    @FXML
    private ImageView imgCerrar;
    @FXML
    private ImageView imgAtras;
    private PracticaHorarios application;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        configurarLista();
        getProfesores();
        rellenarColumnas();
    }
    
    public void setApp(PracticaHorarios application) {
        this.application = application;
    }

    private void getProfesores() {
        //hacer que en getprofesor se obtenga el codigo del profesor tambien.
        //usar ese codigo para no tener que tocar la tabla profesor
        ObservableList datosProf = FXCollections.observableArrayList();
        codProfLista = new ArrayList<>();
        String nombre;
        String codProf;
        try {
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355"); Statement sentencia = conexion.createStatement()) {
                ResultSet rs = sentencia.executeQuery("SELECT nombre, CodProf FROM Profesor");
                ResultSetMetaData rsmd = rs.getMetaData();
                while (rs.next()) {
                    nombre = rs.getString("nombre");
                    codProf = rs.getString("CodProf");
                    datosProf.add(nombre);
                    codProfLista.add(codProf);
                }
                cbProfesor.setItems(datosProf);
            }
        } catch (ClassNotFoundException cn) {
        } catch (SQLException ex) {
            System.out.printf("Error Excepcion");
        }
    }

    private void getHorarioDiario(String codProf) {
        ObservableList datosDiario = FXCollections.observableArrayList();

        Date d = new Date();
        SimpleDateFormat formato = new SimpleDateFormat("EEEE");
        String dia = formato.format(d);

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
                    datosDiario.add(horaInicio + "-" + horaFin + "    -    " + codAsig);
                }
                lvHorario.setItems(datosDiario);
            }
        } catch (ClassNotFoundException cn) {
        } catch (SQLException ex) {
            System.out.printf("Error Excepcion");
        }
    }

    private void getHorarioSemanal(String codProf) {
        ObservableList<Horario> data = FXCollections.observableArrayList();
        ArrayList<Tramo> tramos = new ArrayList<>();
        String codTramo;
        String codAsig;
        String query;

        query = "SELECT th.codTramo, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodCurso = ho.codCurso && re.CodOe = ho.CodOe && re.CodProf = '" + codProf + "' ORDER BY SUBSTRING(th.codTramo, 2)  ASC, CASE WHEN th.codTramo LIKE 'L%' THEN 1 WHEN th.codTramo LIKE 'M%' THEN 2 WHEN th.codTramo LIKE 'X%' THEN 3 WHEN th.codTramo LIKE 'J%' THEN 4 WHEN th.codTramo LIKE 'V%' THEN 5 END";

        try {
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355"); Statement sentencia = conexion.createStatement()) {
                ResultSet rs = sentencia.executeQuery(query);
                ResultSetMetaData rsmd = rs.getMetaData();
                while (rs.next()) {
                    codTramo = rs.getString("th.codTramo");
                    codAsig = rs.getString("re.CodAsignatura");
                    tramos.add(new Tramo(codTramo, codAsig));
                }

            }
        } catch (ClassNotFoundException cn) {
        } catch (SQLException ex) {
            System.out.printf("Error Excepcion");
        }

        String[] semana = new String[5];
        String hora = "";

        for (int i = 0; i < 6; i++) {
            //Renueva el array
            for (int j = 0; j < semana.length; j++) {
                semana[j] = "";
            }
            for (Tramo t : tramos) {
                if (t.getCodTramo().contains("" + (i + 1))) {
                    switch (t.getCodTramo().charAt(0)) {
                        case 'L':
                            semana[0] = t.getCodAsig();
                            break;
                        case 'M':
                            semana[1] = t.getCodAsig();
                            break;
                        case 'X':
                            semana[2] = t.getCodAsig();
                            break;
                        case 'J':
                            semana[3] = t.getCodAsig();
                            break;
                        case 'V':
                            semana[4] = t.getCodAsig();
                            break;
                    }
                }
            }
            switch (i) {
                case 0:
                    hora = "08:15-09:15";
                    break;
                case 1:
                    hora = "09:15-10:15";
                    break;
                case 2:
                    hora = "10:15-11:15";
                    break;
                case 3:
                    hora = "11:45-12:45";
                    break;
                case 4:
                    hora = "12:45-13:45";
                    break;
                case 5:
                    hora = "13:45-14:45";
                    break;
            }
            data.add(new Horario(hora, semana[0], semana[1], semana[2], semana[3], semana[4]));
        }
        
        tbHorarioSemanal.setItems(data);
    }

    @FXML
    private void cbProfesorSelectedItemChanged(ActionEvent event) {
        int opcionRB;
        if (rbDiario.isSelected()) {
            opcionRB = 1;
        } else if (rbSemanal.isSelected()) {
            opcionRB = 2;
        } else {
            opcionRB = 3;
        }

        String selectedProfesor = cbProfesor.getSelectionModel().getSelectedItem().toString();
        switch (opcionRB) {
            case 1://diario
                getHorarioDiario("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
                break;
            case 2://semanal
                getHorarioSemanal("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
                break;
            case 3://ninguno seleccionado
                ObservableList data = FXCollections.observableArrayList();
                data.add("No se ha seleccionado RadioButton");
                lvHorario.setItems(data);
                break;
        }
    }

    
    private void rellenarColumnas() {
        // Initialize the person table with the two columns.
        clHora.setCellValueFactory(cellData -> cellData.getValue().HoraProperty());
        clLunes.setCellValueFactory(cellData -> cellData.getValue().LunesProperty());
        clMartes.setCellValueFactory(cellData -> cellData.getValue().MartesProperty());
        clMiercoles.setCellValueFactory(cellData -> cellData.getValue().MiercolesProperty());
        clJueves.setCellValueFactory(cellData -> cellData.getValue().JuevesProperty());
        clViernes.setCellValueFactory(cellData -> cellData.getValue().ViernesProperty());
    }

    @FXML
    private void rbSemanalPressed(ActionEvent event) {
        if(!rbSemanal.isSelected()){
            rbSemanal.setSelected(true);
        }
        if(rbDiario.isSelected()){
            rbDiario.setSelected(false);
        }
        lvHorario.setVisible(false);
        tbHorarioSemanal.setVisible(true);
        
        if(!cbProfesor.getSelectionModel().isEmpty() && rbDiario.isSelected())
            getHorarioDiario("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
        else if(!cbProfesor.getSelectionModel().isEmpty() && rbSemanal.isSelected())
            getHorarioSemanal("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
    }

    @FXML
    private void rbDiarioPressed(ActionEvent event) {      
        if(!rbDiario.isSelected()){
            rbDiario.setSelected(true);
        }
         if(rbSemanal.isSelected()){
            rbSemanal.setSelected(false);
        }
         
        lvHorario.setVisible(true);
        tbHorarioSemanal.setVisible(false);
        
        if(!cbProfesor.getSelectionModel().isEmpty() && rbDiario.isSelected())
            getHorarioDiario("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
        else if(!cbProfesor.getSelectionModel().isEmpty() && rbSemanal.isSelected())
            getHorarioSemanal("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
    }

    @FXML
    private void btnCerrarClick(MouseEvent event) {
        Platform.exit();
        System.exit(0);
    }

    @FXML
    private void btnAtrasClick(MouseEvent event) {
        application.goToLogin();
    }

    private void configurarLista() {
        lvHorario.setCellFactory(lv -> {

            ListCell<String> listaCeldas = new ListCell<>();
            listaCeldas.textProperty().bind(listaCeldas.itemProperty()); //bindea el textproperty de la lista con el itemproperty de la lista (?)
            listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> { 
                if (isNowEmpty) {
                    listaCeldas.setContextMenu(null);
                } else {
                    ContextMenu menu = new ContextMenu();
                    MenuItem menuItem = new MenuItem();
                    menuItem.setText(obtenerInfo(listaCeldas.itemProperty().get()));
                    menu.getItems().addAll(menuItem);
                    listaCeldas.setContextMenu(menu); //si se hace click en una celda llena sale el menu contextual
                }
            });
            return listaCeldas ;
        });
    }
    
    public String obtenerInfo(String codigo){
        String idA = codigo.substring(26);
        
        
        String query;
        String nombre="";
        int horasS=0;
        int horasT=0;

        try {
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355"); Statement sentencia = conexion.createStatement()) {
                ResultSet rs = sentencia.executeQuery("SELECT * FROM asignatura WHERE codAsignatura = '"+idA+"';");
                ResultSetMetaData rsmd = rs.getMetaData();
                while (rs.next()) {
                    nombre = rs.getString("Nombre");
                    horasS = rs.getInt("HorasSemanales");
                    horasT = rs.getInt("HorasTotales");
                }
            }
        } catch (ClassNotFoundException cn) {
        } catch (SQLException ex) {
            System.out.printf("Error Excepcion");
        }
        
        
        return nombre+"\nHoras semanales: "+horasS+"\nHoras totales: "+horasT;
    }

    

}
