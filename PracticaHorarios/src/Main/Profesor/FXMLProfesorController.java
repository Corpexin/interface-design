package Main.Profesor;

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
import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.Event;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.Tooltip;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;


/**
 * FXML Controller class
 * 
 * Controlador del Profesor
 *
 * @author corpex
 */
public class FXMLProfesorController extends AnchorPane implements Initializable {

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
    public String codProf;
    @FXML
    private ImageView btnAtras;
    @FXML
    private ImageView btnCerrar;
    private PracticaHorarios application;
    @FXML
    private Label lblCodProf;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
    }    
    
    

    @FXML //Evento que se lanza cuando se cambia de Tabla
    private void cambioTab(Event event) {
        String id = ((Tab)event.getSource()).getText();
        if(!id.matches(idAnt)){
            getHorarioDiario(id);
            idAnt = id;
        }
    }

    //Obtener el horario diario a partir del dia
    public void getHorarioDiario(String dia) {
        ObservableList datosDiario = FXCollections.observableArrayList();
        String horaInicio;
        String horaFin;
        String codAsig;
        
        configurarLblProf(); //configuro el profesor con su tooltip
        
        String query = "SELECT th.HoraInicio, th.HoraFin, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodProf = '" + codProf + "' && th.dia = '" + dia + "'";
        
        //Obtiene la hora y asignatura y la introduce en la lista
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                horaInicio = rs.getString("HoraInicio");
                horaFin = rs.getString("HoraFin");
                codAsig = rs.getString("codAsignatura");
                datosDiario.add(horaInicio + "-" + horaFin + "    -    " + codAsig);
            }
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
        //Dependiendo del dia los mete en una tabla o en otra
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

    @FXML //Evento que se lanza cuando presiona el boton atras
    private void atrasPressed(MouseEvent event) {
        application.cambiarEscenario(Helper.ID_LOGIN);
    }

    @FXML//Evento que se lanza cuando presiona el boton cerrar
    private void cerrarClicked(MouseEvent event) {
        Platform.exit();
        System.exit(0);
    }

    //Le pasa la referencia de la actividad principal para que actue como listener
    public void setApp(PracticaHorarios application) {
        this.application = application;
    }

    private void configurarLblProf() {
       lblCodProf.setText(codProf);
       lblCodProf.setTooltip(getInfoProf());
    }

    private Tooltip getInfoProf() {
        
         String query = "SELECT Nombre, Alta, FechaDeNacimiento FROM horario.profesor WHERE CodProf='"+codProf+"';";
         String nombre="";
         String alta="";
         String fechaNac="";
        
        //Obtiene la hora y asignatura y la introduce en la lista
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                nombre = rs.getString("Nombre");
                alta = rs.getString("Alta");
                fechaNac = rs.getString("FechaDeNacimiento");
            }
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        
        return new Tooltip(nombre+"\nFecha de Alta: "+alta+"\nFecha de Nacimiento: "+fechaNac);
    }
    
}
