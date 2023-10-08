using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class LSLC
    {
        private NodoSimple primero;
        private NodoSimple ultimo;


        public LSLC()
        {
            primero = null;
            ultimo = null;
        }
        public bool finDeRecorrido(NodoSimple p)
        {
            if(p == primero)
            {
                return true;
            }
            return false;
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
                ultimo.asignarLiga(x);
                primero = x;
            }
            else
            {
                x.asignarLiga(y.retornarLiga());
                y.asignarLiga(x);
            }
            if (y == ultimo)
            {
                ultimo = x;
            }
        }
        public NodoSimple buscarDato(object d, NodoSimple y)
        {
            NodoSimple x = primero;
            do
            {
                y.asignarDato(x);
                x = x.retornarLiga();
            } while (!finDeRecorrido(x) && x.retornarDato() != d);
            return (x);
        }
        public void desconectar(NodoSimple x, NodoSimple y)
        {
            if (y == null)
            {
                if (primero == ultimo)
                {
                    ultimo = null;
                    primero = null;
                }
                else
                {
                    primero  = x.retornarLiga();
                    ultimo.asignarLiga(primero);
                }
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
        public void conectarAlFinal(NodoSimple x)
        {
            conectar(x, ultimo);
        }
    }
}
