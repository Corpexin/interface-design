/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cuadrado;

import static java.lang.Math.random;
import javafx.animation.KeyFrame;
import javafx.animation.KeyValue;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.effect.BlendMode;
import javafx.scene.effect.BoxBlur;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.scene.paint.CycleMethod;
import javafx.scene.paint.LinearGradient;
import javafx.scene.paint.Stop;
import javafx.scene.shape.Rectangle;
import javafx.scene.shape.StrokeType;
import javafx.stage.Stage;
import javafx.util.Duration;
import javafx.animation.*;

/**
 *
 * @author corpex
 */
public class Cuadrado extends Application {
    
    @Override
    public void start(Stage primaryStage) {
         Group root = new Group();
        Scene scene = new Scene(root, 800, 600, Color.BLACK);
        primaryStage.setScene(scene);
        Group square = new Group();
        
        Rectangle cuadrado = new Rectangle(60, 60, Color.CORAL);
        square.getChildren().add(cuadrado);
        
        Rectangle colors = new Rectangle(scene.getWidth(), scene.getHeight(), Color.web("white", 0.05));
        colors.widthProperty().bind(scene.widthProperty());
        colors.heightProperty().bind(scene.heightProperty());
        
        Group blendModeGroup = new Group(new Group(new Rectangle(scene.getWidth(), scene.getHeight(),Color.BLUE), square), colors);
        colors.setBlendMode(BlendMode.OVERLAY);
        root.getChildren().add(blendModeGroup);
        
        
        Timeline timeline = new Timeline();
        square.getChildren().stream().forEach((circle) -> {
            timeline.getKeyFrames().addAll(
                    new KeyFrame(Duration.ZERO, // set start position at 0
                            new KeyValue(circle.translateXProperty(), random() * 800),
                            new KeyValue(circle.translateYProperty(), random() * 600)
                    ),
                    new KeyFrame(new Duration(5000), // set end position at 40s
                            new KeyValue(circle.translateXProperty(), random() * 800),
                            new KeyValue(circle.translateYProperty(), random() * 600)
                    ),
                    new KeyFrame(new Duration(3000), // set end position at 40s
                            new KeyValue(circle.translateXProperty(), random() * 800),
                            new KeyValue(circle.translateYProperty(), random() * 600)
                    ),
                    new KeyFrame(new Duration(2000), // set end position at 40s
                            new KeyValue(circle.translateXProperty(), random() * 800),
                            new KeyValue(circle.translateYProperty(), random() * 600)
                    )
            );
        });
// play 40s of animation
        timeline.play();
        
        RotateTransition rt = new RotateTransition(Duration.millis(3000), cuadrado);
        rt.setByAngle(180);
        rt.setCycleCount(4);
        rt.setAutoReverse(true);

        rt.play();
        primaryStage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
