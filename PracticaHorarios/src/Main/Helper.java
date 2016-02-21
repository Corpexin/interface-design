package Main;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * @author corpex
 */
public class Helper {
    //Clase estatica auxiliar, la usamos para la conexion a la BD y como clase de constantes (Asi matamos 2 pajaros de 1 tiro)
    private final static String BD_CONEXION= "jdbc:mysql://localhost/horario";
    private final static String BD_USUARIO= "root";
    private final static String BD_PASSWORD= "PHILIPS355";
    
    //Devuelve una conexion. Configurar a gusto las propiedades
    public static Connection conexion() throws SQLException, ClassNotFoundException {
        Class.forName("com.mysql.jdbc.Driver");
        return DriverManager.getConnection(BD_CONEXION, BD_USUARIO, BD_PASSWORD);
    }
    
    //Constantes
    public final static int ID_LOGIN = 1;
    public final static int ID_USUARIO = 2;
    public final static int ID_PROFESOR = 3;
}
