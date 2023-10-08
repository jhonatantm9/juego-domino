using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public static bool ajustesAbierto = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ajustesAbierto) { 
                Juego interfaz = new Juego();
                interfaz.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ajustes ajustes = new Ajustes();
            ajustes.Visible = true;
            ajustesAbierto = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instrucciones\n\nEn cada ronda, el usuario deberá elegir una ficha para colocar en" +
                " la mesa. Dentro del juego habrán 2 botones que sirven para elegir a que lado quiere enviar" +
                " la ficha, los botones son dos flechas que apuntan al lado derecho e izquierdo. Luego de eligir" +
                " la ficha que se desea colocar, los botones se habilitarán y debera darle clic para ubicar la ficha.");
        }
    }
}
