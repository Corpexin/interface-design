/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package forms;

import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import javafx.util.Duration;

/**
 *
 * @author corpex
 */
public class Forms extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("JavaFX Welcome");
        
        primaryStage.show();
        GridPane grid = new GridPane();
        grid.setAlignment(Pos.CENTER);
        grid.setHgap(10);
        grid.setVgap(10);
        grid.setPadding(new Insets(25, 25, 25, 25));

        final Text actiontarget = new Text();
        grid.add(actiontarget, 1, 6);
        actiontarget.setId("actiontarget");
        
        Scene scene = new Scene(grid, 300, 275);
        primaryStage.setScene(scene);
        scene.getStylesheets().add(Forms.class.getResource("style.css").toExternalForm());
        Text scenetitle = new Text("Bienvenido");
        scenetitle.setId("welcome-text");
        
        grid.add(scenetitle, 0, 0, 2, 1);

        Label userName = new Label("Usuario:");
        grid.add(userName, 0, 1);
        userName.setId("usuario");

        TextField userTextField = new TextField();
        grid.add(userTextField, 1, 1);

        Label pw = new Label("Contraseña:");
        grid.add(pw, 0, 2);
        pw.setId("contra");
        PasswordField pwBox = new PasswordField();
        grid.add(pwBox, 1, 2);
        
        Button btn = new Button("Sign in");
        HBox hbBtn = new HBox(10);
        hbBtn.setAlignment(Pos.BOTTOM_RIGHT);
        hbBtn.getChildren().add(btn);
        grid.add(hbBtn, 1, 4);
        
        
        
        btn.setOnAction((ActionEvent e) -> {
            timer(actiontarget);
            if(pwBox.getText().matches("admin") && userTextField.getText().matches("admin")){
                actiontarget.setFill(Color.GREEN);
                actiontarget.setText("Usuario o contraseña correcta");
            }else{
                actiontarget.setFill(Color.FIREBRICK);
                actiontarget.setText("Usuario o contraseña incorrecta");
            }

        });
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
    private void timer(Text actionTarget) {
       Timeline t = new Timeline(new KeyFrame(Duration.seconds(3), (ActionEvent event) -> {
           actionTarget.setText("");
       }));
        t.setCycleCount(1);
        t.play();
    }
    
}
