/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package POJO;

import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class TramoPOJO {

    private final StringProperty codTramo;
    private final StringProperty codAsig;


    public TramoPOJO(String codTramo, String codAsig) {
        this.codTramo = new SimpleStringProperty(codTramo);
        this.codAsig = new SimpleStringProperty(codAsig);
    }
    
    
    public String getCodTramo() {
        return codTramo.get();
    }

    public String getCodAsig() {
        return codAsig.get();
    }

    
    public void setCodTramo(String codTramo) {
        this.codTramo.set(codTramo);
    }
    public void setCodAsig(String codAsig) {
        this.codAsig.set(codAsig);
    }
 
}