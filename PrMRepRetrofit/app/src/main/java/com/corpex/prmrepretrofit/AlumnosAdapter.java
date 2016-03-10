package com.corpex.prmrepretrofit;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 * Created by corpex, by the Grace of God on 29/02/2016.
 */
public class AlumnosAdapter extends RecyclerView.Adapter<AlumnosAdapter.ViewHolder>{
    private OnItemLongClickListener onItemLongClickListener;
    private OnItemClickListener onItemClickListener;
    private final ArrayList<Alumno> mDatos;
    private View emptyView;






    // Constructor.
    public AlumnosAdapter(ArrayList<Alumno> datos) {
        mDatos = datos;
    }






    //Creacion de nueva vista por item
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        // Se infla la especificación XML para obtener la vista-fila.
        View itemView = LayoutInflater.from(parent.getContext()).inflate(R.layout.content_main_item, parent, false);
        // Se crea el contenedor de vistas para la fila.
        final ViewHolder viewHolder = new ViewHolder(itemView);

        // Se establecen los listener de la vista correspondiente al ítem
        // y de las subvistas.

        // Cuando se hace click sobre el elemento.
        itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (onItemClickListener != null) {
                    // Se informa al listener.
                    onItemClickListener.onItemClick(v,
                            mDatos.get(viewHolder.getAdapterPosition()),
                            viewHolder.getAdapterPosition());
                }
            }
        });
        // Cuando se hace click largo sobre el elemento.
        itemView.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                if (onItemLongClickListener != null) {
                    // Se informa al listener.
                    onItemLongClickListener.onItemLongClick(v,
                            mDatos.get(viewHolder.getAdapterPosition()),
                            viewHolder.getAdapterPosition());
                    return true;
                } else {
                    return false;
                }
            }
        });
        // Se retorna el contenedor.
        return viewHolder;
    }







    //Escribir los datos de la vista en el item correspondiente
    @Override
    public void onBindViewHolder(AlumnosAdapter.ViewHolder holder, int position) {
        // Se obtiene el alumno correspondiente.
        Alumno alumno = mDatos.get(position);
        // Se escriben los mDatos en la vista.
        holder.lblNombre.setText(alumno.getNombre());
        holder.lblDireccion.setText(alumno.getDireccion());
        Picasso.with(holder.imgAvatar.getContext()).load("http://lorempixel.com/400/200/").into(holder.imgAvatar);

    }







    //Metodos de accion sobre la lista
    public void addItems(List<Alumno> alumnos) {
        mDatos.addAll(alumnos);
        notifyDataSetChanged();
    }

    public void addItem(Alumno alumno) {
        mDatos.add(alumno);
        notifyItemInserted(mDatos.size() - 1);
        checkIfEmpty();
    }

    void swapItems(int from, int to) {
        Collections.swap(mDatos, from, to);
        notifyItemMoved(from, to);
    }

    @Override
    public int getItemCount() {
        return mDatos.size();
    }

    public void removeItem(int position) {
        mDatos.remove(position);
        notifyItemRemoved(position);
        checkIfEmpty();
    }

    public void updateItem(int idAlumno, Alumno newAlumno){
        int index = -1;

        for (Alumno a : mDatos)
            if(a.getId() == idAlumno)
                index = mDatos.indexOf(a);

        //Reemplaza el antiguo alumno por el actualizado.
        mDatos.set(index,newAlumno);
        notifyItemChanged(index);
    }

    public void replaceItems(List<Alumno> alumnos){
        mDatos.clear();
        mDatos.addAll(alumnos);
        notifyDataSetChanged();
    }

    public boolean containsItems(Alumno alumno){
        return mDatos.contains(alumno);
    }

    private void checkIfEmpty() {
        if (emptyView != null) {
            emptyView.setVisibility(getItemCount() > 0 ? View.GONE : View.VISIBLE);
        }
    }







    //Establecer listeners
    public void setOnItemClickListener(OnItemClickListener listener) {
        this.onItemClickListener = listener;
    }

    public void setOnItemLongClickListener(OnItemLongClickListener listener) {
        this.onItemLongClickListener = listener;
    }







    //Interfaces de click en item
    public interface OnItemClickListener {
        void onItemClick(View view, Alumno alumno, int position);
    }

    public interface OnItemLongClickListener {
        void onItemLongClick(View view, Alumno alumno, int position);
    }








    //ViewHolder
    static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView lblNombre;
        private final TextView lblDireccion;
        private final ImageView imgAvatar;

        public ViewHolder(View itemView) {
            super(itemView);
            lblNombre = (TextView) itemView.findViewById(R.id.lblNombre);
            lblDireccion = (TextView) itemView.findViewById(R.id.lblDireccion);
            imgAvatar = (ImageView) itemView.findViewById(R.id.imgAvatar);
        }

    }
}
