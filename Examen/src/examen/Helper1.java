/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author corpex
 */
public class Helper1 {
     //Clase estatica auxiliar, la usamos para la conexion a la BD y como clase de constantes (Asi matamos 2 pajaros de 1 tiro)
    private final static String BD_CONEXION= "jdbc:mysql://localhost/prueba";
    private final static String BD_USUARIO= "root";
    private final static String BD_PASSWORD= "PHILIPS355";
    
    //Devuelve una conexion. Configurar a gusto las propiedades
    public static Connection conexion() throws SQLException, ClassNotFoundException {
        Class.forName("com.mysql.jdbc.Driver");
        return DriverManager.getConnection(BD_CONEXION, BD_USUARIO, BD_PASSWORD);
    }
}
