using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino
{
    public partial class Juego : Form
    {
        public Juego()
        {
            InitializeComponent();
            label1.Text = nombre2;
            label2.Text = nombre3;
            label3.Text = nombre4;
            iniciarJuego();
        }
        //Datos de cada jugador
        public static Jugador P1;
        public static Jugador P2;
        public static string nombre2 = "Hugo";
        public static Jugador P3;
        public static string nombre3 = "Paco";
        public static Jugador P4;
        public static string nombre4 = "Luis";
        //Jugador dentro del juego
        public static NodoSimple jugador1;
        public static NodoSimple jugador2;
        public static NodoSimple jugador3;
        public static NodoSimple jugador4;
        public static NodoSimple jugadorEnTurno;
        public static LSLC jugadores = new LSLC();
        //Fichas de cada jugador
        public static LSL fichas1;
        public static LSL fichas2;
        public static LSL fichas3;
        public static LSL fichas4;
        public static NodoSimple mano; //Jugador que inicia la ronda
        public static LDL listaFichasMesa; //Lista con las fichas colocadas
        public static bool turnoJugador = false;
        //Números que deben tener las fichas para poder colocarse
        public static int ladoLibreIzquierda = 6;
        public static int ladoLibreDerecha = 6;
        //Coordenadas de las fichas para los picturebox
        public static int coordenadaXFichaDerecha = 610; //529 522
        public static int coordenadaXFichaIzquierda = 575; //495
        public static int coordenadaYFichaIzquierda;
        public static int coordenadaYFichaDerecha;
        //Contadores del número de fichas y turnos pasados
        public static int cantidadFichasDerecha = 0;
        public static int cantidadFichasIzquierda = 0;
        public static int cantidadFichasAbajo = 0;
        public static int cantidadFichasArriba = 0;
        public static int turnosPasados = 0;
        PictureBox imagenAMover = null;
        Ficha fichaSiguiente = null;

        public void iniciarJuego()
        {
            //Se ejecuta cuando se abre el formulario
            P1 = new Jugador("Yo");
            P2 = new Jugador(nombre2);
            P3 = new Jugador(nombre3);
            P4 = new Jugador(nombre4);
            imagenesJ1[0] = pictureJ1;
            imagenesJ1[1] = pictureJ2;
            imagenesJ1[2] = pictureJ3;
            imagenesJ1[3] = pictureJ4;
            imagenesJ1[4] = pictureJ5;
            imagenesJ1[5] = pictureJ6;
            imagenesJ1[6] = pictureJ7;
            imagenesJ2[0] = pictureB1;
            imagenesJ2[1] = pictureB2;
            imagenesJ2[2] = pictureB3;
            imagenesJ2[3] = pictureB4;
            imagenesJ2[4] = pictureB5;
            imagenesJ2[5] = pictureB6;
            imagenesJ2[6] = pictureB7;
            imagenesJ3[0] = pictureC1;
            imagenesJ3[1] = pictureC2;
            imagenesJ3[2] = pictureC3;
            imagenesJ3[3] = pictureC4;
            imagenesJ3[4] = pictureC5;
            imagenesJ3[5] = pictureC6;
            imagenesJ3[6] = pictureC7;
            imagenesJ4[0] = pictureD1;
            imagenesJ4[1] = pictureD2;
            imagenesJ4[2] = pictureD3;
            imagenesJ4[3] = pictureD4;
            imagenesJ4[4] = pictureD5;
            imagenesJ4[5] = pictureD6;
            imagenesJ4[6] = pictureD7;
            //Creación de nodos y asignación LD para los jugadores, luego se reparten las fichas
            jugador1 = new NodoSimple(P1);
            jugador2 = new NodoSimple(P2);
            jugador3 = new NodoSimple(P3);
            jugador4 = new NodoSimple(P4);
            jugadores.conectarAlFinal(jugador1);
            jugadores.conectarAlFinal(jugador2);
            jugadores.conectarAlFinal(jugador3);
            jugadores.conectarAlFinal(jugador4);

            iniciarRonda();
        }

        //Todas las fichas
        public static Ficha ficha1 = new Ficha(0, 0);
        public static Ficha ficha2 = new Ficha(0, 1);
        public static Ficha ficha3 = new Ficha(0, 2);
        public static Ficha ficha4 = new Ficha(0, 3);
        public static Ficha ficha5 = new Ficha(0, 4);
        public static Ficha ficha6 = new Ficha(0, 5);
        public static Ficha ficha7 = new Ficha(0, 6);
        public static Ficha ficha8 = new Ficha(1, 1);
        public static Ficha ficha9 = new Ficha(1, 2);
        public static Ficha ficha10 = new Ficha(1, 3);
        public static Ficha ficha11 = new Ficha(1, 4);
        public static Ficha ficha12 = new Ficha(1, 5);
        public static Ficha ficha13 = new Ficha(1, 6);
        public static Ficha ficha14 = new Ficha(2, 2);
        public static Ficha ficha15 = new Ficha(2, 3);
        public static Ficha ficha16 = new Ficha(2, 4);
        public static Ficha ficha17 = new Ficha(2, 5);
        public static Ficha ficha18 = new Ficha(2, 6);
        public static Ficha ficha19 = new Ficha(3, 3);
        public static Ficha ficha20 = new Ficha(3, 4);
        public static Ficha ficha21 = new Ficha(3, 5);
        public static Ficha ficha22 = new Ficha(3, 6);
        public static Ficha ficha23 = new Ficha(4, 4);
        public static Ficha ficha24 = new Ficha(4, 5);
        public static Ficha ficha25 = new Ficha(4, 6);
        public static Ficha ficha26 = new Ficha(5, 5);
        public static Ficha ficha27 = new Ficha(5, 6);
        public static Ficha ficha28 = new Ficha(6, 6);
        //Arreglos con los picturebox de cada jugador
        static PictureBox[] imagenesJ1 = new PictureBox[7];
        static PictureBox[] imagenesJ2 = new PictureBox[7];
        static PictureBox[] imagenesJ3 = new PictureBox[7];
        static PictureBox[] imagenesJ4 = new PictureBox[7];
        public void repartirFichas()
        {
            Ficha[] arregloFichas = {ficha1, ficha2, ficha3, ficha4, ficha5, ficha6, ficha7, ficha8, ficha9, ficha10, 
                ficha11, ficha12, ficha13, ficha14, ficha15, ficha16, ficha17, ficha18, ficha19, ficha20, ficha21, ficha22, 
                ficha23, ficha24, ficha25, ficha26, ficha27, ficha28};
            int numeroFicha = 0;
            int posicionXVariante = (this.Width / 2) - 152;
            int POSICION_Y_ABAJO = this.ClientSize.Height - 85;
            int posicionYVariante = (this.Height / 2) - 152;
            int POSICION_X_DERECHA = this.ClientSize.Width - 85;
            int POSICION_Y_ARRIBA = 15;
            int POSICION_X_IZQUIERDA = 15;

            Random aleatorio = new Random();
            //asignación del nodo correspondiente a la ficha y las imágenes en el formulario
            for (int i = 28; i > 0; i--)
            {                
                int posicion = aleatorio.Next(0, i);
                Ficha x = arregloFichas[posicion];
                
                if (i % 4 == 0) //Ficha para el jugador 1 (usuario)
                {
                    x.setPictureReferencia(imagenesJ1[numeroFicha]);
                    fichas1.insertarDato(x, fichas1.ultimoNodo());
                    string numero = "";
                    switch (x.getNum1())//Asignar el nombre del archivo de la imagen
                    {
                        case 0:
                            numero += "0";
                            break;
                        case 1:
                            numero += "1";
                            break;
                        case 2:
                            numero += "2";
                            break;
                        case 3:
                            numero += "3";
                            break;
                        case 4:
                            numero += "4";
                            break;
                        case 5:
                            numero += "5";
                            break;
                        case 6:
                            numero += "6";
                            break;
                    }
                    switch (x.getNum2())
                    {
                        case 0:
                            numero += "0";
                            break;
                        case 1:
                            numero += "1";
                            break;
                        case 2:
                            numero += "2";
                            break;
                        case 3:
                            numero += "3";
                            break;
                        case 4:
                            numero += "4";
                            break;
                        case 5:
                            numero += "5";
                            break;
                        case 6:
                            numero += "6";
                            break;
                    }
                    numero += ".png";

                    //organizacion del picturebox
                    imagenesJ1[numeroFicha].SizeMode = PictureBoxSizeMode.StretchImage;
                    imagenesJ1[numeroFicha].Image = Image.FromFile(numero);
                    imagenesJ1[numeroFicha].Height = 70;
                    imagenesJ1[numeroFicha].Width = 35;
                    imagenesJ1[numeroFicha].Location = new Point(posicionXVariante, POSICION_Y_ABAJO);
                    
                    if (x == ficha28)
                    {
                        mano = jugador1;
                    }
                }else if (i % 4 == 1) //Ficha para el jugador 2
                {
                    fichas2.insertarDato(x, fichas2.ultimoNodo());
                    if (x == ficha28)
                    {
                        mano = jugador2;
                    }
                    //Organización del picturebox
                    imagenesJ2[numeroFicha].Image = Image.FromFile("ParteDeAtras2.png");
                    imagenesJ2[numeroFicha].Height = 35;
                    imagenesJ2[numeroFicha].Width = 70;
                    imagenesJ2[numeroFicha].Location = new Point(POSICION_X_DERECHA, posicionYVariante);

                    numeroFicha++;
                    posicionYVariante += 45;
                }
                else if (i % 4 == 2) //Ficha para el jugador 3
                {
                    fichas3.insertarDato(x, fichas3.ultimoNodo());
                    if (x == ficha28)
                    {
                        mano = jugador3;
                    }
                    //Organizacion del picturebox
                    imagenesJ3[numeroFicha].Image = Image.FromFile("ParteDeAtras.png");
                    imagenesJ3[numeroFicha].Height = 70;
                    imagenesJ3[numeroFicha].Width = 35;
                    imagenesJ3[numeroFicha].Location = new Point(posicionXVariante, POSICION_Y_ARRIBA);

                    posicionXVariante += 45;
                }
                else //Ficha para el jugador 4
                {
                    fichas4.insertarDato(x, fichas4.ultimoNodo());
                    if (x == ficha28)
                    {
                        mano = jugador4;
                    }
                    //Organizacion del picturebox
                    imagenesJ4[numeroFicha].Image = Image.FromFile("ParteDeAtras2.png");
                    imagenesJ4[numeroFicha].Height = 35;
                    imagenesJ4[numeroFicha].Width = 70;
                    imagenesJ4[numeroFicha].Location = new Point(POSICION_X_IZQUIERDA, posicionYVariante);
                    
                }
                //Se pasa la ficha elegida a la posición i-1 para que no pueda ser escogida de nuevo
                Ficha aux = arregloFichas[i - 1];
                arregloFichas[i - 1] = arregloFichas[posicion];
                arregloFichas[posicion] = aux;
            }
        }

        public void iniciarRonda()
        {
            //Se reinician los atributos del juego
            Puntaje.Visible = false;
            botonContinuar.Visible = false;
            fichas1 = new LSL();
            fichas2 = new LSL();
            fichas3 = new LSL();
            fichas4 = new LSL();
            //Se reinicia el tablero
            listaFichasMesa = new LDL();
            mano = new NodoSimple(null);
            ladoLibreIzquierda = 6;
            ladoLibreDerecha = 6;
            coordenadaXFichaDerecha = 610;
            coordenadaXFichaIzquierda = 575;
            coordenadaYFichaIzquierda = (this.ClientSize.Height / 2) + 18;
            coordenadaYFichaDerecha = (this.ClientSize.Height / 2) - 17;
            cantidadFichasDerecha = 0;
            cantidadFichasIzquierda = 0;
            cantidadFichasAbajo = 0;
            cantidadFichasArriba = 0;
            turnosPasados = 0;
            repartirFichas();
            
            //Inicio de la nueva ronda
            LDL listaPictureBoxMesa = new LDL();
            jugadorEnTurno = mano;
            //Se coloca la ficha inicial (6-6)
            if (mano == jugador1)
            {
                colocar66(fichas1);
            }
            else if (mano == jugador2)
            {
                colocar66(fichas2);
            }
            else if (mano == jugador3)
            {
                colocar66(fichas3);
            }
            else
            {
                colocar66(fichas4);
            }

        }
        public void colocar66(LSL listaFichas)
        {
            //Coordenadas del punto donde va la ficha 6-6 en el tablero
            Point puntoCentral = new Point((this.ClientSize.Width / 2) - 17, (this.ClientSize.Height / 2) - 35);
            NodoSimple y = new NodoSimple(null);
            NodoSimple nodoFicha = listaFichas.buscarDato(ficha28, y);
            int indicePictureBox = 0; //Entero de referencia para el arreglo con picturebox del jugador 1
            if (listaFichas == fichas1)
            {
                NodoSimple x = listaFichas.primerNodo();
                //Se busca la ficha 28 (6-6) y luego el picturebox del arreglo se coloca en el punto central
                for (int i = 0; i < 7; i++)
                {
                    
                    if (x.retornarDato() == ficha28)
                    {
                        indicePictureBox = i;
                        i = 7;
                    }
                    x = x.retornarLiga();
                }
                imagenesJ1[indicePictureBox].Location = puntoCentral;
            }
            else
            {
                //Si la máquina es quien inicia el juego, se toma una ficha cualquiera y se cambia su imágen por la
                //ficha 6-6, también se pone en el centro
                PictureBox p;
                if (listaFichas == fichas2) 
                {
                    p = pictureB1;  
                }else if(listaFichas == fichas3)
                {
                    p = pictureC1;
                }
                else
                {
                    p = pictureD1;
                }
                p.Height = 70;
                p.Width = 35;
                p.Location = puntoCentral;
                p.Image = Image.FromFile("66.png");
            }
            //NodoSimple nodoFicha = (NodoSimple)y.retornarDato();
            listaFichas.borrar(nodoFicha, (NodoSimple)y.retornarDato());
            listaFichasMesa.insertar(ficha28, null);
            pasarTurno();
        }

        public void pasarTurno()//Método para cambiar el nodo de jugadorEnTurno
        {
            //MessageBox.Show("Turnos pasados: " + turnosPasados);
            if (turnosPasados > 3)
            {
                MessageBox.Show("Todos pasaron");
                finalizarRonda(fichas1);                
            }
            else
            {
                jugadorEnTurno = jugadorEnTurno.retornarLiga();
                if (jugadorEnTurno != jugador1)
                {
                    if (jugadorEnTurno == jugador2)
                    {
                        colocarFicha(fichas2, imagenesJ2);
                    }
                    else if (jugadorEnTurno == jugador3)
                    {
                        colocarFicha(fichas3, imagenesJ3);
                    }
                    else if (jugadorEnTurno == jugador4)
                    {
                        colocarFicha(fichas4, imagenesJ4);
                    }
                }
                else
                {
                    recorrerFichasJugador();
                }
            }
        }
                

        public void recorrerFichasJugador()//Busca si el jugador puede poner fichas o debe pasar su turno
        {
            int fichasDisponibles = 0;//Cuenta la cantidad de fichas que puede colocar
            NodoSimple nodoActual = fichas1.primerNodo();
            //Se buscan las fichas que se pueden colocar y se habilitan los picturebox de estas
            while (nodoActual != null)
            {
                Ficha fichaActual = (Ficha)nodoActual.retornarDato();
                if(fichaActual.contieneNumero(ladoLibreDerecha) || fichaActual.contieneNumero(ladoLibreIzquierda))
                {
                    fichaActual.getPictureBox().Enabled = true;
                    fichasDisponibles++;
                }
                nodoActual = nodoActual.retornarLiga();
            }
            if(fichasDisponibles == 0)//El jugador no tiene fichas para colocar, por lo tanto pasa el turno
            {
                MessageBox.Show("No tienes fichas para colocar");
                turnoJugador = false;
                turnosPasados++;
                pasarTurno();
            }
        }

        //Método para que la máquina ponga una ficha
        public void colocarFicha(LSL fichasJugador, PictureBox[] imagenesIA)
        {
            NodoSimple nodoActual = fichasJugador.primerNodo();
            //Se buscan las fichas que se pueden colocar y se habilitan los picturebox de estas
            while (nodoActual != null)
            {
                fichaSiguiente = (Ficha)nodoActual.retornarDato();
                if (fichaSiguiente.contieneNumero(ladoLibreDerecha) && fichaSiguiente.contieneNumero(ladoLibreIzquierda))
                {
                    Random random = new Random();
                    int eleccion = random.Next(0, 2);
                    PictureBox imagenMaquina = imagenesIA[7 - fichasJugador.cantidadElementos()];
                    imagenMaquina.Size = new Size(70, 35);
                    string nombreArchivo = fichaSiguiente.getNum1().ToString() + fichaSiguiente.getNum2().ToString() + ".png";
                    imagenMaquina.Image = Image.FromFile(nombreArchivo);
                    switch (eleccion)
                    {                        
                        case 0://Derecha
                            ubicarDerecha(imagenMaquina);
                            //Conectar ficha a la lista LDL de la mesa
                            fichasJugador.borrar(nodoActual, fichasJugador.anterior(nodoActual));
                            listaFichasMesa.insertar(fichaSiguiente, listaFichasMesa.ultimoNodo());
                            break;
                        case 1://Izquierda
                            ubicarIzquierda(imagenMaquina);
                            //Conectar ficha a la lista LDL de la mesa
                            fichasJugador.borrar(nodoActual, fichasJugador.anterior(nodoActual));
                            listaFichasMesa.insertar(fichaSiguiente, null);
                            break;
                    }
                    
                    break;
                }else if (fichaSiguiente.contieneNumero(ladoLibreDerecha))
                {
                    PictureBox imagenMaquina = imagenesIA[7 - fichasJugador.cantidadElementos()];
                    imagenMaquina.Size = new Size(70, 35);
                    string nombreArchivo = fichaSiguiente.getNum1().ToString() + fichaSiguiente.getNum2().ToString() + ".png";
                    imagenMaquina.Image = Image.FromFile(nombreArchivo);
                    ubicarDerecha(imagenMaquina);
                    //Conectar ficha a la lista LDL de la mesa
                    fichasJugador.borrar(nodoActual, fichasJugador.anterior(nodoActual));
                    listaFichasMesa.insertar(fichaSiguiente, listaFichasMesa.ultimoNodo());
                    
                    break;
                }
                else if (fichaSiguiente.contieneNumero(ladoLibreIzquierda))
                {
                    PictureBox imagenMaquina = imagenesIA[7 - fichasJugador.cantidadElementos()];
                    imagenMaquina.Size = new Size(70, 35);
                    string nombreArchivo = fichaSiguiente.getNum1().ToString() + fichaSiguiente.getNum2().ToString() + ".png";
                    imagenMaquina.Image = Image.FromFile(nombreArchivo);
                    ubicarIzquierda(imagenMaquina);
                    //Conectar ficha a la lista LDL de la mesa
                    fichasJugador.borrar(nodoActual, fichasJugador.anterior(nodoActual));
                    listaFichasMesa.insertar(fichaSiguiente, null);
                    
                    break;
                }
                nodoActual = nodoActual.retornarLiga();
            }
            if(nodoActual == null)
            {
                turnosPasados++;
            }
            if (fichasJugador.cantidadElementos() == 0)//La máquina no tiene fichas restantes
            {
                finalizarRonda(fichasJugador);
            }
            else
            {
                pasarTurno();
            }
            
        }

        public void ubicarDerecha(PictureBox imagen)//Ubica la ficha de la máquina a la derecha
        {
            //Orientación de la ficha
            if (cantidadFichasDerecha < 6)
            {
                if (fichaSiguiente.getNum1() == ladoLibreDerecha)
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                imagen.Location = new Point(coordenadaXFichaDerecha, (this.ClientSize.Height / 2) - 17);
                
                coordenadaXFichaDerecha += 70;
                cantidadFichasDerecha++;
            }
            else if (cantidadFichasArriba < 3)
            {
                imagen.Size = new Size(35, 70);
                if (fichaSiguiente.getNum1() == ladoLibreDerecha)
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }                
                imagen.Location = new Point(coordenadaXFichaDerecha - 35, coordenadaYFichaDerecha - 70);
                coordenadaYFichaDerecha -= 70;
                cantidadFichasArriba++;
                if (cantidadFichasArriba == 3)
                {
                    coordenadaXFichaDerecha -= 35;
                }
            }
            else //Se devuelve hacia la izquierda
            {
                imagen.Size = new Size(70, 35);
                if (fichaSiguiente.getNum1() == ladoLibreDerecha)
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                imagen.Location = new Point(coordenadaXFichaDerecha - 70, coordenadaYFichaDerecha);
                coordenadaXFichaDerecha -= 70;
            }
            //Cambio de la variable ladoLibre derecha o izquierda
            if (ladoLibreDerecha == fichaSiguiente.getNum1())
            {
                ladoLibreDerecha = fichaSiguiente.getNum2();
            }
            else
            {
                ladoLibreDerecha = fichaSiguiente.getNum1();
            }
            turnosPasados = 0;
        }

        public void ubicarIzquierda(PictureBox imagen)//Ubica la ficha de la máquina a la izquierda
        {
            
            if (cantidadFichasIzquierda < 6)
            {
                //Orientación de la ficha
                if (fichaSiguiente.getNum1() == ladoLibreIzquierda)
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                imagen.Location = new Point(coordenadaXFichaIzquierda - 70, (this.ClientSize.Height / 2) - 17);
                

                coordenadaXFichaIzquierda -= 70;
                cantidadFichasIzquierda++;
            }
            else if (cantidadFichasAbajo < 3)
            {
                imagen.Size = new Size(35, 70);
                if (fichaSiguiente.getNum2() == ladoLibreIzquierda)
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                imagen.Location = new Point(coordenadaXFichaIzquierda, coordenadaYFichaIzquierda);
                coordenadaYFichaIzquierda += 70;
                cantidadFichasAbajo++;
                if (cantidadFichasAbajo == 3)
                {
                    coordenadaXFichaIzquierda += 35;
                    coordenadaYFichaIzquierda -= 35;
                }
            }
            else
            {
                imagen.Size = new Size(70, 35);
                if (fichaSiguiente.getNum1() == ladoLibreIzquierda)
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    imagen.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                imagen.Location = new Point(coordenadaXFichaIzquierda, coordenadaYFichaIzquierda);
                coordenadaXFichaIzquierda += 70;
            }
            //Cambio de la variable ladoLibre derecha o izquierda
            if (ladoLibreIzquierda == fichaSiguiente.getNum1())
            {
                ladoLibreIzquierda = fichaSiguiente.getNum2();
            }
            else
            {
                ladoLibreIzquierda = fichaSiguiente.getNum1();
            }
            turnosPasados = 0;
        }

        public void finalizarRonda(LSL fichasGanador)//Termina la ronda, asigna el puntaje y busca si alguien ganó el juego
        {
            
            string ganadorRonda = "";
            bool elGanador = false;
            if (turnosPasados > 3)//Nadie puede poner fichas
            {
                int puntos1 = contarPuntos(fichas1);
                int puntos2 = contarPuntos(fichas2);
                int puntos3 = contarPuntos(fichas3);
                int puntos4 = contarPuntos(fichas4);
                int[] vectorPuntos = { puntos1, puntos2, puntos3, puntos4 };
                bool empate = false;    //Empate: Nadie puede poner fichas y hay al menos dos jugadores con los mismos puntos
                ganadorRonda = "Yo";
                if (puntos1 == puntos2 || puntos1 == puntos3 || puntos1 == puntos4 || puntos2 == puntos3 ||
                    puntos2 == puntos4 || puntos3 == puntos4)
                {
                    empate = true;
                }
                //Se busca el puntaje menor (aunque haya empate)
                int puntajeMenor = puntos1;
                if (puntajeMenor > puntos2)
                {
                    puntajeMenor = puntos2;
                    ganadorRonda = nombre2;
                }
                if (puntajeMenor > puntos3)
                {
                    puntajeMenor = puntos3;
                    ganadorRonda = nombre3;
                }
                if (puntajeMenor > puntos4)
                {
                    puntajeMenor = puntos4;
                    ganadorRonda = nombre4;
                }
                if (!empate)//No hay empate y se asignan los puntos totales al jugaador que tuvo menor número en sus fichas
                {
                    if (ganadorRonda.Equals("Yo"))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            P1.aumentarPuntaje(vectorPuntos[i] - puntajeMenor);
                        }
                        if (P1.retornaPuntaje() > 100)
                        {
                            elGanador = true;
                        }
                    }
                    else if (ganadorRonda.Equals(nombre2))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            P2.aumentarPuntaje(vectorPuntos[i] - puntajeMenor);
                        }
                        if (P2.retornaPuntaje() > 100)
                        {
                            elGanador = true;
                        }
                    }
                    else if (ganadorRonda.Equals(nombre3))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            P3.aumentarPuntaje(vectorPuntos[i] - puntajeMenor);
                        }
                        if (P3.retornaPuntaje() > 100)
                        {
                            elGanador = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            P4.aumentarPuntaje(vectorPuntos[i] - puntajeMenor);
                        }
                        if (P4.retornaPuntaje() > 100)
                        {
                            elGanador = true;
                        }
                    }
                }
                else//Hay empate, por lo que se le suman los puntos de los demás al jugador mano o que esté más cerca
                {
                    NodoSimple aux = mano;
                    while (aux != null)
                    {
                        if (aux == jugador1 && puntos1 == puntajeMenor)
                        {
                            P1.aumentarPuntaje(contarPuntos(fichas2, fichas3, fichas4));
                            ganadorRonda = "Yo";
                            if (P1.retornaPuntaje() > 100)
                            {
                                elGanador = true;
                            }
                            break;
                        }
                        else if (aux == jugador2 && puntos2 == puntajeMenor)
                        {
                            P2.aumentarPuntaje(contarPuntos(fichas1, fichas3, fichas4));
                            ganadorRonda = nombre2;
                            if (P1.retornaPuntaje() > 100)
                            {
                                elGanador = true;
                            }
                            break;
                        }
                        else if (aux == jugador3 && puntos3 == puntajeMenor)
                        {
                            P3.aumentarPuntaje(contarPuntos(fichas1, fichas2, fichas4));
                            ganadorRonda = nombre3;
                            if (P1.retornaPuntaje() > 100)
                            {
                                elGanador = true;
                            }
                            break;
                        }
                        else if (aux == jugador4 && puntos4 == puntajeMenor)
                        {
                            P4.aumentarPuntaje(contarPuntos(fichas1, fichas2, fichas3));
                            ganadorRonda = nombre4;
                            if (P1.retornaPuntaje() > 100)
                            {
                                elGanador = true;
                            }
                            break;
                        }
                        aux = aux.retornarLiga();
                    }

                }
            }
            else//Alguien quedó sin fichas, por lo que se suman los puntos de los demás
            {
                if (fichasGanador == fichas1)
                {
                    P1.aumentarPuntaje(contarPuntos(fichas2, fichas3, fichas4));
                    ganadorRonda = "Yo";
                    if (P1.retornaPuntaje() > 100)
                    {
                        elGanador = true;
                    }
                }
                else if (fichasGanador == fichas2)
                {
                    P2.aumentarPuntaje(contarPuntos(fichas1, fichas3, fichas4));
                    ganadorRonda = nombre2;
                    if (P2.retornaPuntaje() > 100)
                    {
                        elGanador = true;
                    }
                }
                else if (fichasGanador == fichas3)
                {
                    P3.aumentarPuntaje(contarPuntos(fichas1, fichas2, fichas4));
                    ganadorRonda = nombre3;
                    if (P3.retornaPuntaje() > 100)
                    {
                        elGanador = true;
                    }
                }
                else
                {
                    P4.aumentarPuntaje(contarPuntos(fichas1, fichas2, fichas3));
                    ganadorRonda = nombre4;
                    if (P4.retornaPuntaje() > 100)
                    {
                        elGanador = true;
                    }
                }
            }
            //Estas líneas tratan de reducir la memoria usada, aunque a veces no funcionan del todo bien
            fichas1.reiniciarLista();
            fichas2.reiniciarLista();
            fichas3.reiniciarLista();
            fichas4.reiniciarLista();
            listaFichasMesa.reiniciarLista();
            //Se muestra el mensaje de ganador de ronda y en caso de que alguien tenga más de 100 puntos, lo asigna
            //como ganador del juego
            if (ganadorRonda.Equals("Yo"))
            {
                MessageBox.Show("¡Has dominado la ronda!");
            }
            else
            {
                MessageBox.Show("¡" + ganadorRonda + " dominó la ronda!");
            }
            
            Puntaje.Items.Clear();
            Puntaje.Items.Add("Yo :  " + P1.retornaPuntaje());
            Puntaje.Items.Add(nombre2 + " :  " + P2.retornaPuntaje());
            Puntaje.Items.Add(nombre3 + " :  " + P3.retornaPuntaje());
            Puntaje.Items.Add(nombre4 + " :  " + P4.retornaPuntaje());
            Puntaje.Visible = true;
            if (elGanador == false)
            {                
                botonContinuar.Visible = true;
            }
            else
            {
                if (ganadorRonda.Equals("Yo"))
                {
                    MessageBox.Show("¡Felicidades!\nHas ganado el juego");
                }
                else
                {
                    MessageBox.Show("Lo sentimos\nHas perdido el juego");
                }
            }        
            
        }

        public int contarPuntos(LSL a, LSL b, LSL c)//Cuenta los puntos de tres jugadores y los suma en un sólo int
        {
            int puntos = 0;
            NodoSimple x = a.primerNodo();
            while (x != null)
            {
                Ficha aux = (Ficha)x.retornarDato();
                puntos += aux.getNum1() + aux.getNum2();
                x = x.retornarLiga();
            }
            x = b.primerNodo();
            while (x != null)
            {
                Ficha aux = (Ficha)x.retornarDato();
                puntos += aux.getNum1() + aux.getNum2();
                x = x.retornarLiga();
            }
            x = c.primerNodo();
            while (x != null)
            {
                Ficha aux = (Ficha)x.retornarDato();
                puntos += aux.getNum1() + aux.getNum2();
                x = x.retornarLiga();
            }
            return (puntos);
        }
        public int contarPuntos(LSL a)//Cuenta los puntos de un sólo jugador y lo asigna a un int
        {
            int puntos = 0;
            NodoSimple x = a.primerNodo();
            while (x != null)
            {
                Ficha aux = (Ficha)x.retornarDato();
                puntos += aux.getNum1() + aux.getNum2();
                x = x.retornarLiga();
            }
            return (puntos);
        }

        public void deshabilitarPictureBox()//Bloquea los picturebox para que el usuario no pueda hacer click
        {
            for (int i = 0; i < 7; i++)
            {
                imagenesJ1[i].Enabled = false;
            }
        }

        //Eventos de click en los pickturebox del usuario
        private void pictureJ1_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ1;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while(nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if(fichaActual.getPictureBox() == pictureJ1)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }

        private void pictureJ2_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ2;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while (nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if (fichaActual.getPictureBox() == pictureJ2)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }

        private void pictureJ3_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ3;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while (nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if (fichaActual.getPictureBox() == pictureJ3)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }

        private void pictureJ4_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ4;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while (nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if (fichaActual.getPictureBox() == pictureJ4)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }

        private void pictureJ5_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ5;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while (nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if (fichaActual.getPictureBox() == pictureJ5)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }

        private void pictureJ6_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ6;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while (nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if (fichaActual.getPictureBox() == pictureJ6)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }

        private void pictureJ7_Click(object sender, EventArgs e)
        {
            if (jugadorEnTurno == jugador1)
            {
                deshabilitarPictureBox();
                imagenAMover = pictureJ7;
                NodoSimple nodoFicha = fichas1.primerNodo();
                while (nodoFicha != null)
                {
                    Ficha fichaActual = (Ficha)nodoFicha.retornarDato();//Ficha contenida dentro del nodo
                    if (fichaActual.getPictureBox() == pictureJ7)
                    {
                        fichaSiguiente = fichaActual;
                        //El nodo y la ficha coinciden con la imagen del picturebox
                        if (fichaActual.contieneNumero(ladoLibreDerecha))
                        {
                            botonDerecha.Enabled = true;
                        }
                        if (fichaActual.contieneNumero(ladoLibreIzquierda))
                        {
                            botonIzquierda.Enabled = true;
                        }
                        break;
                    }
                    nodoFicha = nodoFicha.retornarLiga();
                }

            }
        }        

        private void botonIzquierda_Click(object sender, EventArgs e)//Click en la flecha izquierda para colocar la ficha
        {
            
            //se pone la ficha tenemos que mover el picturebox
            if (cantidadFichasIzquierda < 6)
            {
                
                cantidadFichasIzquierda++;
                imagenAMover.Size = new Size(70, 35);
                if (fichaSiguiente.getNum1() == ladoLibreIzquierda)
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                
                imagenAMover.Location = new Point(coordenadaXFichaIzquierda - 70, (this.ClientSize.Height / 2) - 17);
                coordenadaXFichaIzquierda -= 70;
                
            }
            else if(cantidadFichasAbajo < 3) //Ficha hacia abajo
            {
                cantidadFichasAbajo++;
                imagenAMover.Size = new Size(35, 70);
                if (fichaSiguiente.getNum2() == ladoLibreIzquierda)
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }

                imagenAMover.Location = new Point(coordenadaXFichaIzquierda, coordenadaYFichaIzquierda);
                coordenadaYFichaIzquierda += 70;
                if (cantidadFichasAbajo == 3)
                {
                    coordenadaYFichaIzquierda -= 35;
                    coordenadaXFichaIzquierda += 35;
                }
            }
            else
            {
                imagenAMover.Size = new Size(70, 35);
                if (fichaSiguiente.getNum1() == ladoLibreIzquierda)
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                imagenAMover.Location = new Point(coordenadaXFichaIzquierda, coordenadaYFichaIzquierda);
                coordenadaXFichaIzquierda += 70;
            }
            if (ladoLibreIzquierda == fichaSiguiente.getNum1())
            {
                ladoLibreIzquierda = fichaSiguiente.getNum2();
            }
            else
            {
                ladoLibreIzquierda = fichaSiguiente.getNum1();
            }
            //Quitar el nodo de las fichas del jugador y enviarlo a la mesa
            NodoSimple y = new NodoSimple(null);
            fichas1.borrar(fichas1.buscarDato(fichaSiguiente, y), (NodoSimple)y.retornarDato());
            listaFichasMesa.insertar(fichaSiguiente, null);
            //Deshabilitar los botones y pasar el turno
            botonIzquierda.Enabled = false;
            botonDerecha.Enabled = false;
            turnoJugador = false;
            turnosPasados = 0;
            deshabilitarPictureBox();
            if (fichas1.cantidadElementos() == 0)
            {
                finalizarRonda(fichas1);
            }
            else
            {
                pasarTurno();
            }
        }

        private void botonDerecha_Click(object sender, EventArgs e)//Click en la flecha derecha para colocar la ficha
        {
            if (cantidadFichasDerecha < 6)
            {                
                cantidadFichasDerecha++;
                imagenAMover.Size = new Size(70, 35);
                if (fichaSiguiente.getNum1() == ladoLibreDerecha)
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                imagenAMover.Location = new Point(coordenadaXFichaDerecha, (this.ClientSize.Height / 2) - 17);
                coordenadaXFichaDerecha += 70;
            }
            else if (cantidadFichasArriba < 3) //Ficha hacia abajo
            {
                cantidadFichasArriba++;
                imagenAMover.Size = new Size(35, 70);
                if (fichaSiguiente.getNum1() == ladoLibreDerecha)
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }

                imagenAMover.Location = new Point(coordenadaXFichaDerecha - 35, coordenadaYFichaDerecha - 70);
                coordenadaYFichaDerecha -= 70;
                if (cantidadFichasArriba == 3)
                {
                    coordenadaXFichaDerecha -= 35;
                }
            }
            else
            {
                imagenAMover.Size = new Size(70, 35);
                if (fichaSiguiente.getNum1() == ladoLibreDerecha)
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    imagenAMover.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                imagenAMover.Location = new Point(coordenadaXFichaDerecha - 70, coordenadaYFichaDerecha);
                coordenadaXFichaDerecha -= 70;
            }
            if (ladoLibreDerecha == fichaSiguiente.getNum1())
            {
                ladoLibreDerecha = fichaSiguiente.getNum2();
            }
            else
            {
                ladoLibreDerecha = fichaSiguiente.getNum1();
            }
            //Quitar el nodo de las fichas del jugador y enviarlo a la mesa
            NodoSimple y = new NodoSimple(null);
            fichas1.borrar(fichas1.buscarDato(fichaSiguiente, y), (NodoSimple)y.retornarDato());
            listaFichasMesa.insertar(fichaSiguiente, listaFichasMesa.ultimoNodo());
            //Deshabilitar los botones y pasar el turno
            botonIzquierda.Enabled = false;
            botonDerecha.Enabled = false;
            turnoJugador = false;
            turnosPasados = 0;
            deshabilitarPictureBox();
            if (fichas1.cantidadElementos() == 0)
            {
                finalizarRonda(fichas1);
            }
            else
            {
                pasarTurno();
            }
        }

        private void botonContinuar_Click(object sender, EventArgs e)
        {
            iniciarRonda();
        }

        private void Juego_FormClosed(object sender, FormClosedEventArgs e)//Cierra la aplicación en caso de cerrar la ventana de juego
        {
            Application.Exit();
        }
    }
}
