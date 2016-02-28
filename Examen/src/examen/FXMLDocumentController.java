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
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.Tooltip;
import javafx.scene.effect.BlendMode;
import javafx.scene.input.ClipboardContent;
import javafx.scene.input.DragEvent;
import javafx.scene.input.Dragboard;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.input.TransferMode;

/**
 *
 * @author corpex
 */
public class FXMLDocumentController implements Initializable {
    
    private Label label;
    @FXML
    private ListView<String> lvLista;
    @FXML
    private TableView<Horarios> tvTabla;
    @FXML
    private TableColumn<Horarios, String> cl1;
    @FXML
    private TableColumn<Horarios, String> cl2;
    
    HashMap<String, String> mapaTooltip;
    @FXML
    private TextField tbBuscador;
    
    public Examen app;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        //Codigo para que las columnas cambien de tama;o automaticamente si se hace resize
        cl1.prefWidthProperty().bind(tvTabla.widthProperty().divide(2)); // 50%
        cl2.prefWidthProperty().bind(tvTabla.widthProperty().divide(2)); // 50%
        rellenarColumnas();
        //Configuramos la lista
        cargarAsignaturas("");
        configurarTooltip();
    }    
    
    //Inicializamos cada columna
    private void rellenarColumnas() {
        cl1.setCellValueFactory(cellData -> cellData.getValue().codTProperty());
        cl2.setCellValueFactory(cellData -> cellData.getValue().codCProperty());
    }

    private void cargarAsignaturas(String busc) {
        ObservableList datosAsignaturas = FXCollections.observableArrayList();
        String query = "SELECT CodAsignatura, Nombre, HorasSemanales, HorasTotales FROM horario.asignatura WHERE CodAsignatura LIKE '"+busc+"%';";
        mapaTooltip = new HashMap<>();
        String codA;
        String mnsjTooltip;
        
        try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
               codA = rs.getString("CodAsignatura");
               mnsjTooltip = "Nombre: "+rs.getString("Nombre")+"\nHoras Semanales: "+rs.getString("HorasSemanales")+"\nHoras Totales: "+rs.getString("HorasTotales");
               mapaTooltip.put(codA, mnsjTooltip);
               datosAsignaturas.add(codA);
            }
            lvLista.setItems(datosAsignaturas);
            
        } catch (SQLException | ClassNotFoundException ex) {}  
    }

    private void configurarTooltip() {
       lvLista.setCellFactory(lv -> { //Basicamente vamos a modificar la "factoria de celdas" a;adiendole el menu
            ListCell<String> listaCeldas = new ListCell<>();
            listaCeldas.textProperty().bind(listaCeldas.itemProperty());
            listaCeldas.emptyProperty().addListener((obs, wasEmpty, isNowEmpty) -> { 
                if (isNowEmpty) { //condicion para que el menu solo salga en tablas con contenido
                    listaCeldas.setTooltip(null);
                } else {
                    listaCeldas.setTooltip(new Tooltip(mapaTooltip.get(listaCeldas.itemProperty().get())));
                }
            });
            return listaCeldas ;
        });
    }

    @FXML
    private void lvItemClick(MouseEvent event) throws Exception {
        //Dependiendo del item clickeado se muestra una informacion determinada
        cargarInfo(lvLista.getSelectionModel().getSelectedItem());
        cargarVentana2();
    }

    private void cargarInfo(String selectedItem) {
        String query = "SELECT CodTramo, CodCurso FROM horario.horario WHERE CodAsignatura = '"+selectedItem+"';";
        String codT, codC;
        ObservableList<Horarios> horarios = FXCollections.observableArrayList();
        
        
         try {
            Connection connection = Helper.conexion();
            PreparedStatement sentencia = connection.prepareStatement(query);
            ResultSet rs = sentencia.executeQuery(query);
            while (rs.next()) {
               codT = rs.getString("CodTramo");
               codC = rs.getString("CodCurso");
               horarios.add(new Horarios(codT, codC));
            }
            tvTabla.setItems(horarios);
            
            
        } catch (SQLException | ClassNotFoundException ex) {}  
    }

    @FXML
    private void writeText(KeyEvent event) {
        //Habria que cambiar el tema este para que no cogiera texto, sino el keyevento
        if(tbBuscador.getText() == null){
            cargarAsignaturas("");
        }else{
            cargarAsignaturas(tbBuscador.getText());
        }
    }
    
    
    
     private void cargarVentana2() throws Exception {
        app.reemplazarContenido(2);
    }
    
    
    
    
    //DRAG&DROP BITCHES!
    /**
     * lista detected - empieza el drag and drop
     * lista done - termina el drag and drop
     * tabla entered - entra en componente que permite drop
     * tabla exited - sale de componente que permite drop
     * tabla over - se ejecuta continuamente cuando el drag esta encima de componente que permite drop
     * tabla droped - suelta el objeto drageado en componente de drop
     **/
    
    @FXML //entra en componente con drop habilitado
    private void DragEntrado(DragEvent event) {
         System.out.println("setOnDragEntered");
         tvTabla.setBlendMode(BlendMode.DIFFERENCE);
    }

    @FXML //Cuando se detecta que se quiere hacer d&d
    private void DragDetectado(MouseEvent event) {
        System.out.println("setOnDragDetected");

        Dragboard dragBoard = lvLista.startDragAndDrop(TransferMode.MOVE);

        ClipboardContent content = new ClipboardContent();

        content.putString(lvLista.getSelectionModel().getSelectedItem());

        dragBoard.setContent(content);
    }

    @FXML //Siempre se ejecuta al final cuando se termina el d&d
    private void DragHecho(DragEvent event) {
        System.out.println("setOnDragDone");
    }

    @FXML//cuando sale del componente que hace drag
    private void DragSalido(DragEvent event) {
        System.out.println("setOnDragExited");
        tvTabla.setBlendMode(null);
    }

    @FXML //cuando se suelta el drag sobre un elemento que permita drop
    private void DropSoltado(DragEvent event) {
        System.out.println("setOnDragDropped");

        String celda = event.getDragboard().getString();

        tbBuscador.setText(celda);
        event.setDropCompleted(true);
    }

    @FXML //cuando el objeto drageado esta encima
    private void DragEncima(DragEvent event) {
        System.out.println("setOnOver");
        event.acceptTransferModes(TransferMode.MOVE);
    }

   

}
