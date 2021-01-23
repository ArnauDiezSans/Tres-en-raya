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
    public partial class TresEnRaya : Form
    {
        /*
         * Joc del tres en ratlla.
         * 
         * El programa funciona de forma que al clicar un boto, executa funcions per
         * comprovar qui esta jugant i printar la marca corresponent. Màxim de 3 marques,
         * si ja s'en te tres, s'ha de treure una marca igual existent abans de poder ficar
         * una altra marca.
         * 
         * Al modificar el contingut dels botons, s'executa la funció per comprovar si hi ha
         * victoria de algun jugador. Per fer això, tenim 8 arrays:
         * - cada array correspont a una de les 8 línies posibles on es pot fer la ratlla:
         * 
         *  1   | 1    | 1 8
         *  4 7 | 5    | 6
         * -------------------
         *  2   | 2 8  | 2
         *  4   | 5 7  | 6
         * -------------------
         *  3 8 | 3    | 3
         *  4   | 5    | 6 7
         *     
         * quant se fa una marca, es canvia el valor als arrais corresponents i si 
         * coincideixen es done la victoria.
         *
         * Els arrays estan declarats amb 3 números, cada número correspon a la 
         * posició del botó al programa, aixó doncs (exemple):
         * array123 = línea superior horitzontal que correspont a la línea 1 al model superior
         * array159 = línea diagonal descendent que comença adalt a la esquerra
         * array147 = línea vertical esquerra. 
         * 
         */
        public TresEnRaya()
        {
            InitializeComponent();
        }
        // ATRIBUTOS
        // string per jugadors (controla la cantitat de fitxes que te en joc)
        int jugador1 = 0;
        int jugador2 = 0;
        // string per als noms dels jugadors
        string jugador1_nom = "";
        string jugador2_nom = "";
        // arrays per comprobar les 8 línies possibles
        string[] array123 = new string[3] {"", "", ""};
        string[] array456 = new string[3] {"", "", ""};
        string[] array789 = new string[3] {"", "", ""};
        string[] array147 = new string[3] {"", "", ""};
        string[] array258 = new string[3] {"", "", ""};
        string[] array369 = new string[3] {"", "", ""};
        string[] array357 = new string[3] {"", "", ""};
        string[] array159 = new string[3] {"", "", ""};
        // string para marjar qué jugador es el activo;
        string jugadorActual = "x";
        // string per comprobar que les cpu no fiquin la marca on l'acaben de treure
        string nombreCasillaRetirada = "";
        // string per indicar qui es el guanyador
        public string guanyador = "";
        // boolean para parar la ejecucion del bucle de juego CPU-CPU
        Boolean finalPartida = false;

        private void button1_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº1 ; POSICIÓN NOROESTE ; EVENTO onClick
            Jugar(jugadorActual, button1);
        }
        private void button1_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº1 ; POSICIÓN NOROESTE ; EVENTO onTextChanged
            array123[0] = button1.Text;
            array147[0] = button1.Text;
            array159[0] = button1.Text;
            CheckVictoria(array123);
            CheckVictoria(array147);
            CheckVictoria(array159);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº2 ; POSICIÓN NORTE ; EVENTO onClick
            Jugar(jugadorActual, button2);
        }
        private void button2_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº2 ; POSICIÓN NORTE ; EVENTO onTextChanged
            array258[0] = button2.Text;
            array123[1] = button2.Text;
            CheckVictoria(array258);
            CheckVictoria(array123);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº3 ; POSICIÓN NORDESTE ; EVENTO onClick
            Jugar(jugadorActual, button3);
        }
        private void button3_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº3 ; POSICIÓN NORDESTE ; EVENTO onTextChanged
            array123[2] = button3.Text;
            array357[0] = button3.Text;
            array369[0] = button3.Text;
            CheckVictoria(array123);
            CheckVictoria(array357);
            CheckVictoria(array369);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº4 ; POSICIÓN ESTE ; EVENTO onClick
            Jugar(jugadorActual, button4);
        }
        private void button4_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº4 ; POSICIÓN ESTE ; EVENTO onTextChanged
            array147[1] = button4.Text;
            array456[0] = button4.Text;
            CheckVictoria(array147);
            CheckVictoria(array456);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº5 ; POSICIÓN CENTRAL ; EVENTO onClick
            Jugar(jugadorActual, button5);
        }
        private void button5_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº5 ; POSICIÓN CENTRAL ; EVENTO onTextChanged
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
            // BOTÓN Nº6 ; POSICIÓN ESTE ; EVENTO onClick
            Jugar(jugadorActual, button6);
        }
        private void button6_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº6 ; POSICIÓN ESTE ; EVENTO onTextChanged
            array456[2] = button6.Text;
            array369[1] = button6.Text;
            CheckVictoria(array456);
            CheckVictoria(array369);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº7 ; POSICIÓN SUDOESTE ; EVENTO onClick
            Jugar(jugadorActual, button7);
        }
        private void button7_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº7 ; POSICIÓN SUDOESTE ; EVENTO onTextChanged
            array789[0] = button7.Text;
            array147[2] = button7.Text;
            array357[2] = button7.Text;
            CheckVictoria(array789);
            CheckVictoria(array147);
            CheckVictoria(array357);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº8 ; POSICIÓN SUD ; EVENTO onClick
            Jugar(jugadorActual, button8);
        }
        private void button8_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº8 ; POSICIÓN SUD ; EVENTO onTextChanged
            array789[1] = button8.Text;
            array258[2] = button8.Text;
            CheckVictoria(array789);
            CheckVictoria(array258);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // BOTÓN Nº9 ; POSICIÓN SUDESTE ; EVENTO onClick
            Jugar(jugadorActual, button9);
        }
        private void button9_TextChanged(object sender, EventArgs e)
        {
            // BOTÓN Nº9 ; POSICIÓN SUDESTE ; EVENTO onTextChanged
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

            //asignem nom als jugadors
            jugador1_nom = textBox1.Text;
            jugador2_nom = textBox2.Text;
            // asignem valor del jugador actual al label que mostra a qui l'hi toca jugar
            label3.Text = jugador1_nom;
            // asignem valor de la marca pertinent al label que mostra el simbol del jugador actual
            label2.Text = "x";
            // asignem variable amb la marca del jugador actual pel funcionament interne de diversos mètodes.
            jugadorActual = "x";

            if (radioButton3.Checked) //per iniciar la jugada 1 si el primer jugador es CPU, fa el primer moviment
            {
                CheckIfCPU(jugadorActual);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TEXTBOX DEL NOM DEL JUGADOR 1, EVENTO: ONCHANGE
            jugador1_nom = textBox1.Text; // si es canvia el nom en mitat del joc, s'actualitza
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // TEXTBOX DEL NOM DEL JUGADOR 2, EVENTO: ONCHANGE
            jugador2_nom = textBox2.Text; // si es canvia el nom en mitat del joc, s'actualitza
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            // BOTÓN DE SALIR
            Application.Exit();
        }

        private void Jugar(string jugador, System.Windows.Forms.Button boto)
        {
            //procediment per verificar si es huma i fer-lo jugar
            // si esta marcat los dos radio buttons
            if (!((radioButton1.Checked || radioButton3.Checked) && (radioButton2.Checked || radioButton4.Checked)))
            {
                MessageBox.Show("No es pot iniciar partida fins triïs el tipus de jugadors: Human || CPU");
            }
            else
            {

                if (jugador == "x") // si el jugador es el primer == x
                {
                    if (radioButton1.Checked)  // si no es cpu
                    {
                        JugarHuman(jugador, boto); // fa jugar al humà
                    }
                }
                else
                {
                    if (radioButton2.Checked) // si no es cpu
                    {
                        JugarHuman(jugador, boto); // fa jugar al humà
                    }
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
                    if (boto.Text == "" && boto.Name != nombreCasillaRetirada) //si la casella esta buida, pot jugar a aquella posicio
                    {
                        jugador1++; // incrementent marques posades
                        boto.Text = jugador; // asignem marca a la casella
                        boto.Update(); // actizamos la casilla
                        CanviJugador(jugador); // invoquem la funcio per canviar jugador
                    }
                }
                else
                {
                    //nomes pot retirar la peça si es propietat seva
                    if (boto.Text == "x")
                    {
                        jugador1--; // restem 1 al nº peces posades
                        boto.Text = ""; // borrem el text del boto
                        boto.Update(); // actualitzem botó 
                        // guardamos el boton editado para que no se pueda colocar en el mismo espacio
                        nombreCasillaRetirada = boto.Name;
                    }
                }
            }
            else
            {
                //en cas que el jugador porti menys de 3 jugades, pot jugar lliurement, sino primer haura de retirar una peça
                if (jugador2 < 3)
                {
                    if (boto.Text == "" && boto.Name != nombreCasillaRetirada) //si la casella esta buida, pot jugar a aquella posicio
                    {
                        jugador2++; // incrementent marques posades
                        boto.Text = jugador; // asignem marca a la casella
                        boto.Update(); // actizamos la casilla
                        CanviJugador(jugador); // invoquem la funcio per canviar jugador
                    }
                }
                else
                {
                    //nomes pot retirar la peça si es propietat seva
                    if (boto.Text == "o")
                    {
                        jugador2--;  // restem 1 al nº peces posades
                        boto.Text = ""; // borrem el text del boto
                        boto.Update(); // actualitzem botó
                        // guardamos el boton editado para que no se pueda colocar en el mismo espacio
                        nombreCasillaRetirada = boto.Name; 
                    }
                }
            }
        }
        
        private void CanviJugador(string jugador)//canvia de jugador i inicia jugada de cpu si convé i executa guanyador
        {
            // Li pasem el jugador actual i fa el canvi de jugador
            // método para cambiar la marca del jugador, se ejecutará al final de cada botón
            if (jugador== "x") // si actualmente es x
            {
                label2.Text = "o"; // cambia la marca que se muestra por pantalla en el form de la marca activa
                label3.Text = jugador2_nom; // cambia el nombre del jugador activo que se muestra en el form
                jugadorActual = "o"; // cambia el jugador actual
            }
            else
            {
                label2.Text = "x"; // cambia la marca que se muestra por pantalla en el form de la marca activa
                label3.Text = jugador1_nom; // cambia el nombre del jugador activo que se muestra en el form
                jugadorActual = "x"; // cambia el jugador actual
            }
            if (finalPartida == false) // mentres no sigui final de partida, executa en bucle a la cpu
            {
                CheckIfCPU(jugadorActual);
            }
        }

        private void CheckIfCPU(string jugador)//juega como CPU si es CPU
        {
            // comprova si es un cpu a qui li toca jugar
            if (radioButton3.Checked && radioButton4.Checked) // si son dos cpus, aplica un tempo per les jugades
            {
                System.Threading.Thread.Sleep(500); // que dormi 0.5 segons per a veure el moviment
            }
            if ((radioButton3.Checked && jugador == "x") || (radioButton4.Checked && jugador == "o"))
            {
                JugarCPU(jugador); // executem funcio de jugar cpu

                CanviJugador(jugador); // canviem jugador
            }
        }

        private void JugarCPU(string jugador)
        {
            //metodo para que la cpu juegue
            if (jugador == "x") // si cpu es x
            {
                if (jugador1 < 3) //si te marques per jugar
                {
                    CasellaRandom(jugador, false); // genera una casella random i marque
                }
                else
                {
                    CasellaRandom(jugador, true); //borrem una casella random
                    CasellaRandom(jugador, false); // fiquem una nova marca a la csella casella
                }
            }
            else // si cpu es o
            {
                if (jugador2 < 3) //si falte per jugar
                {
                    CasellaRandom(jugador, false);// genera una casella random i marque
                }
                else
                {
                    CasellaRandom(jugador, true); //borrem una casella random
                    CasellaRandom(jugador, false); // fiquem una nova marca a la csella casella
                }
            }
        }

        private void CasellaRandom(string jugador, bool borrar)
        {
            // método para que la ia ponga su ficha o la borre, usando un random, comprobamos si esta vacia y ponemos la marca
            // ATRIBUTOS
            Random r = new Random(); // variable random
            Boolean correcto = false; // boleano para indicar si ya ha puesto la casilla
            string numeroRandom;
            System.Windows.Forms.Button buttonRandom; // generamos un objeto del tipo botón

            while (correcto == false) // mientras la marca no este puesta
            {

                numeroRandom = Convert.ToString(r.Next(1, 10));//generamos nuevo numero random entre 1 y 9
                // asignamos un objeto botón con el numeroRandom para generar un botón random 
                buttonRandom = (System.Windows.Forms.Button)this.Controls["button" + numeroRandom];
                // si el boton está vacio y no hay que sobreescribir y no es donde acaba de quitar la marca
                if (buttonRandom.Text == "" && borrar == false && buttonRandom.Name != nombreCasillaRetirada)
                {
                    buttonRandom.Text = jugador; // ponemos la marca
                    buttonRandom.Update(); // actizamos la casilla
                    correcto = true; // salimos del bucle
                    if (jugador == "x") // augmentem el nº de marques
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
                    buttonRandom.Update(); // actizamos la casilla
                    nombreCasillaRetirada = buttonRandom.Name; 
                    if (jugador == "x")// decrementem el nº de marques
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

        private void CheckVictoria(string[] array)
        {
            // iniciem l'objecte form2 per cridar la finestra
            Ganador ventanaGanador = new Ganador();

            // método para saber si hay un 3 en línea, pasando por parámetro el array en el que se acaba de jugar
            if (array[0] == array[1] && array[0] == array[2] && array[0] != "") // si todas las marcas son iguales y no son vacias
            {
                if (jugadorActual == "x")
                {
                    guanyador = jugador1_nom; // guardem el nom del guanyador
                }
                else
                {
                    guanyador = jugador2_nom;
                }

                ventanaGanador.guanyador = guanyador; // pasamos el ganador al form2
                ventanaGanador.Show();// mostramos la ventana de final de partida
                finalPartida = true; // variable per para l'execució en bucle del modo cpu vs cpu
            }
        }

        public void resetejarPartida()
        {
            // método para resetear los valores a 0 para empezar una nueva partida
            // se llama en el botón de resetear partida y al cargar el form del ganador
            // checkeamos que esten los jugadores seleccionados

            //netegem la pantalla
            System.Windows.Forms.Button boton; //generem un objecte boto
            for (int x = 1; x < 10; x++) // recorrem 9 cops, un per cada botó
            {
                boton = (System.Windows.Forms.Button)this.Controls["button" + Convert.ToString(x)]; //agafem cada botó
                boton.Text = ""; // treiem lo text
                boton.Update(); // actualitzem
            }

            for (int i = 0; i < 3; i++)
            {
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
            // treiem el guanyador
            guanyador = "";
            // reiniciel el boolean del final de partida
            finalPartida = false;
        }
    }
}
