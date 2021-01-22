using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3enraya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // ATRIBUTOS
        // string per jugadors (controla la cantitat de fitxes que te en joc)
        public int jugador1 = 0;
        public int jugador2 = 0;
        // string per als noms dels jugadors
        public string jugador1_nom = "";
        public string jugador2_nom = "";
        public string jugador1_tipus = "";
        public string jugador2_tipus = "";
        // arrays per comprobar les 8 línies possibles
        public string[] array123 = new string[3] {"", "", ""};
        public string[] array456 = new string[3] {"", "", ""};
        public string[] array789 = new string[3] {"", "", ""};
        public string[] array147 = new string[3] {"", "", ""};
        public string[] array258 = new string[3] {"", "", ""};
        public string[] array369 = new string[3] {"", "", ""};
        public string[] array357 = new string[3] {"", "", ""};
        public string[] array159 = new string[3] {"", "", ""};
        // string para marjar qué jugador es el activo;
        public string jugadorActual = "x";
        

        private void button1_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button1);
            array123[0] = button1.Text;
            array147[0] = button1.Text;
            array159[0] = button1.Text;
            CheckVictoria(array123);
            CheckVictoria(array147);
            CheckVictoria(array159);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button2);
            array258[0] = button2.Text;
            array123[1] = button2.Text;
            CheckVictoria(array258);
            CheckVictoria(array123);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button3);
            array123[2] = button3.Text;
            array357[0] = button3.Text;
            array369[0] = button3.Text;
            CheckVictoria(array123);
            CheckVictoria(array357);
            CheckVictoria(array369);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button4);
            array147[1] = button4.Text;
            array456[0] = button4.Text;
            CheckVictoria(array147);
            CheckVictoria(array456);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button5);
            array258[1] = button5.Text;
            array159[1] = button5.Text;
            array357[1] = button5.Text;
            array456[1] = button5.Text;
            CheckVictoria(array258);
            CheckVictoria(array159);
            CheckVictoria(array357);
            CheckVictoria(array456);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button6);
            array456[2] = button6.Text;
            array369[1] = button6.Text;
            CheckVictoria(array456);
            CheckVictoria(array369);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button7);
            array789[0] = button7.Text;
            array147[2] = button7.Text;
            array357[2] = button7.Text;
            CheckVictoria(array789);
            CheckVictoria(array147);
            CheckVictoria(array357);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button8);
            array789[1] = button8.Text;
            array258[2] = button8.Text;
            CheckVictoria(array789);
            CheckVictoria(array258);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Jugar(jugadorActual, button9);
            array789[2] = button9.Text;
            array369[2] = button9.Text;
            array159[2] = button9.Text;
            CheckVictoria(array789);
            CheckVictoria(array369);
            CheckVictoria(array159);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //BOTÓ NOVA PARTIDA
            // executem la funció per reiniciar la partida
            resetejarPartida();
            if (radioButton3.Checked) //per iniciar la jugada 1 si el primer jugador es CPU
            {
                CheckIfCPU(jugadorActual);
            }

        }
        private void Jugar(string jugador, System.Windows.Forms.Button boto)//procediment per verificar si es huma i fer-lo jugar
        {
            
            if (jugador == "x")
            {
                if (radioButton1.Checked)
                {
                    JugarHuman(jugador, boto);
                }
            }
            else
            {
                if (radioButton2.Checked)
                {
                    JugarHuman(jugador, boto);
                }
            }
        }
        private void JugarHuman (string jugador, System.Windows.Forms.Button boto)
        {
            if (jugador == "x")
            {
                //en cas que el jugador porti menys de 3 jugades, pot jugar lliurement, sino primer haura de retirar una peça
                if (jugador1 < 3)
                {
                    if (boto.Text == "") //si la casella esta buida, pot jugar a aquella posicio
                    {
                        jugador1++;
                        boto.Text = jugador;
                        CanviJugador(jugador);
                    }
                }
                else
                {
                    //nomes pot retirar la peça si es propietat seva
                    if (boto.Text == "x")
                    {
                        jugador1--;
                        boto.Text = "";
                    }
                }
            }
            else
            {
                if (jugador2 < 3)
                {
                    if (boto.Text == "")
                    {
                        jugador2++;
                        boto.Text = jugador;
                        CanviJugador(jugador);
                    }
                }
                else
                {
                    if (boto.Text == "o")
                    {
                        jugador2--;
                        boto.Text = "";
                    }
                }
            }
        }//jugada humana
        
        private void CanviJugador(string jugador)//canvia de jugador i inicia jugada de cpu si convé
        {
            // Li pasem el jugador actual i fa el canvi de jugador
            // método para cambiar la marca del jugador, se ejecutará al final de cada botón
            if (jugador== "x") // si actualmente es x
            {
                label2.Text = "o"; // cambia la marca que se muestra por pantalla en el form de la marca activa
                label3.Text = "(" + jugador2_nom + ")"; // cambia el nombre del jugador activo que se muestra en el form
                jugadorActual = "o"; // cambia el jugador actual
            }
            else
            {
                label2.Text = "x"; // cambia la marca que se muestra por pantalla en el form de la marca activa
                label3.Text = "(" + jugador1_nom + ")"; // cambia el nombre del jugador activo que se muestra en el form
                jugadorActual = "x"; // cambia el jugador actual
            }
            CheckIfCPU(jugadorActual);
        }
        private void CheckIfCPU(string jugador)//juega como CPU si es CPU
        {
            // comprova si es un cpu a qui li toca jugar
            if ((radioButton3.Checked && jugador == "x") || (radioButton4.Checked && jugador == "o"))
            {
                JugarCPU(jugador); // executem funcio de jugar cpu
                CanviJugador(jugador); // canviem jugador
            }
        }

        private void CheckVictoria(string[] array)
        {
            string guanyador;
            
            // método para saber si hay un 3 en línea, pasando por parámetro el array en el que se acaba de jugar
            if (array[0] == array[1] && array[0] == array[2] && array[0]!="")
            {
                //Form2.Show();
                if (jugadorActual == "x")
                {
                    guanyador = jugador2_nom;
                }
                else
                {
                    guanyador = jugador1_nom;
                }
                MessageBox.Show("FIN DE PARTIDA. HA GANADO EL PUTO " + guanyador + "!!!!");
                //this.Hide();
            }
        }

        private void JugarCPU(string jugador)
        {
            //metodo para que la cp juegue

            //System.Threading.Thread.Sleep(500); // que dormi 0.5 segons per a veure el moviment

            if (jugador == "x") // si cpu es x
            {
                if (jugador1<3) //si falte per jugar
                {
                    CasellaRandom(jugador, false);
                }
                else
                {
                    CasellaRandom(jugador, true);
                    CasellaRandom(jugador, false);
                }
            }
            else // si cpu es y
            {
                if (jugador2 < 3) //si falte per jugar
                {
                    CasellaRandom(jugador, false);
                }
                else
                {
                    CasellaRandom(jugador, true);
                    CasellaRandom(jugador, false);
                }
            }
        }

        private void CasellaRandom(string jugador, bool borrar)
        {
            // método para que la ia ponga su ficha o la borre, usando un random, comprobamos si esta vacia y ponemos la marca
            Random r = new Random();
            Boolean correcto = false;
            string numeroRandom;
            System.Windows.Forms.Button buttonRandom;

            while (correcto == false) // mientras la marca no este puesta
            {
                numeroRandom = Convert.ToString(r.Next(1, 10));//generamos nuevo numero random entre 1 y 9
                // generamos un objeto botón con el numeroRandom para generar un botón random 
                buttonRandom = (System.Windows.Forms.Button)this.Controls["button" + numeroRandom];
                // si el boton está vacio y no hay que sobreescribir
                if (buttonRandom.Text == "" && borrar == false)
                {
                    buttonRandom.Text = jugador; // ponemos la marca
                    correcto = true; // salimos del bucle
                    if (jugador == "x")
                    {
                        jugador1++;
                    }
                    else
                    {
                        jugador2++;
                    }
                }
                else if (borrar == true && buttonRandom.Text == jugador) // si tenemos que borrar la casilla
                {
                    buttonRandom.Text = ""; // borramos la marca
                    correcto = true; // salimos del bucle
                    if (jugador == "x")
                    {
                        jugador1--;
                    }
                    else
                    {
                        jugador2--;
                    }
                }
            }
        }


        public void resetejarPartida()
        {
            // método para resetear los valores a 0 para empezar una nueva partida
            // se llama en el botón de resetear partida y al cargar el form del ganador
            // checkeamos que esten los jugadores seleccionados
            if (!((radioButton1.Checked || radioButton3.Checked) && (radioButton2.Checked || radioButton4.Checked)))
            {
                MessageBox.Show("No es pot iniciar partida fins triis el tipus de jugadors"+radioButton1.Checked+radioButton2.Checked+radioButton3.Checked+radioButton4.Checked);
            }
            else
            {
                //INICIALITZEM LA PARTIDA
                for (int i = 0; i < 3; i++)
                {
                    //netegem la pantalla
                    button1.Text = "";
                    button2.Text = "";
                    button3.Text = "";
                    button4.Text = "";
                    button5.Text = "";
                    button6.Text = "";
                    button7.Text = "";
                    button8.Text = "";
                    button9.Text = "";
                    // reseteamos la matriz controladora de cada posible victoria
                    array123[i] = "";
                    array456[i] = "";
                    array789[i] = "";
                    array147[i] = "";
                    array258[i] = "";
                    array369[i] = "";
                    array159[i] = "";
                    array357[i] = "";
                }
                // asignamos la cantidad de marcas puesta por cada jugador a 0
                jugador1 = 0;
                jugador2 = 0;
                //ASSIGNEM NOMS ALS JUGADORS
                jugador1_nom = textBox1.Text;
                jugador2_nom = textBox2.Text;
                label3.Text = jugador1_nom;
                label2.Text = "x";
                jugadorActual="x";
            }
        }

    }
}
