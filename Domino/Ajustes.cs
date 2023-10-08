using System;
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
    public partial class Ajustes : Form
    {
        public Ajustes()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") && textBox2.Text.Equals("") && textBox3.Text.Equals(""))
            {
                MenuPrincipal.ajustesAbierto = false;
                Dispose();
            }
            else if(textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese todos los campos");
            }else if(textBox1.Text.Length >10 || textBox2.Text.Length > 10 || textBox3.Text.Length > 10)
            {
                MessageBox.Show("El máximo número de caractéres en el nombre es 10");
            }
            else
            {
                Juego.nombre2 = textBox1.Text;
                Juego.nombre3 = textBox2.Text;
                Juego.nombre4 = textBox3.Text;
                MenuPrincipal.ajustesAbierto = false;
                this.Dispose();
            }
        }
    }
}
