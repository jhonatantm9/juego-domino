using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class NodoDoble
    {
        private object dato;
        private NodoDoble LI;
        private NodoDoble LD;

        public NodoDoble(object d)
        {
            LI = null;
            LD = null;
            dato = d;
        }
        public void asignarLD(NodoDoble x)
        {
            LD = x;
        }
        public void asignarLI(NodoDoble x)
        {
            LI = x;
        }
        public NodoDoble retornaLD()
        {
            return (LD);
        }
        public NodoDoble retornaLI()
        {
            return (LI);
        }
        public object retornaDato()
        {
            return (dato);
        }
        public void asignarDato(object d)
        {
            dato = d;
        }

        public void eliminarNodo()
        {
            LI = null;
            LD = null;
            dato = null;
        }
    }
}
