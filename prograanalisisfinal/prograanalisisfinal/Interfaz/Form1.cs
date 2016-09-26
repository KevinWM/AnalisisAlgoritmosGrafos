using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrograAnalisisFinal
{

    public partial class Form1 : Form
    {
        public string grafoTex = "";

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            metodosGrafos grafo = new metodosGrafos();
            grafo.crearGrafo();
            grafoTex = grafo.imprimir();
            richTextBox1.Text = grafoTex;
        }

        private void BTNrutaAlgoritmoGenetico_Click(object sender, EventArgs e)
        {
            if ((origentextBox.Text != "") && (destinotextBox.Text != ""))
            {
                
            }
            else
            {

            }
        }

        private void BTNalgoritmoProbabilistico_Click(object sender, EventArgs e)
        {
            string medidas = "";
            if ((origentextBox.Text != "") && (destinotextBox.Text != "") && (cantidaExploradorastextBox.Text != ""))
            {
                int origenNum = int.Parse(origentextBox.Text);
                int destinoNum = int.Parse(destinotextBox.Text);
                int canExploHormiNum = int.Parse(cantidaExploradorastextBox.Text);

                metodosGrafos grafo = new metodosGrafos();
                Vertice origen = grafo.buscarV(origenNum);
                Vertice destino = grafo.buscarV(destinoNum);

                grafo.algoritmoProbabilistico(origen, destino, canExploHormiNum);
                richTextBox2.Text = grafo.rutaOptimaText;
                richTextBox2.Text += medidas += " Asig: " + grafo.asigProbabilistico.ToString() +
                    " Compar: " + grafo.compProbabilistico.ToString();

            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((origentextBox.Text != "") && (destinotextBox.Text != "") && (nuevaDistanciatextBox.Text != ""))
            {
                metodosGrafos grafo = new metodosGrafos();
                grafo.modificarDistancia(int.Parse(origentextBox.Text), int.Parse(destinotextBox.Text), int.Parse(nuevaDistanciatextBox.Text));
                richTextBox1.Clear();
                grafoTex = grafo.imprimir();
                richTextBox1.Text = grafoTex;
            }
        }
    }
}
