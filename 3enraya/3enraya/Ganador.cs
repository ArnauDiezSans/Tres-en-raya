using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TresEnRaya
{
    public partial class Ganador : Form
    {
        public Ganador()
        {
            InitializeComponent();
        }
        //ATRIBUTOS
        TresEnRaya partida = new TresEnRaya(); //objeto de la ventana form1
        public string guanyador { get; set; } // string del ganador de la partida, se envía en la función de checkVictoria()

        private void button2_Click(object sender, EventArgs e)
        {
            // BOTÓN DE SALIR
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // BOTÓN DE REINICIAR PARTIDA
            // executem el mètode de resetejar partida del form TresEnRaya
            if (System.Windows.Forms.Application.OpenForms["TresEnRaya"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["TresEnRaya"] as TresEnRaya).resetejarPartida();
            }
            this.Close();
        }

        private void Ganador_Shown(object sender, EventArgs e)
        {
            // LABEL DE TEXTO DONDE SE MUESTRA EL GANADOR ; EVENTO : onShow
            label1.Text = "Enhorabona " + guanyador + "!!! Has guanyat.";
        }
    }
}
