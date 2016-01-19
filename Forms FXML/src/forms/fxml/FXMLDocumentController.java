/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package forms.fxml;

 
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;
 
public class FXMLDocumentController {
    @FXML private Text actiontarget;
    @FXML private TextField tbUsuario;
    @FXML private TextField tbContraseña;
    
    @FXML protected void handleSubmitButtonAction(ActionEvent event) {
        if(tbUsuario.getText().matches("admin") && tbContraseña.getText().matches("admin")){
            actiontarget.setFill(Color.GREEN);
            actiontarget.setText("Usuario y contraseña correctos");
        }else{
            actiontarget.setFill(Color.FIREBRICK);
            actiontarget.setText("Usuario o contraseña invalidos");
        }
    }

}
