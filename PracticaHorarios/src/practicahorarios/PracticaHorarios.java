/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package practicahorarios;

import java.io.InputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.fxml.JavaFXBuilderFactory;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

/**
 * @author corpex
 */
public class PracticaHorarios extends Application {

    private Stage stage;
    FXMLLoginController login;
    @Override
    public void start(Stage primaryStage) throws Exception {
        stage = primaryStage;
        goToLogin();
        primaryStage.show();
        stage.setTitle("Horarios");
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);

    }

    private void goToLogin() {
        try {
            login = (FXMLLoginController) replaceSceneContent("FXMLLogin.fxml");
            login.setApp(this);
        } catch (Exception ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void goToHorario() {
        try {
            replaceSceneContent("FXMLDocument.fxml");
        } catch (Exception ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
     private void goToPersonalHorario() {
        try {
            FXMLProfesorHController horarioP = (FXMLProfesorHController) replaceSceneContent("FXMLProfesorH.fxml");
        } catch (Exception ex) {
            Logger.getLogger(PracticaHorarios.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public boolean userLogging(String userId, String password) {
        boolean result = true;
        String query;
        int tipoUsuario = 99;
        query = "SELECT tipousuario FROM horario.login WHERE usuario='"+userId+"' AND password = '"+password+"'";

        try {
            // Cargamos el driver
            Class.forName("com.mysql.jdbc.Driver");
            // Preparamos la consulta
            try (Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/horario", "root", "PHILIPS355"); Statement sentencia = conexion.createStatement()) {
                ResultSet rs = sentencia.executeQuery(query);
                ResultSetMetaData rsmd = rs.getMetaData();
                if(rs.next()) {
                    tipoUsuario = rs.getInt("tipousuario");
                }
            }
        } catch (ClassNotFoundException cn) {
        } catch (SQLException ex) {
            System.out.printf("Error Excepcion");
        }
        
        switch (tipoUsuario) {
            case 0:
                goToHorario();
                break;
            case 1:
                goToPersonalHorario();
                break;
            default:
                result = false;
                break;
        }
        
        return result;
    }

    private Initializable replaceSceneContent(String fxml) throws Exception {
        FXMLLoader loader = new FXMLLoader();
        
        InputStream in = PracticaHorarios.class.getResourceAsStream(fxml);
        loader.setBuilderFactory(new JavaFXBuilderFactory());
        loader.setLocation(PracticaHorarios.class.getResource(fxml));
       
        AnchorPane page;
        try {
            page = (AnchorPane) loader.load(in);
            if (fxml.matches("FXMLProfesorH.fxml")) {
                ((FXMLProfesorHController) loader.getController()).codProf = login.getCodProf();
            }
        } finally {
            in.close();
        }
        Scene scene = new Scene(page);
        stage.setScene(scene);
        stage.sizeToScene();
        return (Initializable) loader.getController();
    }

}