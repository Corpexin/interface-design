/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hola.mundo;

import java.util.Random;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author corpex
 */
public class HolaMundo extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        Button boton = new Button();
        
        //Transladamos
        moverBoton(boton);
        //Ponemos el boton vacio
        boton.setText("     ");
        //Evento de click
        boton.setOnAction((ActionEvent event) -> {
            moverBoton(boton);
        });
        
        //Panel principal
        StackPane root = new StackPane();
        root.getChildren().add(boton);
        
        //Al se mueve el boton al acercarse el raton
        root.setOnMouseMoved((MouseEvent event) -> {
            
            //arriba
            if (event.getY() - boton.getTranslateY() > 0 && boton.getTranslateX() > 35){
                moverBoton(boton);
            }
             //izquierda
            if (event.getX() - boton.getTranslateX() > 0 && boton.getTranslateX() > 35){
                moverBoton(boton);
            }
             //abajo
            if (event.getY() - boton.getTranslateY() < 0 && boton.getTranslateY() < maxSizeHeight - boton.Height - 35){
                moverBoton(boton);
            }
            //derecha
             if (event.getX() - boton.getTranslateX() < 0 && boton.getTranslateX() < maxSizeWidth - boton.Width - 35)
            {
                moverBoton(boton);
            }
            
            //CAMBIAR 35 POR -400?
            //CAMBIAR MAXSIZE - ... POR ...
        });   
        
        //Ventana Principal
        Scene scene = new Scene(root, 800, 600);
        primaryStage.setTitle("Boton Escurridizo");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }

    private void moverBoton(Button boton) {
       Random rnd = new Random();
       
       boton.setTranslateX(rnd.nextInt(800)-400);
       boton.setTranslateY(rnd.nextInt(600)-300);
       //boton.relocate(rnd.nextInt(800)-400, rnd.nextInt(600)-300);
       
      //boton.setLayout(rnd.nextDouble(400.0));
       
       
    }
    
}
