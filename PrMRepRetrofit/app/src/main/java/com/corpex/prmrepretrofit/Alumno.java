package com.corpex.prmrepretrofit;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by corpex, by the Grace of God on 29/02/2016.
 */
public class Alumno implements Parcelable {
    private int id;
    private String nombre;
    private int edad;
    private String direccion;
    private String telefono;
    private String curso;
    private String foto;
    private Boolean repetidor;

    //Constructor
    public Alumno(Boolean repetidor, String nombre, int edad, String direccion, String telefono, String curso, String foto) {
        this.repetidor = repetidor;
        this.nombre = nombre;
        this.edad = edad;
        this.direccion = direccion;
        this.telefono = telefono;
        this.curso = curso;
        this.foto = foto;
    }

    public Alumno(String s) {
        nombre = s;
    }

    //Getters & setters
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public int getEdad() {
        return edad;
    }
    public void setEdad(int edad) {
        this.edad = edad;
    }
    public String getDireccion() {
        return direccion;
    }
    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }
    public String getTelefono() {
        return telefono;
    }
    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }
    public String getCurso() {
        return curso;
    }
    public void setCurso(String curso) {
        this.curso = curso;
    }
    public String getFoto() {
        return foto;
    }
    public void setFoto(String foto) {
        this.foto = foto;
    }
    public Boolean getRepetidor() {
        return repetidor;
    }
    public void setRepetidor(Boolean repetidor) {
        this.repetidor = repetidor;
    }
    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }

    //Parcelable implementations
    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(id);
        dest.writeValue(repetidor);
        dest.writeString(nombre);
        dest.writeInt(edad);
        dest.writeString(direccion);
        dest.writeString(telefono);
        dest.writeString(curso);
        dest.writeString(foto);
    }

    protected Alumno(Parcel in) {
        id = in.readInt();
        repetidor = (Boolean) in.readValue(null);
        nombre = in.readString();
        edad = in.readInt();
        direccion = in.readString();
        telefono = in.readString();
        curso = in.readString();
        foto = in.readString();
    }

    public static final Creator<Alumno> CREATOR = new Creator<Alumno>() {
        @Override
        public Alumno createFromParcel(Parcel in) {
            return new Alumno(in);
        }

        @Override
        public Alumno[] newArray(int size) {
            return new Alumno[size];
        }
    };
}
