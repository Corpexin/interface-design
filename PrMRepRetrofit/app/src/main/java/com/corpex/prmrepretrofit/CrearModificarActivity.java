package com.corpex.prmrepretrofit;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.Toast;

import retrofit2.Callback;
import retrofit2.Response;

public class CrearModificarActivity extends AppCompatActivity {
    public static final int MODO_CREAR = 1;
    public static final int MODO_EDICION = 33;
    public static final String INTENT_ALUMNO_CREADO = "alumnoCreado";
    public static final String INTENT_ALUMNO_EDITADO = "alumnoEditado";
    private int modoActual;
    private TextInputLayout tilNombre;
    private Spinner spCurso;
    private FloatingActionButton fab;
    private TextInputLayout tilEdad;
    private TextInputLayout tilDireccion;
    private TextInputLayout tilTlf;
    private TextInputLayout tilFoto;
    private EditText txtNombre;
    private EditText txtEdad;
    private EditText txtDireccion;
    private EditText txtTlf;
    private EditText txtFoto;
    private RadioButton rbSi;
    private RadioButton rbNo;
    private Alumno alumno;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_crear_modificar);
        initViews();
        //Si se entra editando.
        if((alumno = getIntent().getParcelableExtra(INTENT_ALUMNO_EDITADO)) != null){
            modoActual = MODO_EDICION;
            rellenarCampos();
        }
    }

    private void initViews() {
        tilNombre = (TextInputLayout)  findViewById(R.id.tilNombre);
        tilEdad = (TextInputLayout)  findViewById(R.id.tilEdad);
        tilDireccion = (TextInputLayout) findViewById(R.id.tilDireccion);
        tilTlf = (TextInputLayout) findViewById(R.id.tilTlf);
        tilFoto = (TextInputLayout) findViewById(R.id.tilFoto);
        txtNombre = (EditText) findViewById(R.id.txtNombre);
        txtEdad = (EditText) findViewById(R.id.txtEdad);
        txtDireccion = (EditText) findViewById(R.id.txtDireccion);
        rbSi = (RadioButton) findViewById(R.id.rbSi);
        rbNo = (RadioButton) findViewById(R.id.rbNo);
        txtTlf = (EditText) findViewById(R.id.txtTlf);
        txtFoto = (EditText) findViewById(R.id.txtFoto);

        spCurso = (Spinner) findViewById(R.id.spCurso);

        String[] datos = getResources().getStringArray(R.array.arrayCursos);
        ArrayAdapter<String> adaptador = new ArrayAdapter<String>(this,android.R.layout.simple_spinner_item, datos);
        adaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spCurso.setAdapter(adaptador);

        fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(comprobarCamposVacios()) {
                    if (modoActual == MODO_EDICION)
                        confirmarEdicion();
                    else
                        confirmarCreacion();
                }
            }
        });
    }


    private void confirmarCreacion(){

        alumno = crearAlumnoFromForm();
        InterfazPeticiones.getServicio().crearAlumno(alumno).enqueue(new Callback<Alumno>() {
            @Override
            public void onResponse(Response<Alumno> response) {
                //Se devuelve el alumno creado al MainActivity para que se encargue de introducirlo en el adaptador.
                setResult(RESULT_OK, new Intent().putExtra(INTENT_ALUMNO_CREADO, alumno));
                finish();
            }

            @Override
            public void onFailure(Throwable t) {
                Toast.makeText(CrearModificarActivity.this, "Error: El alumno no ha podido ser creado.", Toast.LENGTH_LONG).show();
            }
        });

    }
    private void confirmarEdicion(){
        final Alumno alumnoEditado = crearAlumnoFromForm();
        //Se le asigna el id del alumno que se está editando.
        alumnoEditado.setId(alumno.getId());

        InterfazPeticiones.getServicio().actualizarAlumno(alumno.getId(), alumnoEditado).enqueue(new Callback<Alumno>() {
            @Override
            public void onResponse(Response<Alumno> response) {
                setResult(RESULT_OK, new Intent().putExtra(INTENT_ALUMNO_EDITADO, alumnoEditado));
                finish();
            }

            @Override
            public void onFailure(Throwable t) {
                Toast.makeText(CrearModificarActivity.this, "Error: No se ha podido actualizar este alumno.", Toast.LENGTH_LONG).show();
            }
        });
    }
    private Alumno crearAlumnoFromForm(){
        //Se crea un alumno con los datos del formulario.
        return new Alumno(rbSi.isChecked(), txtNombre.getText().toString(), Integer.parseInt(txtEdad.getText().toString()), txtDireccion.getText().toString(), txtTlf.getText().toString(), spCurso.getSelectedItem().toString(), txtFoto.getText().toString());
    }



    private void rellenarCampos() {
        txtNombre.setText(alumno.getNombre());
        txtEdad.setText(alumno.getEdad() + "");
        txtTlf.setText(alumno.getTelefono());
        txtFoto.setText(alumno.getFoto());
        txtDireccion.setText(alumno.getDireccion());
        if(alumno.getRepetidor())
            rbSi.setChecked(true);
        else
            rbNo.setChecked(true);
        spCurso.setSelection(((ArrayAdapter) spCurso.getAdapter()).getPosition(alumno.getCurso()));

    }


    public static void startCreadorForResult(Activity mainActivityClass) {
        Intent intent= new Intent(mainActivityClass,CrearModificarActivity.class);
        mainActivityClass.startActivityForResult(intent, MODO_CREAR);
    }

    public static void startEditorForResult(MainActivity mainActivity, Alumno alumno) {
        Intent intent= new Intent(mainActivity,CrearModificarActivity.class);
        intent.putExtra(INTENT_ALUMNO_EDITADO, alumno);
        mainActivity.startActivityForResult(intent,MODO_EDICION);
    }


    private boolean comprobarCamposVacios(){
        boolean rellenos = false;
        //Comprueba que todos los til están rellenos.
        if(!comprobarTil(tilNombre))
            rellenos = true;
        if(!comprobarTil(tilTlf))
            rellenos = true;
        if(!comprobarTil(tilDireccion))
            rellenos = true;
        if(!comprobarTil(tilFoto))
            rellenos = true;
        if(!comprobarTil(tilEdad))
            rellenos = true;

        return rellenos;
    }

    //Comprueba si el editText del interior del TextInputLayout está vacio
    // y muestra un error si estuviera vacío.
    private boolean comprobarTil(TextInputLayout til) {

        if(til.getEditText().getText().toString().isEmpty()){
            til.setError("Campo requerido");
            til.setErrorEnabled(true);
        }
        else
            til.setErrorEnabled(false);

        return til.isErrorEnabled();
    }

}
