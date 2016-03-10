package com.corpex.prmrepretrofit;

import android.content.Intent;
import android.os.Bundle;
import android.os.Parcelable;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity implements AlumnosAdapter.OnItemClickListener, AlumnosAdapter.OnItemLongClickListener{
    private static final String STATE_LISTA = "estadoLista";
    static ArrayList<Alumno> alumnos;
    private RecyclerView lstAlumnos;
    private AlumnosAdapter mAdaptador;
    private LinearLayoutManager mLayoutManager; //?
    private Parcelable mEstadoLista;

    private InterfazPeticiones.Servicio servicio;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initVistas();
        obtenerDatos();
    }


    private void initVistas() {
        servicio = InterfazPeticiones.getServicio();
        //Toolbar
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        //Fab
        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CrearModificarActivity.startCreadorForResult(MainActivity.this);
            }
        });

        alumnos = new ArrayList<>();
        lstAlumnos = (RecyclerView) findViewById(R.id.lstAlumnos);
        lstAlumnos.setHasFixedSize(true);
        mAdaptador = new AlumnosAdapter(alumnos);
        mAdaptador.setOnItemClickListener(this);
        mAdaptador.setOnItemLongClickListener(this);
        lstAlumnos.setAdapter(mAdaptador);
        mLayoutManager = new LinearLayoutManager(this,LinearLayoutManager.VERTICAL, false);
        lstAlumnos.setLayoutManager(mLayoutManager);
        lstAlumnos.setItemAnimator(new DefaultItemAnimator());
    }

    private void obtenerDatos() {

        Call<List<Alumno>> llamada = servicio.listarAlumnos();
        llamada.enqueue(new Callback<List<Alumno>>() {
            @Override
            public void onResponse(Response<List<Alumno>> response) {
                mAdaptador.addItems(response.body());
            }

            @Override
            public void onFailure(Throwable t) {
                mAdaptador.addItem(new Alumno("Error. no se pudo connectar " + t.getMessage()));
            }
        });
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        return id == R.id.action_settings || super.onOptionsItemSelected(item);
    }

    @Override
    public void onItemClick(View view, Alumno alumno, int position) {
        CrearModificarActivity.startEditorForResult(this, alumno);
    }

    @Override
    public void onItemLongClick(View view, Alumno alumno, int position) {
        eliminarAlumno(alumno, position);

    }


    private void eliminarAlumno(final Alumno alumno, final int position){
        InterfazPeticiones.getServicio().borrarAlumno(alumno.getId()).enqueue(new Callback<Alumno>() {
            @Override
            public void onResponse(Response<Alumno> response) {
                Toast.makeText(MainActivity.this, "Error: El alumno no ha podido ser creado.", Toast.LENGTH_LONG).show();
                mAdaptador.removeItem(position);
            }

            @Override
            public void onFailure(Throwable t) {
                Toast.makeText(MainActivity.this, "Error: El alumno no ha podido ser creado.", Toast.LENGTH_LONG).show();
            }
        });

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if(resultCode == RESULT_OK){
            switch (requestCode){
                case CrearModificarActivity.MODO_CREAR:
                    //Se introduce a través del adaptador, el alumno creado en la actividad de creación.
                    mAdaptador.addItem((Alumno) data.getParcelableExtra(CrearModificarActivity.INTENT_ALUMNO_CREADO));
                    break;
                case CrearModificarActivity.MODO_EDICION:
                    Alumno alumno = data.getParcelableExtra(CrearModificarActivity.INTENT_ALUMNO_EDITADO);
                    mAdaptador.updateItem(alumno.getId(), alumno);
                    break;
            }
        }
        super.onActivityResult(requestCode, resultCode, data);
    }
}
