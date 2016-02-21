package Main.Usuario;

import Main.Helper;
import POJO.HorarioPOJO;
import Main.PracticaHorarios;
import POJO.TramoPOJO;
import java.net.URL;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ContextMenu;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.control.MenuItem;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TableCell;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.Tooltip;
import javafx.scene.image.ImageView;
import javafx.scene.input.ClipboardContent;
import javafx.scene.input.DragEvent;
import javafx.scene.input.Dragboard;
import javafx.scene.input.MouseEvent;
import javafx.scene.input.TransferMode;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.BorderPane;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 * FXML Controller class
 * 
 * Controlador del Usuario
 * 
 * @author corpex
 */
public class FXMLUsuarioController implements Initializable {

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
    private TableView<HorarioPOJO> tbHorarioSemanal;
    @FXML
    private TableColumn<HorarioPOJO, String> clHora;
    @FXML
    private TableColumn<HorarioPOJO, String> clLunes;
    @FXML
    private TableColumn<HorarioPOJO, String> clMartes;
    @FXML
    private TableColumn<HorarioPOJO, String> clMiercoles;
    @FXML
    private TableColumn<HorarioPOJO, String> clJueves;
    @FXML
    private TableColumn<HorarioPOJO, String> clViernes;
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
        configurarTabla();
        getProfesores();
        rellenarColumnas();
    }
    
    //Metodo para que la clase reciba la referencia a la clase principal y que actue como listener
    public void setApp(PracticaHorarios application) {
        this.application = application;
    }

    //Metodo para habilitar el menu contextual en la listview de horas
    private void configurarLista() {
        lvHorario.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
            ListCell<String> listaCeldas = new ListCell<>();
            listaCeldas.textProperty().bind(listaCeldas.itemProperty());
            listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> { 
                if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
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
    
    //Añadimos tooltip en cada celda
     private void configurarTabla() {
         clLunes.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
            TableCell<HorarioPOJO,String> listaCeldas = new TableCell<>();
            listaCeldas.textProperty().bind(listaCeldas.itemProperty());
            listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> { 
                if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
                    listaCeldas.setContextMenu(null);
                } else {
                    listaCeldas.setTooltip(new Tooltip(obtenerInfo(listaCeldas.itemProperty().get()))); 
                }
            });
            return listaCeldas ;
        });
         
         clMartes.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
             TableCell<HorarioPOJO, String> listaCeldas = new TableCell<>();
             listaCeldas.textProperty().bind(listaCeldas.itemProperty());
             listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> {
                 if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
                     listaCeldas.setContextMenu(null);
                 } else {
                     listaCeldas.setTooltip(new Tooltip(obtenerInfo(listaCeldas.itemProperty().get())));
                 }
             });
             return listaCeldas;
         });
         
         clMiercoles.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
             TableCell<HorarioPOJO, String> listaCeldas = new TableCell<>();
             listaCeldas.textProperty().bind(listaCeldas.itemProperty());
             listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> {
                 if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
                     listaCeldas.setContextMenu(null);
                 } else {
                     listaCeldas.setTooltip(new Tooltip(obtenerInfo(listaCeldas.itemProperty().get())));
                 }
             });
             return listaCeldas;
         });
         
         clJueves.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
             TableCell<HorarioPOJO, String> listaCeldas = new TableCell<>();
             listaCeldas.textProperty().bind(listaCeldas.itemProperty());
             listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> {
                 if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
                     listaCeldas.setContextMenu(null);
                 } else {
                     listaCeldas.setTooltip(new Tooltip(obtenerInfo(listaCeldas.itemProperty().get())));
                 }
             });
             return listaCeldas;
         });
         
         clViernes.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
             TableCell<HorarioPOJO, String> listaCeldas = new TableCell<>();
             listaCeldas.textProperty().bind(listaCeldas.itemProperty());
             listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> {
                 if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
                     listaCeldas.setContextMenu(null);
                 } else {
                     listaCeldas.setTooltip(new Tooltip(obtenerInfo(listaCeldas.itemProperty().get())));
                 }
             });
             return listaCeldas;
         });
    }
     
    //Metodo que carga en el combobox los profesores
    private void getProfesores() {
        ObservableList datosProf = FXCollections.observableArrayList();
        codProfLista = new ArrayList<>();
        String nombre;
        String codProf;
        
        String query = "SELECT nombre, CodProf FROM Profesor";
        
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                nombre = rs.getString("nombre");
                codProf = rs.getString("CodProf");
                datosProf.add(nombre);
                codProfLista.add(codProf);
            }
            cbProfesor.setItems(datosProf);
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @FXML //Evento que se lanza cuando se cambia de profesor en el combobox
    private void cbProfesorSelectedItemChanged(ActionEvent event) {
        int opcionRB;
        //Comprueba cual radiobutton esta activado, para hacer una u otra accion
        if (rbDiario.isSelected()) {
            opcionRB = 1;
        } else if (rbSemanal.isSelected()) {
            opcionRB = 2;
        } else {
            opcionRB = 3;
        }

        //Si radiobutton es el de horario diario lanza el listview, si es el otro, lanza el tableview.
        //Si no hay ninguno muestra un mensaje.
        String selectedProfesor = cbProfesor.getSelectionModel().getSelectedItem().toString();
        switch (opcionRB) {
            case 1://diario
                getHorarioDiario("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
                break;
            case 2://semanal
                getHorarioSemanal("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
                configurarTabla();
                break;
            case 3://ninguno seleccionado
                ObservableList data = FXCollections.observableArrayList();
                data.add("No se ha seleccionado RadioButton");
                lvHorario.setItems(data);
                break;
        }
    }
    
    //Metodo que obtiene el horario diario y lo introduce en el listview
    private void getHorarioDiario(String codProf) {
        ObservableList datosDiario = FXCollections.observableArrayList();
        Date d = new Date();
        SimpleDateFormat formato = new SimpleDateFormat("EEEE");
        String dia = formato.format(d);
        String horaInicio;
        String horaFin;
        String codAsig;
        String query = "SELECT th.HoraInicio, th.HoraFin, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodProf = '" + codProf + "' && th.dia = '" + dia + "'";
        
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
            lvHorario.setItems(datosDiario);
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    //Metodo que obtiene el horario semanal y lo introduce en la table
    private void getHorarioSemanal(String codProf) {
        ObservableList<HorarioPOJO> data = FXCollections.observableArrayList();
        ArrayList<TramoPOJO> tramos = new ArrayList<>();
        String codTramo;
        String codAsig;
        String query = "SELECT th.codTramo, re.CodAsignatura FROM Reparto as re,  Horario as ho LEFT JOIN TramoHorario as th ON th.codTramo = ho.codTramo WHERE re.CodAsignatura = ho.CodAsignatura && re.CodCurso = ho.codCurso && re.CodOe = ho.CodOe && re.CodProf = '" + codProf + "' ORDER BY SUBSTRING(th.codTramo, 2)  ASC, CASE WHEN th.codTramo LIKE 'L%' THEN 1 WHEN th.codTramo LIKE 'M%' THEN 2 WHEN th.codTramo LIKE 'X%' THEN 3 WHEN th.codTramo LIKE 'J%' THEN 4 WHEN th.codTramo LIKE 'V%' THEN 5 END";
        
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                codTramo = rs.getString("th.codTramo");
                codAsig = rs.getString("re.CodAsignatura");
                tramos.add(new TramoPOJO(codTramo, codAsig));
            }
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }

        String[] semana = new String[5];
        String hora = "";

        //Como el contenido hay que introducirlo en horizontal,  hay que agrupar
        //las asignaturas por dia e ir introduciendolas en el array
        for (int i = 0; i < 6; i++) {
            //Renueva el array
            for (int j = 0; j < semana.length; j++) {
                semana[j] = "";
            }
            for (TramoPOJO t : tramos) {
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
            //Por cada fila vamos introduciendo tambien el horario
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
            data.add(new HorarioPOJO(hora, semana[0], semana[1], semana[2], semana[3], semana[4]));
        }
        tbHorarioSemanal.setItems(data);//vinculamos los datos a la tabla
    }
    
    //Inicializamos cada columna
    private void rellenarColumnas() {
        clHora.setCellValueFactory(cellData -> cellData.getValue().HoraProperty());
        clLunes.setCellValueFactory(cellData -> cellData.getValue().LunesProperty());
        clMartes.setCellValueFactory(cellData -> cellData.getValue().MartesProperty());
        clMiercoles.setCellValueFactory(cellData -> cellData.getValue().MiercolesProperty());
        clJueves.setCellValueFactory(cellData -> cellData.getValue().JuevesProperty());
        clViernes.setCellValueFactory(cellData -> cellData.getValue().ViernesProperty());
    }

    @FXML//Evento que se lanza cuando se pulsa el radiobutton de horario semanal
    private void rbSemanalPressed(ActionEvent event) {
        //Dependiendo de cual estuviera seleccionado antes, seleccionamos/deseleccionamos el otro
        if(!rbSemanal.isSelected()){
            rbSemanal.setSelected(true);
        }
        if(rbDiario.isSelected()){
            rbDiario.setSelected(false);
        }
        lvHorario.setVisible(false); //ocultamos el horario diario
        tbHorarioSemanal.setVisible(true); //mostramos el horario semanal
        
        //Mostramos el horario diario si no hay ningun profesor deseleccionado
        if(!cbProfesor.getSelectionModel().isEmpty() && rbDiario.isSelected())
            getHorarioDiario("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
        else if(!cbProfesor.getSelectionModel().isEmpty() && rbSemanal.isSelected())
            getHorarioSemanal("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
    }

    @FXML//Evento que se lanza cuando el radiobutton de horario diario es seleccinado
    private void rbDiarioPressed(ActionEvent event) {
        //Dependiendo de cual estuviera seleccionado antes, seleccionamos/deseleccionamos el otro
        if(!rbDiario.isSelected()){
            rbDiario.setSelected(true);
        }
         if(rbSemanal.isSelected()){
            rbSemanal.setSelected(false);
        }
         
        lvHorario.setVisible(true);//mostramos la lista de horario diario
        tbHorarioSemanal.setVisible(false);//ocultamos la tabla
        
        //carga los datos del profesor seleccionado en la tabla
        if(!cbProfesor.getSelectionModel().isEmpty() && rbDiario.isSelected())
            getHorarioDiario("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
        else if(!cbProfesor.getSelectionModel().isEmpty() && rbSemanal.isSelected())
            getHorarioSemanal("" + codProfLista.get(cbProfesor.getSelectionModel().getSelectedIndex()));
    }

    @FXML//Evento que se lanza cuando el usuario pulsa en la X de cerrar
    private void btnCerrarClick(MouseEvent event) {
        Platform.exit();
        System.exit(0);//cierra la aplicacion
    }

    @FXML//Evento que se lanza cuando el usuario pulsa en la flecha "atras"
    private void btnAtrasClick(MouseEvent event) {
        application.cambiarEscenario(Helper.ID_LOGIN); //carga el login
    }
    
    //Obtiene la informacion de una asignatura en el listview a partir del codigo
    public String obtenerInfo(String codigo){
        String idA;
        if(codigo.length()>5)
            idA = codigo.substring(26);
        else
            idA = codigo;
                
        String query = "SELECT * FROM asignatura WHERE codAsignatura = '"+idA+"';";
        String nombre="";
        int horasS=0;
        int horasT=0;

        //En concreto obtenemos el nombre completo, las horas semanales y totales de esa asignatura
         try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
                nombre = rs.getString("Nombre");
                horasS = rs.getInt("HorasSemanales");
                horasT = rs.getInt("HorasTotales");
            }
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
        return nombre+"\nHoras semanales: "+horasS+"\nHoras totales: "+horasT; //Retornamos toda esa informacion como String formateado
    }

    @FXML//Evento que se lanza cuando se hace click en el boton del menu about
    private void aboutClick(ActionEvent event) {
        //Se lanza un dialog con informacion del desarrollador =P
        Alert alert = new Alert(AlertType.INFORMATION);
        alert.setTitle("Acerca de Corpex");
        alert.setHeaderText(null);
        alert.setContentText("Email: corpex@gmx.com\nGithub: https://github.com/Corpexin");
        alert.showAndWait();
    }

    @FXML//Evento que se lanza cuando se hace click en el boton del menu version
    private void versionClick(ActionEvent event) {
        //Se lanza un dialog con informacion sobre la version de la tecnologia utilizada
        Alert alert = new Alert(AlertType.INFORMATION);
        alert.initStyle(StageStyle.UTILITY);
        alert.setTitle("Version");
        alert.setHeaderText(null);
        alert.setContentText("Versión programa: 1.0\nVersion Java: 8\nVersion Mysql: 1.4");
        alert.showAndWait();
    }

    @FXML //Evento de drag and drop en el easter egg
    private void dragDropAction(ActionEvent event) {
        //Se lanza un nuevo escenario
        final Stage startPage = new Stage();
        startPage.initStyle(StageStyle.DECORATED);
        //startPage.initOwner(primaryStage);
        //startPage.toFront();
        Group root = new Group();
        Scene scene = new Scene(root, 400, 200);
        startPage.setScene(scene);
        scene.setFill(Color.CADETBLUE);
        
        //Se usan dos textos para el drag and drop
        final Text source = new Text(50, 100, "ARRASTRAR");
        source.setScaleX(2.0);
        source.setScaleY(2.0);

        final Text target = new Text(250, 100, "SOLTAR AQUI");
        target.setScaleX(2.0);
        target.setScaleY(2.0);

        //Metodo cuando detecta que se esta realizando el drag
        source.setOnDragDetected((MouseEvent event1) -> {
            Dragboard db = source.startDragAndDrop(TransferMode.ANY);
            ClipboardContent content = new ClipboardContent();
            content.putString(source.getText());
            db.setContent(content);
            event1.consume();
        });

        //Metodo cuando detecta que ha parado de hacer drag
        target.setOnDragOver((DragEvent event1) -> {
            if (event1.getGestureSource() != target && event1.getDragboard().hasString()) {
                event1.acceptTransferModes(TransferMode.COPY_OR_MOVE);
            }
            event1.consume();
        });

        //Metodo cuando detecta que el drag entra en zona de drop
        target.setOnDragEntered((DragEvent event1) -> {
            if (event1.getGestureSource() != target && event1.getDragboard().hasString()) {
                target.setFill(Color.CADETBLUE);
            }
            event1.consume();
        });

        //Metodo cuando sale del drag
        target.setOnDragExited((DragEvent event1) -> {
            target.setFill(Color.AQUA);
            event1.consume();
        });
        
        //Metodo cuando suelta el elemento drageado
        target.setOnDragDropped((DragEvent event1) -> {
            Dragboard db = event1.getDragboard();
            boolean success = false;
            if (db.hasString()) {
                target.setText(db.getString());
                success = true;
            }
            event1.setDropCompleted(success);
            event1.consume();
        });

        //Metodo cuando se ha completado el draganddrop
        source.setOnDragDone((DragEvent event1) -> {
            if (event1.getTransferMode() == TransferMode.MOVE) {
                source.setText("");
                target.setText("BIEN HECHO ;D");
            }
            event1.consume();
        });

        root.getChildren().add(source);
        root.getChildren().add(target);
        startPage.show(); //mostrar el escenario
    }

    //         ¯\_(ツ)_/¯ 
    private Parent agentsPanel() {
        BorderPane bp = new BorderPane();
        bp.setPrefSize(300, 200);
        bp.setMaxSize(300, 200);
        return bp;
    }

   
}
