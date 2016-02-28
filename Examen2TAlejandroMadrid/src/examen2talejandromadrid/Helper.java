/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen2talejandromadrid;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author corpex
 */
public class Helper {
      //Clase para Base de datos y lo que surja
    private final static String BD_CONEXION= "jdbc:mysql://localhost/alumno_examen";
    private final static String BD_USUARIO= "root";
    private final static String BD_PASSWORD= "PHILIPS355";
    
    //Constantes
    public final static int LOGIN = 1;
    public final static int LISTAP = 2;
    public final static int NUEVAP = 3;
    public final static int ESTADIST = 4;
    

    public static Connection conexion() throws SQLException, ClassNotFoundException {
        Class.forName("com.mysql.jdbc.Driver");
        return DriverManager.getConnection(BD_CONEXION, BD_USUARIO, BD_PASSWORD);
    }
}
