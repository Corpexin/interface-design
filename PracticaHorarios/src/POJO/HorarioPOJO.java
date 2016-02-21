/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package POJO;

import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author corpex
 */
public class HorarioPOJO {

    private final StringProperty Hora;
    private final StringProperty Lunes;
    private final StringProperty Martes;
    private final StringProperty Miercoles;
    private final StringProperty Jueves;
    private final StringProperty Viernes;

    public HorarioPOJO(String Hora, String Lunes, String Martes, String Miercoles, String Jueves, String Viernes) {
        this.Hora = new SimpleStringProperty(Hora);
        this.Lunes = new SimpleStringProperty(Lunes);
        this.Martes = new SimpleStringProperty(Martes);
        this.Miercoles = new SimpleStringProperty(Miercoles);
        this.Jueves = new SimpleStringProperty(Jueves);
        this.Viernes = new SimpleStringProperty(Viernes);
    }
    
    public StringProperty HoraProperty() {
        return Hora;
    }
    
    public StringProperty LunesProperty() {
        return Lunes;
    }
    
    public StringProperty MartesProperty() {
        return Martes;
    }
    
    public StringProperty MiercolesProperty() {
        return Miercoles;
    }
    
    public StringProperty JuevesProperty() {
        return Jueves;
    }
    
    public StringProperty ViernesProperty() {
        return Viernes;
    }
    
    
    
    public String getHora() {
        return Hora.get();
    }

    public String getLunes() {
        return Lunes.get();
    }

    public String getMartes() {
        return Martes.get();
    }

    public String getMiercoles() {
        return Miercoles.get();
    }

    public String getJueves() {
        return Jueves.get();
    }

    public String getViernes() {
        return Viernes.get();
    }
    
    public void setHora(String Hora) {
        this.Hora.set(Hora);
    }
    public void setLunes(String Lunes) {
        this.Lunes.set(Lunes);
    }
    public void setMartes(String Martes) {
        this.Martes.set(Martes);
    }
    public void setMiercoles(String Miercoles) {
        this.Miercoles.set(Miercoles);
    }
    public void setJueves(String Jueves) {
        this.Jueves.set(Jueves);
    }
    public void setViernes(String Viernes) {
        this.Viernes.set(Viernes);
    }
}
