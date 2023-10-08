using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class LSL
    {
        private NodoSimple primero;
        private NodoSimple ultimo;

        public LSL()
        {
            primero = null;
            ultimo = null;
        }

        public NodoSimple primerNodo()
        {
            return (primero);
        }
        public NodoSimple ultimoNodo()
        {
            return (ultimo);
        }
        public void setUltimoNodo(NodoSimple x)
        {
            ultimo = x;
        }
        public void setPrimerNodo(NodoSimple x)
        {
            primero = x;
        }
        public void insertarDato(Object d, NodoSimple y)
        {
            NodoSimple x = new NodoSimple(d);
            conectar(x, y);
        }
        public void conectar(NodoSimple x, NodoSimple y)
        {
            if (y == null)
            {
                if (primero == null)
                {
                    ultimo = x;
                }
                else
                {
                    x.asignarLiga(primero);
                }
                primero = x;
            }
            else
            {
                x.asignarLiga(y.retornarLiga());
                y.asignarLiga(x);
            }
            if (ultimo == y)
            {
                ultimo = x;
            }
        }
        public NodoSimple buscarDato(Object d, NodoSimple y)
        {
            NodoSimple x = primero;
            while (x != null && x.retornarDato() != d)
            {
                y.asignarDato(x);
                x = x.retornarLiga();
            }
            return (x);
        }

        //y tiene como dato el nodo anterior a x
        public void desconectar(NodoSimple x, NodoSimple y)
        {
            if (y == null)
            {
                if (primero == ultimo)
                {
                    ultimo = null;
                }
                primero = x.retornarLiga();
            }
            else
            {
                y.asignarLiga(x.retornarLiga());
                if (x == ultimo)
                {
                    ultimo = y;
                }
            }
        }
        public void borrar(NodoSimple x, NodoSimple y)
        {
            if (x != null)
            {
                desconectar(x, y);
            }
        }

        public int cantidadElementos()
        {
            int cantidad = 0;
            if(primero == null)
            {
                return (0);
            }
            else
            {
                NodoSimple x = primero;
                while (x != null)
                {
                    x = x.retornarLiga();
                    cantidad++;
                }
                return (cantidad);
            }
        }
        public NodoSimple anterior(NodoSimple x)
        {
            if (x == primero)
            {
                return null;
            }
            else
            {
                NodoSimple y = primero;
                while (y != ultimo)
                {
                    if (y.retornarLiga() == x)
                    {
                        return (y);
                    }
                    y = y.retornarLiga();
                }
                return (y);
            }
        }

        public void reiniciarLista()
        {
            NodoSimple x = primero;
            while (x != null)
            {
                NodoSimple y = x.retornarLiga();
                x.eliminarNodo();
                x = y;
            }
            primero = null;
            ultimo = null;
        }
    }
    
}
