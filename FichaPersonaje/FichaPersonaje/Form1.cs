using FichaPersonaje.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichaPersonaje
{
    public partial class FichaPersonaje : Form
    {
        Boolean[] clickeado = new Boolean[4]; //Indices: 0 = bk | 1 = dw | 2 = elf | 3 = dl
        Boolean[] btnclickeado = new Boolean[3]; //Indices: 0 = basic | 1 = caract | 2 = equip
        private int MAX_PUNTOS_CONT = 5000;//Constante con el maximo de puntos disponibles para las caracteristicas
        int[] listaValoresCaract = new int[4]; //aqui se guardan los puntos de las 4 caracteristicas
        List<Label> listaST; //Lista de los campos del Skill Tree
        public String[] lines;
        Album album;
        Personaje pj; //personaje actual que contiene la informacion mostrada en el formulario
        int contadorPj;
        Boolean modificador;

        public FichaPersonaje()
        {
            InitializeComponent();
        }

        private void initClickeado()
        {
            for (int i = 0; i < clickeado.Length; i++)
            {
                clickeado[i] = false;
            }
        }

        private void FichaPersonaje_Load(object sender, EventArgs e)
        {
            //Codigo que pone el doublebuffered a true en los elementos que se indiquen. 
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelUno, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelDos, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelTres, new object[] { true });
            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pictureBox1, new object[] { true });
            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pictureBox2, new object[] { true });
            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pbImagenArma, new object[] { true });
            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pbItem1, new object[] { true });

            //Inicializamos el album de pj
            album = new Album();

            //Inicializamos los booleans de clickeados. Controlan si una clase esta clickeada o no
            initClickeado();
            contadorPj = 0;
            modificador = false;
            for (int i = 0; i < btnclickeado.Length; i++)
            {
                if (i == 0)
                {
                    btnclickeado[i] = true;
                }
                else
                {
                    btnclickeado[i] = false;
                }
            }
            //Inicializamos el uptodown
            inicioUptoDown();

            //Inicializamos array de valores de estadisticas a 0
            for (int i = 0; i < listaValoresCaract.Length; i++)
            {
                listaValoresCaract[i] = 0;
            }
            //Comprobamos la activacion del boton editar
            activarDesactivarEditar();
        }


        

        private void imgBk_Click(object sender, EventArgs e)
        {
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            imgBk.Image = Resources.clbk3;
            clickeado[0] = true;
            imagPerfil.Image = Resources.bk1;
            //Activo los tipos de armas pertenecientes al blade knight
            TipoArma(0);
        }

        private void imgDW_Click(object sender, EventArgs e)
        {
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            imgDW.Image = Resources.cldw1;
            clickeado[1] = true;
            imagPerfil.Image = Resources.dw;
            //Activo los tipos de armas pertenecientes al dark wizard
            TipoArma(1);
        }

        private void imgElf_Click(object sender, EventArgs e)
        {
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            imgElf.Image = Resources.clelf1;
            clickeado[2] = true;
            imagPerfil.Image = Resources.elf;
            //Activo los tipos de armas pertenecientes al elf
            TipoArma(2);
        }

        private void imgDL_Click(object sender, EventArgs e)
        {
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            imgDL.Image = Resources.cldl1;
            clickeado[3] = true;
            imagPerfil.Image = Resources.dl;
            //Activo los tipos de armas pertenecientes al dark lord
            TipoArma(3);
        }

        //Metodo para desactivar resto de imagenes segun el que se haga click
        private void desactivarImagen()
        {
            for (int i = 0; i < clickeado.Length; i++)
            {
                if (clickeado[i] == true)
                {
                    switch (i)
                    {
                        case 0:
                            imgBk.Image = Resources.clbkdesact1;
                            break;
                        case 1:
                            imgDW.Image = Resources.cldwdesact1;
                            break;
                        case 2:
                            imgElf.Image = Resources.clelfdesact1;
                            break;
                        case 3:
                            imgDL.Image = Resources.cldldesact1;
                            break;
                            
                    }
                    clickeado[i] = false;
                   
                }
            }
        }
        

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            for(int i = 0; i<clickeado.Length; i++)
            {
                clickeado[i] = false;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    imgBk.Enabled = true;
                    imgDW.Enabled = true;
                    imgElf.Enabled = false;
                    imgDL.Enabled = false;
                    imgBk.Image = Resources.clbkdesact1;
                    imgDW.Image = Resources.cldwdesact1;
                    imgElf.Image = Resources.clelfproh1;
                    imgDL.Image = Resources.cldlproh1;
                    break;
                case 1:
                    imgBk.Enabled = false;
                    imgDW.Enabled = false;
                    imgElf.Enabled = true;
                    imgDL.Enabled = false;
                    imgElf.Image = Resources.clelfdesact1;
                    imgBk.Image = Resources.clbkproh1;
                    imgDW.Image = Resources.cldwproh1;
                    imgDL.Image = Resources.cldlproh1;
                    break;
                case 2:
                    imgBk.Enabled = false;
                    imgDW.Enabled = false;
                    imgElf.Enabled = false;
                    imgDL.Enabled = true;
                    imgDL.Image = Resources.cldldesact1;
                    imgBk.Image = Resources.clbkproh1;
                    imgDW.Image = Resources.cldwproh1;
                    imgElf.Image = Resources.clelfproh1;
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Image = Resources.btnAct1;
            btn2.Image = Resources.btnDesact1;
            btn3.Image = Resources.btnDesact1;
            panelUno.Visible = true;
            panelDos.Visible = false;
            panelTres.Visible = false;
            btnclickeado[0] = true;
            btnclickeado[1] = false;
            btnclickeado[2] = false;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.Image = Resources.btnAct1;
            btn1.Image = Resources.btnDesact1;
            btn3.Image = Resources.btnDesact1;
            panelUno.Visible = false;
            panelDos.Visible = true;
            panelTres.Visible = false;
            btnclickeado[0] = false;
            btnclickeado[1] = true;
            btnclickeado[2] = false;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.Image = Resources.btnAct1;
            btn1.Image = Resources.btnDesact1;
            btn2.Image = Resources.btnDesact1;
            panelUno.Visible = false;
            panelDos.Visible = false;
            panelTres.Visible = true;
            btnclickeado[0] = false;
            btnclickeado[2] = true;
            btnclickeado[1] = false;
        }

        private void inicioUptoDown()
        {
            UDFuerza.ReadOnly = true;
            UDAgilidad.ReadOnly = true;
            UDVitalidad.ReadOnly = true;
            UDEnergia.ReadOnly = true;

            //Creo un arrayList de 5000 numeros y se los asigno a los uptodown
            ArrayList listNum = new ArrayList();
            UDFuerza.Items.Clear();
            UDAgilidad.Items.Clear();
            UDVitalidad.Items.Clear();
            UDEnergia.Items.Clear();
            for (int i = MAX_PUNTOS_CONT; i >=0; i=i-100)
            {
                listNum.Add(i);
            }
            UDFuerza.Items.AddRange(listNum);
            UDFuerza.SelectedIndex = MAX_PUNTOS_CONT/100; //mueve el indice al 0 (ultimo numero añadido)
            UDAgilidad.Items.AddRange(listNum);
            UDAgilidad.SelectedIndex = MAX_PUNTOS_CONT/100;
            UDVitalidad.Items.AddRange(listNum);
            UDVitalidad.SelectedIndex = MAX_PUNTOS_CONT/100;
            UDEnergia.Items.AddRange(listNum);
            UDEnergia.SelectedIndex = MAX_PUNTOS_CONT/100;
            tvContadorPuntos.Text = ""+MAX_PUNTOS_CONT;
            PBFuerza.Maximum = MAX_PUNTOS_CONT;//Cambio el maximo de puntos de la progressbar
            PBAgilidad.Maximum = MAX_PUNTOS_CONT;
            PBVitalidad.Maximum = MAX_PUNTOS_CONT;
            PBEnergia.Maximum = MAX_PUNTOS_CONT;
        }

        private void UDFuerza_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDFuerza, 0, PBFuerza);
        }

        private void UDAgilidad_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDAgilidad, 1, PBAgilidad);
        }

        private void UDVitalidad_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDVitalidad, 2, PBVitalidad);
        }

        private void UDEnergia_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDEnergia, 3, PBEnergia);
        }

        private void calcularValor(DomainUpDown udCaract, int indice, ProgressBar pbCaract)
        {
            int valorprevio = 0;
            int valor = 0;
           
            for(int i=0; i<listaValoresCaract.Length; i++) //sumamos todos los valores de las caracteristicas menos del que ha llamado al metodo
            {
                if(i!=indice)
                    valorprevio = valorprevio + listaValoresCaract[i];
            }
            if(valorprevio + Int32.Parse(udCaract.Text) <= MAX_PUNTOS_CONT)//si el valor previo + el nuevo numero <= maximo de puntos, seguira, sino no le dejara
            {
                listaValoresCaract[indice] = Int32.Parse(udCaract.Text);//le pasa a la lista que guarda los puntos de cada caracteristica por separado el valor
                for (int i = 0; i < listaValoresCaract.Length; i++) // saca la suma, pero ya con el valor introducido
                {
                    valor = valor + listaValoresCaract[i];
                }
                tvContadorPuntos.Text = "" + (MAX_PUNTOS_CONT - valor); //Se le resta al contador principal(5000) la suma de los 4 caract
                pbCaract.Value = listaValoresCaract[indice]; //se mueve la progressbar
            }
            else
            {
                udCaract.SelectedItem = listaValoresCaract[indice]; //si el valor nuevo + los anteriores sobrepasan 5000, vuelve al valor anterior
            }

        }

        private void TipoArma(int v)
        {
            //reinicio la lista del combobox y el texto
            cbTipoArma.Items.Clear();
            cbTipoArma.Text = "   Tipo de Arma";
            cbArma.Items.Clear();
            cbArma.Text = "          Arma";
            pbImagenArma.Image = Resources.defectoarma;
            switch (v)
            {
                case 0://bk
                    cbTipoArma.Items.Add("Espadas");
                    cbTipoArma.Items.Add("Lanzas");
                    break;
                case 1://dw
                    cbTipoArma.Items.Add("Varas");
                    cbTipoArma.Items.Add("Bastones");
                    break;
                case 2://elf
                    cbTipoArma.Items.Add("Arcos");
                    break;
                case 3://dl
                    cbTipoArma.Items.Add("Cetros");
                    cbTipoArma.Items.Add("Bastones");
                    break;
            }
        }

        private void cbTipoArma_SelectedValueChanged(object sender, EventArgs e)
        {
            //Limpio la lista de armas
            cbArma.Items.Clear();
            cbArma.Text = "          Arma";
            pbImagenArma.Image = Resources.defectoarma;
            //Segun el tipo de armas, añado al combobox unas armas u otras
            switch (cbTipoArma.Text)
            {
                case "Espadas":
                    cbArma.Items.Add("Bone Blade");
                    cbArma.Items.Add("Breaker Sword");
                    cbArma.Items.Add("Flame Sword");
                    break;
                case "Lanzas":
                    cbArma.Items.Add("Dragon Spear");
                    cbArma.Items.Add("Beuroba Spear");
                    break;
                case "Varas":
                    cbArma.Items.Add("Platina Staff");
                    cbArma.Items.Add("Imperial Staff");
                    break;
                case "Bastones":
                    cbArma.Items.Add("Mystery Stick");
                    cbArma.Items.Add("Violent Stick");
                    break;
                case "Arcos":
                    cbArma.Items.Add("Stinger Bow");
                    cbArma.Items.Add("Sylph Bow");
                    cbArma.Items.Add("Vyper Bow");
                    break;
                case "Cetros":
                    cbArma.Items.Add("King Scepter");
                    cbArma.Items.Add("Shining Scepter");
                    break;
            }
        }

        private void cbArma_SelectedValueChanged(object sender, EventArgs e)
        {
            //Cambio la imagen segun el arma seleccionada
            pbImagenArma.Image = Resources.defectoarma;
            switch (cbArma.Text)
            {
                case "Bone Blade":
                    pbImagenArma.Image = Resources.espada1boneblade;
                    break;
                case "Breaker Sword":
                    pbImagenArma.Image = Resources.espada2breakerblade;
                    break;
                case "Flame Sword":
                    pbImagenArma.Image = Resources.espada3flamesword;
                    break;
                case "Dragon Spear":
                    pbImagenArma.Image = Resources.lanza1dragonspear;
                    break;
                case "Beuroba Spear":
                    pbImagenArma.Image = Resources.lanza2beurobaspear;
                    break;
                case "Platina Staff":
                    pbImagenArma.Image = Resources.vara1platinastaff;
                    break;
                case "Imperial Staff":
                    pbImagenArma.Image = Resources.vara2imperialstaff;
                    break;
                case "Mystery Stick":
                    pbImagenArma.Image = Resources.baston1mysterystick;
                    break;
                case "Violent Stick":
                    pbImagenArma.Image = Resources.baston2violentstick;
                    break;
                case "Stinger Bow":
                    pbImagenArma.Image = Resources.arco1stingerbow;
                    break;
                case "Sylph Bow":
                    pbImagenArma.Image = Resources.arco2sylphbow;
                    break;
                case "Vyper Bow":
                    pbImagenArma.Image = Resources.arco3vyperbow;
                    break;
                case "King Scepter":
                    pbImagenArma.Image = Resources.cetro2kingscepter;
                    break;
                case "Shining Scepter":
                    pbImagenArma.Image = Resources.cetro1shiningscepter;
                    break;
            }
        }
        
        //Si se activa/desactiva se resta/suma 500 puntos al total.
        private void ckbItem1_CheckStateChanged(object sender, EventArgs e)
        {
            if(ckbItem1.CheckState == CheckState.Checked){
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT - 500;
                inicioUptoDown();
            }
            else
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT + 500;
                inicioUptoDown();
            }
        }

        private void ckbItem2_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbItem2.CheckState == CheckState.Checked)
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT - 500;
                inicioUptoDown();
            }
            else
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT + 500;
                inicioUptoDown();
            }
        }

        private void ckbItem3_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbItem3.CheckState == CheckState.Checked)
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT - 500;
                inicioUptoDown();
            }
            else
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT + 500;
                inicioUptoDown();
            }
        }

        private void ckbItem4_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbItem4.CheckState == CheckState.Checked)
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT - 500;
                inicioUptoDown();
            }
            else
            {
                MAX_PUNTOS_CONT = MAX_PUNTOS_CONT + 500;
                inicioUptoDown();
            }
        }



        private void btnTirar_Click(object sender, EventArgs e)
        {
            //Disminuimos en 1 la tirada, reiniciamos los campos del SkillTree y generamos unos nuevos valores
            if (Int32.Parse(tvNumTiradas.Text) > 0)
            {
                tvNumTiradas.Text = "" + (Int32.Parse(tvNumTiradas.Text) - 1);
                iniciarCamposTreeSkill();
                generarTreeSkill();
                habilitar();
            }
            else
            {
                btnTirar.Enabled = false; //si se queda sin tiradas se deshabilita el boton
            }
        }

        private void habilitar()
        {
            //Activo todos los labels de la lista de skills del arbol
           foreach(Label l in listaST)
            {
                l.Enabled = true;
            }
        }

        private void generarTreeSkill()
        {
            //Codigo que va generando aleatoriamente, en 3 tiradas, los valores (de 0 a 5) de un TreeSkill
            //De manera que para llegar a un nivel superior en el arbol, uno de los valores anteriores
            //Tiene que llegar a 5 puntos. El arbol tiene 55 puntos totales y 28 puntos a repartir.
            Random rnd = new Random();
            int cont=0;
            int aleat;

            while (cont < 28)
            {
                //Genero Aleatorio
                aleat = rnd.Next(11);
                //Habilito los dos primeros campos.
                if (cont == 0)
                {
                    listaST[0].Enabled = true;
                    listaST[1].Enabled = true;
                }

                //Primer bloque
                if (aleat == 0 || aleat == 2 || aleat == 3 || aleat == 6 || aleat == 7)
                {
                    if (aleat == 0 && listaST[aleat].Enabled == true)
                    {
                        listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                        cont++;
                        if (listaST[aleat].Text == "5")//si llega a 5 se desactiva y activa a los siguientes
                        {
                            listaST[aleat].Enabled = false;
                            listaST[2].Enabled = true;
                            listaST[3].Enabled = true;
                        }
                    }
                    else if (aleat == 2 || aleat == 3 || aleat == 6 || aleat == 7)
                    {
                        if ((aleat == 2 || aleat == 3) && listaST[aleat].Enabled == true)
                        {
                            listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                            cont++;
                            if (listaST[aleat].Text == "5")
                            {
                                listaST[aleat].Enabled = false;
                                listaST[6].Enabled = true;
                                listaST[7].Enabled = true;
                            }
                        }
                        else if ((aleat == 6 || aleat == 7) && listaST[aleat].Enabled == true)
                        {
                            listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                            cont++;
                            if (listaST[aleat].Text == "5")
                            {
                                listaST[aleat].Enabled = false;
                                listaST[10].Enabled = true;
                            }
                        }
                    }
                }
                //Segundo bloque
                else if (aleat == 1 || aleat == 4 || aleat == 5 || aleat == 8 || aleat == 9)
                {
                    if (aleat == 1 && listaST[aleat].Enabled == true)
                    {
                        listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                        cont++;
                        if (listaST[aleat].Text == "5")
                        {
                            listaST[aleat].Enabled = false;
                            listaST[4].Enabled = true;
                            listaST[5].Enabled = true;
                        }
                    }
                    else if (aleat == 4 || aleat == 5 || aleat == 8 || aleat == 9)
                    {
                        if ((aleat == 4 || aleat == 5) && listaST[aleat].Enabled == true)
                        {
                            listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                            cont++;
                            if (listaST[aleat].Text == "5")
                            {
                                listaST[aleat].Enabled = false;
                                listaST[8].Enabled = true;
                                listaST[9].Enabled = true;
                            }
                        }
                        else if ((aleat == 8 || aleat == 9) && listaST[aleat].Enabled == true)
                        {
                            listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                            cont++;
                            if (listaST[aleat].Text == "5")
                            {
                                listaST[aleat].Enabled = false;
                                listaST[10].Enabled = true;
                            }
                        }
                    }
                }
                else //Para la ultima skill(10) que se puede llegar desde ambos bloques
                {
                    if(aleat == 10 && listaST[aleat].Enabled == true)
                    {
                        listaST[aleat].Text = "" + (Int32.Parse(listaST[aleat].Text) + 1);
                        cont++;
                        if (listaST[aleat].Text == "5")
                        {
                            listaST[aleat].Enabled = false;
                        }
                    }
                }
            }

        }


        private void iniciarCamposTreeSkill()
        {
            //Creamos los campos y los inicializamos a false
            listaST = new List<Label>();
            listaST.Add(tvST1);
            listaST.Add(tvST6);
            listaST.Add(tvST2);
            listaST.Add(tvST3);
            listaST.Add(tvST7);
            listaST.Add(tvST8);
            listaST.Add(tvST4);
            listaST.Add(tvST5);
            listaST.Add(tvST9);
            listaST.Add(tvST10);
            listaST.Add(tvST11); 
            
            foreach(Label l in listaST)
            {
                l.Text = "0";
                l.Enabled = false;
            }   
        }


        private void imgGuardar_MouseClick(object sender, MouseEventArgs e)
        {
            //Al hacer click en guardar primero comprueba que todos los campos sean correctos y luego guarda
            //el personaje en array de string
            if (!comprobacion())
            {
                tvErrorEdicion.Visible = true;
            }
            else
            {
                tvErrorEdicion.Visible = false;
                guardarPj();
            }
        }

        private bool comprobacion()
        {
            Boolean result = true;
            //Comprueba que todos los campos son correctos
            //NombrePJ
            if (etNombrePJ.Text == "")
            {
                result = false;
                tvErrorEdicion.Text = "Error: Nombre de PJ debe ser rellenado";
            }
            else
            {//comprueba que ningun pj tenga el mismo nombre
                foreach(Personaje p in album.listPj)
                {
                    if(p.nombrePJ == etNombrePJ.Text && p != pj) //si coincide el nombre pero el pj no es el actual
                    {
                        result = false;
                        tvErrorEdicion.Text = "Error: Nombre de PJ ya existente en album";
                    }
                }
            }

            //NombreJug
            if(etNombreJug.Text == "")
            {
                result = false;
                tvErrorEdicion.Text = "Error: Nombre de Jugador debe ser rellenado";
            }
          
            //Faccion
            if(rbDuprian.Checked == false && rbVanert.Checked == false)
            {
                result = false;
                tvErrorEdicion.Text = "Error: Faccion debe ser elegida";
            }

            //MapaInicio
            if (comboBox1.SelectedItem == null)
            {
                result = false;
                tvErrorEdicion.Text = "Error: Mapa Inicio debe ser elegido";
            }

            //Clase
            if (clickeado[0] == false && clickeado[1] == false && clickeado[2] == false && clickeado[3]==false)
            {
                result = false;
                tvErrorEdicion.Text = "Error: La Clase debe ser elegida";
            }

            //Puntos
            if(tvContadorPuntos.Text != "0")
            {
                result = false;
                tvErrorEdicion.Text = "Error: Deben introducirse todos los Puntos de caracteristicas";
            }
            
            //Armas
            if(cbArma.SelectedItem == null)
            {
                result = false;
                tvErrorEdicion.Text = "Error: El arma debe ser elegida";
            }

            //TreeSkill
            if(tvST1.Enabled == false)
            {
                result = false;
                tvErrorEdicion.Text = "Error: Debe lanzarse el TreeSkill 1 vez al menos";
            }

            return result;
        }

       

        private void modoVisualizacion()
        {
            //Aumenta el tamaño de la ventana y oculta los botones guardar y cancelar
            imagMenuInf.Visible = true;
            this.Size = new Size(700, 653);
            imagCancelar.Visible = false;
            imgGuardar.Visible = false;
            //Desactivar la modificacion del personaje
            desactivarEdicion();
        }

        private void modoEdicion()
        {
            //Aumenta el tamaño de la ventana y oculta los botones guardar y cancelar
            imagMenuInf.Visible = false;
            this.Size = new Size(700, 600);
            imagCancelar.Visible = true;
            imgGuardar.Visible = true;
            //activar todos los campos
            activarEdicion();
        }

        private void imagCancelar_Click(object sender, EventArgs e)
        {
            //Resetear todas las opciones
            resetearCampos();
            //Cambia al modo visualizacion    
            modoVisualizacion();
            //Si el contador es distinto de 0, le resto 1
            if (contadorPj != 0)
                contadorPj--;
            //cargar pj
            cargarPJ();
        }

        private void imagNuevo_Click(object sender, EventArgs e)
        {
            //pasar al modo edicion
            modoEdicion();
            //reiniciar los campos (usando cancelar)
            resetearCampos();
        }

        private void imagAnterior_Click(object sender, EventArgs e)
        {
            contadorPj = album.anteriorPJ(contadorPj);
            cargarPJ();
        }

        private void imagSiguiente_Click(object sender, EventArgs e)
        {
            contadorPj = album.siguientePJ(contadorPj);
            cargarPJ(); //carga ese pj en los campos
            
        }

        private void imagBorrar_Click(object sender, EventArgs e)
        {
            contadorPj = album.eliminarPj(contadorPj, pj);
            cargarPJ(); //carga ese pj en los campos
            activarDesactivarEditar();
        }

        private void activarDesactivarEditar()
        {
            if (album.listPj.Count == 0)
            {
                imagEditar.Enabled = false;
                imagEditar.Image = Resources.editarDesact;
            }
            else
            {
                imagEditar.Enabled = true;
                imagEditar.Image = Resources.editarAct;
            }
        }

        private void imagEditar_Click(object sender, EventArgs e)
        {
            //lo pone en modo edicion, habilitando los campos pero no reseteandolos
             modoEdicion();
             modificador = true;

        }

        private void guardarPj()
        {

            lines = new String[10];
            //Introduccion de atributos en array de String
            //nombrePJ
            lines[0] = etNombrePJ.Text;
            //nombreJug
            lines[1] = etNombreJug.Text;
            //faccion
            if (rbDuprian.Checked == true)
                lines[2] = "duprian";
            else
                lines[2] = "vanert";
            //mapa inicio
            lines[3] = "" + comboBox1.SelectedItem;
            //clase
            if (clickeado[0] == true)
            {
                lines[4] = "0";
            }
            else if (clickeado[1] == true)
            {
                lines[4] = "1";
            }
            else if (clickeado[2] == true)
            {
                lines[4] = "2";
            }
            else if (clickeado[3] == true)
            {
                lines[4] = "3";
            }
            //puntos  
            lines[5] = UDFuerza.SelectedItem + ":" + UDAgilidad.SelectedItem + ":" + UDVitalidad.SelectedItem + ":" + UDEnergia.SelectedItem;
            //tipo de arma
            lines[6] = "" + cbTipoArma.SelectedItem;
            //arma
            lines[7] = "" + cbArma.SelectedItem;
            //inventario
            if (ckbItem1.Checked == true)
                lines[8] = "1";
            else
                lines[8] = "0";
            //inventario 2
            if (ckbItem2.Checked == true)
                lines[8] = lines[8] + ":1";
            else
                lines[8] = lines[8] + ":0";
            //inventario 3
            if (ckbItem3.Checked == true)
                lines[8] = lines[8] + ":1";
            else
                lines[8] = lines[8] + ":0";
            //inventario 4
            if (ckbItem4.Checked == true)
                lines[8] = lines[8] + ":1";
            else
                lines[8] = lines[8] + ":0";

            //treeskill
            lines[9] = tvST1.Text + ":" + tvST2.Text + ":" + tvST3.Text + ":" + tvST4.Text + ":" + tvST5.Text + ":" + tvST6.Text + ":" + tvST7.Text + ":" + tvST8.Text + ":" + tvST9.Text + ":" + tvST10.Text + ":" + tvST11.Text;

            

            if(modificador == false) {
                pj = new Personaje(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7], lines[8], lines[9]);
                //Se añade al album
                album.guardarPj(pj);
                //Aumento 1 el contador de pj
                contadorPj++;
            }
            else
            {//se modifica en la posicion determinada
                album.modificarPj(pj, lines);
                modificador = false;
            }
           

            //Cambio  a modo visualizacion
            modoVisualizacion();

            //comprueba la activacion del boton editar
            activarDesactivarEditar();
        }

        private void cargarPJ()
        {
            if (album.listPj.Count > 0)
            {
                pj = (Personaje)album.listPj[contadorPj]; //obtiene el PJ guardado en el album en la posicion indicada en el contador
                                                          //nombrePJ
                etNombrePJ.Text = pj.nombrePJ;
                //nombreJug
                etNombreJug.Text = pj.nombreJug;
                //faccion
                if (pj.faccion == "duprian")
                {
                    rbDuprian.Checked = true;
                    rbVanert.Checked = false;
                }
                else
                {
                    rbVanert.Checked = true;
                    rbDuprian.Checked = false;
                }

                //mapa inicio
                comboBox1.SelectedItem = pj.mapaInicio;
                //clase
                switch (pj.clase)
                {
                    case "0":
                        clickeado[0] = true;
                        imagPerfil.Image = Resources.bk1;
                        TipoArma(0);
                        imgBk.Image = Resources.clbk3;
                        imgDW.Image = Resources.cldwdesact1;
                        imgElf.Image = Resources.clelfproh1;
                        imgDL.Image = Resources.cldlproh1;
                        break;
                    case "1":
                        clickeado[1] = true;
                        imagPerfil.Image = Resources.dw;
                        TipoArma(1);
                        imgDW.Image = Resources.cldw1;
                        imgBk.Image = Resources.clbkdesact1;
                        imgElf.Image = Resources.clelfproh1;
                        imgDL.Image = Resources.cldlproh1;
                        break;
                    case "2":
                        clickeado[2] = true;
                        imagPerfil.Image = Resources.elf;
                        TipoArma(2);
                        imgElf.Image = Resources.clelf1;
                        imgBk.Image = Resources.clbkproh1;
                        imgDW.Image = Resources.cldwproh1;
                        imgDL.Image = Resources.cldlproh1;
                        break;
                    case "3":
                        clickeado[3] = true;
                        imagPerfil.Image = Resources.dl;
                        TipoArma(3);
                        imgDL.Image = Resources.cldl1;
                        imgBk.Image = Resources.clbkproh1;
                        imgDW.Image = Resources.cldwproh1;
                        imgElf.Image = Resources.clelfproh1;
                        break;
                }

                desactivarEdicion();
                tvDescrip.Visible = false;

                //inventario
                String codigoInv = pj.inventario;
                String[] valoresInv = codigoInv.Split(':');
                if (valoresInv[0] == "1")
                    ckbItem1.Checked = true;
                else
                    ckbItem1.Checked = false;
                //inventario 2
                if (valoresInv[1] == "1")
                    ckbItem2.Checked = true;
                else
                    ckbItem2.Checked = false;
                //inventario 3
                if (valoresInv[2] == "1")
                    ckbItem3.Checked = true;
                else
                    ckbItem3.Checked = false;
                //inventario 4
                if (valoresInv[3] == "1")
                    ckbItem4.Checked = true;
                else
                    ckbItem4.Checked = false;

                //Valores Caract
                String codigoCaract = pj.puntos;
                String[] valoresCaract = codigoCaract.Split(':');
                UDFuerza.SelectedItem = Int32.Parse(valoresCaract[0]);
                UDAgilidad.SelectedItem = Int32.Parse(valoresCaract[1]);
                UDVitalidad.SelectedItem = Int32.Parse(valoresCaract[2]);
                UDEnergia.SelectedItem = Int32.Parse(valoresCaract[3]);


                //tipo de arma
                cbTipoArma.SelectedItem = pj.tipoArma;
                //arma
                cbArma.SelectedItem = pj.arma;

                //SkillTree
                String codigoST = pj.skillTree;
                String[] valoresST = codigoST.Split(':');

                tvST1.Text = valoresST[0];
                tvST2.Text = valoresST[1];
                tvST3.Text = valoresST[2];
                tvST4.Text = valoresST[3];
                tvST5.Text = valoresST[4];
                tvST6.Text = valoresST[5];
                tvST7.Text = valoresST[6];
                tvST8.Text = valoresST[7];
                tvST9.Text = valoresST[8];
                tvST10.Text = valoresST[9];
                tvST11.Text = valoresST[10];
            }
            else
            {
                resetearCampos();
            }
           
        }

        private void resetearCampos()
        {
            //nombrePJ
            etNombrePJ.Text = "";
            //nombreJug
            etNombreJug.Text = "";
            //faccion
            rbDuprian.Checked = false;
            rbVanert.Checked = false;
            //mapa inicio
            comboBox1.SelectedItem = null;
            //clase
            initClickeado();
            //puntos
            inicioUptoDown();
            //tipo de arma
            cbTipoArma.SelectedItem = null;
            //arma
            cbArma.SelectedItem = null;
            //inventario
            ckbItem1.Checked = false;
            ckbItem2.Checked = false;
            ckbItem3.Checked = false;
            ckbItem4.Checked = false;
            //treeskill
            iniciarCamposTreeSkill();
            //tiradas
            tvNumTiradas.Text = "3";
            //imagenes de clase 
            imgBk.Enabled = false;
            imgDW.Enabled = false;
            imgElf.Enabled = false;
            imgDL.Enabled = false;
            imgBk.Image = Resources.clbkproh1;
            imgDW.Image = Resources.cldwproh1;
            imgElf.Image = Resources.clelfproh1;
            imgDL.Image = Resources.cldlproh1;
            imagPerfil.Image = Resources.df;
            TipoArma(4);//desactiva los tipos de arma
        }


        private void desactivarEdicion()
        {
            etNombrePJ.Enabled = false;
            etNombreJug.Enabled = false;
            rbVanert.Enabled = false;
            rbDuprian.Enabled = false;
            comboBox1.Enabled = false;
            imgBk.Enabled = false;
            imgDW.Enabled = false;
            imgElf.Enabled = false;
            imgDL.Enabled = false;
            UDFuerza.Enabled = false;
            UDAgilidad.Enabled = false;
            UDVitalidad.Enabled = false;
            UDEnergia.Enabled = false;
            cbTipoArma.Enabled = false;
            cbArma.Enabled = false;
            ckbItem1.Enabled = false;
            ckbItem2.Enabled = false;
            ckbItem3.Enabled = false;
            ckbItem4.Enabled = false;
            btnTirar.Enabled = false;
        }

        private void activarEdicion()
        {
            //activamos todos los campos
            etNombrePJ.Enabled = true;
            etNombreJug.Enabled = true;
            rbVanert.Enabled = true;
            rbDuprian.Enabled = true;
            comboBox1.Enabled = true;
            UDFuerza.Enabled = true;
            UDAgilidad.Enabled = true;
            UDVitalidad.Enabled = true;
            UDEnergia.Enabled = true;
            cbTipoArma.Enabled = true;
            cbArma.Enabled = true;
            ckbItem1.Enabled = true;
            ckbItem2.Enabled = true;
            ckbItem3.Enabled = true;
            ckbItem4.Enabled = true;
            btnTirar.Enabled = true;
        }

        private void imagExportar_Click(object sender, EventArgs e)
        {
            //exportar
            String line;
            String[] aux;
            String[] separador = { "¡-:*!" };
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FichaPersonaje\\SavePJ.fpj"))
            {
                StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FichaPersonaje\\SavePJ.fpj");
                album = new Album();
                while ((line = sr.ReadLine()) != null)
                {
                    aux = line.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                    album.listPj.Add(new Personaje(aux[0], aux[1], aux[2], aux[3], aux[4], aux[5], aux[6], aux[7], aux[8], aux[9]));
                }
                contadorPj = 0;
                cargarPJ();
                sr.Close();
                activarDesactivarEditar();
                activarTreeSkill();
            }

        }

        private void imagImportar_Click(object sender, EventArgs e)
        {
            //Importar
            //StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\SavePJ.fpj");
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FichaPersonaje"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FichaPersonaje");
            }
            StreamWriter file = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FichaPersonaje\\SavePJ.fpj");
            foreach (Personaje pj in album.listPj)
            {
                file.WriteLine(pj.ToString());
            }
            file.Close();
        }

        private void activarTreeSkill()
        {
            tvST1.Enabled = true;
            tvST2.Enabled = true;
            tvST3.Enabled = true;
            tvST4.Enabled = true;
            tvST5.Enabled = true;
            tvST6.Enabled = true;
            tvST7.Enabled = true;
            tvST8.Enabled = true;
            tvST9.Enabled = true;
            tvST10.Enabled = true;
            tvST11.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void imgBk_MouseHover(object sender, EventArgs e)
        {

            imgBk.Image = Resources.clbk3;
            tvDescrip.Text = "Clase enfocada al cuerpo a cuerpo a corta distancia.";
            tvDescrip.Visible = true;
        }


        private void imgBk_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[0] == false)
            {
                imgBk.Image = Resources.clbkdesact1;
                tvDescrip.Visible = false;
            }

        }

        private void imgDW_MouseHover(object sender, EventArgs e)
        {
            imgDW.Image = Resources.cldw1;
            tvDescrip.Text = "Clase enfocada al ataque a largas distancias con hechizos.";
            tvDescrip.Visible = true;
        }

        private void imgDW_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[1] == false)
            {
                imgDW.Image = Resources.cldwdesact1;
                tvDescrip.Visible = false;
            }
        }

        private void imgElf_MouseHover(object sender, EventArgs e)
        {
            imgElf.Image = Resources.clelf1;
            tvDescrip.Text = "Clase enfocada a largas distancias con arco y flechas";
            tvDescrip.Visible = true;
        }

        private void imgElf_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[2] == false)
            {
                imgElf.Image = Resources.clelfdesact1;
                tvDescrip.Visible = false;
            }
        }

        private void imgDL_MouseHover(object sender, EventArgs e)
        {
            imgDL.Image = Resources.cldl1;
            tvDescrip.Text = "Clase enfocada a largas distancias a personajes individuales";
            tvDescrip.Visible = true;
        }

        private void imgDL_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[3] == false)
            {
                imgDL.Image = Resources.cldldesact1;
                tvDescrip.Visible = false;
            }
        }


        private void btn1_MouseHover(object sender, EventArgs e)
        {
            btn1.Image = Resources.btnAct1;
        }

        private void btn2_MouseHover(object sender, EventArgs e)
        {
            btn2.Image = Resources.btnAct1;
        }

        private void btn3_MouseHover(object sender, EventArgs e)
        {
            btn3.Image = Resources.btnAct1;
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            if (btnclickeado[0] == false)
                btn1.Image = Resources.btnDesact1;
        }

        private void btn2_MouseLeave(object sender, EventArgs e)
        {
            if (btnclickeado[1] == false)
                btn2.Image = Resources.btnDesact1;
        }

        private void btn3_MouseLeave(object sender, EventArgs e)
        {
            if (btnclickeado[2] == false)
                btn3.Image = Resources.btnDesact1;
        }

        private void btnTirar_MouseHover(object sender, EventArgs e)
        {
            btnTirar.Image = Resources.stbtnAct_5; //boton Tirar encendido
        }

        private void btnTirar_MouseLeave(object sender, EventArgs e)
        {
            btnTirar.Image = Resources.stbtnDesact; //Boton Tirar apagado
        }

        private void imgGuardar_MouseHover(object sender, EventArgs e)
        {
            imgGuardar.Image = Resources.btn_GuardarDesact; //Boton guardar apagado
        }

        private void imgGuardar_MouseLeave(object sender, EventArgs e)
        {
            imgGuardar.Image = Resources.btn_GuardarAct;//Boton guardar encendido
        }

        private void imagCancelar_MouseHover(object sender, EventArgs e)
        {
            imagCancelar.Image = Resources.btn_CancelarDesact; //boton cancelar apagado
        }

        private void imagCancelar_MouseLeave(object sender, EventArgs e)
        {
            imagCancelar.Image = Resources.btn_CancelarAct; //boton cancelar encendido
        }

        private void imagEditar_MouseHover(object sender, EventArgs e)
        {
            imagEditar.Image = Resources.editarDesact;
        }

        private void imagEditar_MouseLeave(object sender, EventArgs e)
        {
            imagEditar.Image = Resources.editarAct;
        }

        private void imagNuevo_MouseHover(object sender, EventArgs e)
        {
            imagNuevo.Image = Resources.nuevoDesact;
        }

        private void imagNuevo_MouseLeave(object sender, EventArgs e)
        {
            imagNuevo.Image = Resources.nuevoAct1;
        }

        private void imagBorrar_MouseHover(object sender, EventArgs e)
        {
            imagBorrar.Image = Resources.borrarDesact;
        }

        private void imagBorrar_MouseLeave(object sender, EventArgs e)
        {
            imagBorrar.Image = Resources.borrarAct;
        }

        private void cbTipoArma_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //Desactiva el combobox tipo arma sin perder la funcionalidad
        }

        private void cbArma_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //Desactiva el combobox arma sin perder la funcionalidad
        }

        private void imagImportar_MouseHover(object sender, EventArgs e)
        {
            imagExportar.Image = Resources.exportarDesact;
        }

        private void imagImportar_MouseLeave(object sender, EventArgs e)
        {
            imagExportar.Image = Resources.exportarAct;
        }

        private void imagExportar_MouseHover(object sender, EventArgs e)
        {
            imagImportar.Image = Resources.importarDesact;
        }

        private void imagExportar_MouseLeave(object sender, EventArgs e)
        {
            imagImportar.Image = Resources.importarAct;
        }

        
    }

}