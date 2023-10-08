using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class NodoSimple
    {
        private Object dato;
        private NodoSimple liga;

        public NodoSimple(object d)
        {
            dato = d;
            liga = null;
        }
        public void asignarDato(Object d)
        {
            dato = d;
        }
        public void asignarLiga(NodoSimple x)
        {
            liga = x;
        }
        public Object retornarDato()
        {
            return (dato);
        }
        public NodoSimple retornarLiga()
        {
            return (liga);
        }

        public void eliminarNodo()
        {
            liga = null;            
            dato = null;
        }

    }
}
