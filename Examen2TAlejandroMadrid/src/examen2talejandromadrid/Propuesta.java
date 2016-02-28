/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examen2talejandromadrid;

import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author corpex
 */
class Propuesta {
    private final StringProperty propuesta;
    private final StringProperty votos;

    public Propuesta(String propuesta, String votos) {
        this.propuesta = new SimpleStringProperty(propuesta);
        this.votos = new SimpleStringProperty(votos);
    }

    public StringProperty propuestaProperty() {
        return propuesta;
    }

    public StringProperty votosProperty() {
        return votos;
    }

    public String getPropuesta() {
        return propuesta.get();
    }

    public String getVotos() {
        return votos.get();
    }
}
