using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class Jugador
    {
        private string nombre;
        private int puntaje = 0;

        public Jugador(string nombre)
        {
            this.nombre = nombre;
        }
        public void asignarNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void asignarPuntaje(int puntos)
        {
            puntaje = puntos;
        }
        public void aumentarPuntaje(int puntos)
        {
            puntaje += puntos;
        }
        public string retornaNombre()
        {
            return (nombre);
        }
        public int retornaPuntaje()
        {
            return (puntaje);
        }
    }
}
