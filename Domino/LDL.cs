using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class LDL
    {
        private NodoDoble primero;
        private NodoDoble ultimo;

        public LDL()
        {
            primero = null;
            ultimo = null;
        }

        public NodoDoble primerNodo()
        {
            return (primero);
        }
        public NodoDoble ultimoNodo()
        {
            return (ultimo);
        }
        public bool esVacia()
        {
            return (primero == null);
        }
        public bool finDeRecorrido(NodoDoble x)
        {
            return (x == null);
        }
        public void conectar(NodoDoble x, NodoDoble y)
        {
            if (y == null) {
                if (primero == null)
                {
                    ultimo = x;
                }
                else
                {
                    x.asignarLD(primero);
                    primero.asignarLI(x);
                }
                
                primero = x;
                return;
            }
            if (y == ultimo) {
                x.asignarLI(y);
                y.asignarLD(x);
                ultimo = x;
            }
            else {
                x.asignarLI(y);
                x.asignarLD(y.retornaLD());
                y.asignarLD(x);
                x.retornaLD().asignarLI(x);
            }
                
        }
        public void insertarAlFinal(object d)
        {
            NodoDoble x = new NodoDoble(d);
            conectar(x, ultimo);
        }
        public void insertar(object d, NodoDoble y) {
            NodoDoble x = new NodoDoble(d);
            conectar(x, y);
        }
        public NodoDoble buscarDato(object d) {
            NodoDoble p = primerNodo();
            while (!finDeRecorrido(p) && p.retornaDato() != d) {
                p = p.retornaLD();
            }
            return (p);
        }
        public void borrar(NodoDoble x) {
            if (x == null) {
                //this.displayText.Text += "No se encuentra el dato";
            }
            desconectar(x);
        }
        public void desconectar(NodoDoble x) {
            if (primero == x) {
                primero = x.retornaLD();
                if (primero == null)
                {
                    ultimo = null;
                }
                else {
                    primero.asignarLI(null);
                }
                return;
            }
            if (x == ultimo)
            {
                ultimo = x.retornaLI();
                ultimo.asignarLD(null);
            }
            else {
                x.retornaLI().asignarLD(x.retornaLD());
                x.retornaLD().asignarLD(x.retornaLI());
            }
        }     
        
        public void reiniciarLista()
        {
            NodoDoble x = primero;
            while(x != null)
            {
                NodoDoble y = x.retornaLD();
                x.eliminarNodo();
                x = y;
            }
            primero = null;
            ultimo = null;
        }

    }
}