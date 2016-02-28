/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen;

import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author corpex
 */
//Clase interna
public class Horarios {

    private final StringProperty codT;
    private final StringProperty codC;

    public Horarios(String codT, String codC) {
        this.codT = new SimpleStringProperty(codT);
        this.codC = new SimpleStringProperty(codC);
    }

    public StringProperty codTProperty() {
        return codT;
    }

    public StringProperty codCProperty() {
        return codC;
    }

    public String getCodT() {
        return codT.get();
    }

    public String getCodC() {
        return codC.get();
    }
}
