/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hola.mundo;

import java.util.Random;
import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.Pane;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import javafx.util.Duration;

/**
 *
 * @author corpex
 */
public class HolaMundo extends Application {
    int aceleracion;
    Button boton = new Button();
    
    @Override
    public void start(Stage primaryStage) {
        
        //Ponemos el boton vacio
        boton.setText("     ");
        boton.setLayoutX(400);
        boton.setLayoutY(300);
        //Panel principal
        Pane root = new Pane();
        root.getChildren().add(boton);
        
        //Al se mueve el boton al acercarse el raton
        root.setOnMouseMoved((MouseEvent event) -> {
            mirar(event);
        });
        
        //Al hacer click en boton
        boton.setOnAction((ActionEvent event) -> {
            boton.setScaleX(1);
            boton.setScaleY(1);
            boton.setLayoutX(400);
            boton.setLayoutY(300);
        });

        
        //Ventana Principal
        Scene scene = new Scene(root, 800, 600);
        primaryStage.setTitle("Boton Escurridizo");
        primaryStage.setScene(scene);
        primaryStage.show();
        
        
        timer();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }

    
    public void mirar(MouseEvent e){
            //Si la distancia es de 0-100 va corriendo, si la distancia es de 100-140 va andando.
        if (fDistancia((int)e.getX(), (int)e.getY(), (int)boton.getLayoutX(), (int)boton.getLayoutY()) < 100){
            aceleracion = 10;
            huir(e);
        }else if (fDistancia((int)e.getX(), (int)e.getY(), (int)boton.getLayoutX(), (int)boton.getLayoutY()) < 140){
            aceleracion = 5;
            huir(e);
        }
        if((boton.getLayoutX() == 35 && boton.getLayoutY()==35) || (boton.getLayoutX() == (800 - boton.getWidth() - 35) && boton.getLayoutY()==(600 - boton.getHeight() -35)) || (boton.getLayoutX() == 35 && boton.getLayoutY()==(600 - boton.getHeight() -35)) || (boton.getLayoutX() == (800 - boton.getWidth() - 35) && boton.getLayoutY()==35) ){
            salto();
        }
    }
    
     public void huir(MouseEvent e){
         //arriba
         if (e.getY() - boton.getLayoutY() > 0 && boton.getLayoutY() >= 35){
             boton.setLayoutY(boton.getLayoutY() + aceleracion);
         }
        //izquierda
        if (e.getX() - boton.getLayoutX() > 0 && boton.getLayoutX() >= 35){
            boton.setLayoutX(boton.getLayoutX() - aceleracion);
        }
        //abajo
        if (e.getY() - boton.getLayoutY() < 0 && boton.getLayoutY() <= 600 - boton.getHeight() -35 ){
            boton.setLayoutY(boton.getLayoutY() - aceleracion);
        }
        //derecha
        if (e.getX() - boton.getLayoutX() < 0 && boton.getLayoutX() <= 800 - boton.getWidth() - 35)
        {
            boton.setLayoutX(boton.getLayoutX() + aceleracion);
        }
     }
    
    
    
    private int fDistancia(int ratonX, int ratonY, int botonX, int botonY){
        return (int)Math.pow(Math.pow(ratonX - botonX, 2) + Math.pow(ratonY - botonY, 2), 0.5);
    }

    private void timer() {
       Timeline fiveSecondsWonder = new Timeline(new KeyFrame(Duration.seconds(5), (ActionEvent event) -> {
           boton.setScaleX(boton.getScaleX() + 1);
           boton.setScaleY(boton.getScaleY() + 1);
       }));
        fiveSecondsWonder.setCycleCount(Timeline.INDEFINITE);
        fiveSecondsWonder.play();
    }

    private void salto() {
       Random rnd = new Random();
       boton.setLayoutX(rnd.nextInt(800));
       boton.setLayoutY(rnd.nextInt(600));
    }
    
}
