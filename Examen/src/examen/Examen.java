/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen;

import java.io.IOException;
import java.io.InputStream;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.fxml.JavaFXBuilderFactory;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 *
 * @author corpex
 */
public class Examen extends Application {
    double xOffset=0;
    double yOffset=0;
    Stage stage;
    FXMLDocumentController ventana1;
    FXMLVentana2Controller ventana2;
    
    @Override
    public void start(Stage st) throws Exception {
        stage = st;
        stage.initStyle(StageStyle.UNDECORATED); //para que aparezca sin parte superior
        reemplazarContenido(1);
        stage.setMinWidth(340);
        stage.setMinHeight(240);
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
    public void reemplazarContenido(int i) throws Exception {
       switch(i){
           case 1:
               ventana1 = (FXMLDocumentController) replaceSceneContent("FXMLDocument.fxml");
               ventana1.app = this;
               break;
           case 2:
               ventana2 = (FXMLVentana2Controller) replaceSceneContent("FXMLVentana2.fxml");
               ventana2.app = this;
               break;
       }
    }
     

    
    private Initializable replaceSceneContent(String fxml) throws Exception {
        FXMLLoader loader = new FXMLLoader();
        
        InputStream in = getClass().getResourceAsStream(fxml);
        loader.setBuilderFactory(new JavaFXBuilderFactory());
        loader.setLocation(getClass().getResource(fxml));
        
        AnchorPane page;
        try {
            page = (AnchorPane) loader.load(in);
        } finally {
            in.close();
        }
        
         //Evento para dragear la  ventana
        page.setOnMousePressed((MouseEvent event) -> {
            xOffset = stage.getX() - event.getScreenX();
            yOffset = stage.getY() - event.getScreenY();
        });
        
        //Evento 2 para dragear la ventana
        page.setOnMouseDragged((MouseEvent event) -> {
            stage.setX(event.getScreenX() + xOffset);
            stage.setY(event.getScreenY() + yOffset);
        });
        
        //Creamos la escena con el page y la cambiamos en el stage
        Scene scene = new Scene(page);
        stage.setScene(scene);
        
        //Condiciones para cargar los css de cada FXML
        switch(fxml){
            case "FXMLDocument.fxml":
                scene.getStylesheets().add(Examen.class.getResource("Document.css").toExternalForm());
                break;
            case "FXMLVentana2.fxml":
                scene.getStylesheets().add(Examen.class.getResource("fxmlventana2.css").toExternalForm());
                break;
        }
        stage.sizeToScene();
        stage.centerOnScreen(); //la escena siempre aparecera centrada en pantalla
        return (Initializable) loader.getController();
    }

   
    
}
