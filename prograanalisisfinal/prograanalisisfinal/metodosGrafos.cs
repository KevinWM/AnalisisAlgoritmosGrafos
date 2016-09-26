using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograAnalisisFinal
{
    class metodosGrafos
    {
        public int rango1 = 1;
        public int rango2 = 25;
        public int distanciaRuta = 1000000;
        static public int cantVertices = 10;
        static public int peso = 1000000;
        static public Arco[,] matrizGrafo = new Arco[cantVertices, cantVertices];
        static public int[,] matrizValores;
        public Vertice primerVertice = new Vertice();
        public static LinkedList<Vertice> grafo = new LinkedList<Vertice>();
        public static LinkedList<Vertice> rutaOptima = new LinkedList<Vertice>();
        public static LinkedList<Arco> arcosVertice = new LinkedList<Arco>();
        public string rutaOptimaText = "";
        private static readonly Random r = new Random();
        private static readonly object syncLock = new object();

        public int asigProbabilistico = 0;
        public int compProbabilistico = 0;

        public int asigGenetico = 0;
        public int compGenetico = 0;

        /// <summary>
        /// Metodo que crea el grafo automaticamente
        /// </summary>
        public void crearGrafo()
        {
            for (int i = 1; i <= cantVertices; i++)
            {
                insertarVertice(i);
            }
            for (int i = 1; i <= cantVertices; i++)
            {
                for (int j = 1; j <= cantVertices; j++)
                {
                    if (i != j)
                    {
                        int distanciaAleatoria = r.Next(rango1, rango2);
                        crearArco(i, j, distanciaAleatoria);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que modifica la distancia a un arco
        /// </summary>
        /// <param name="origen"> punto inicial de la distancia </param>
        /// <param name="destino"> punta fina de la destancia </param>
        /// <param name="distancia"> la nueva distancia </param>
        public void modificarDistancia(int origen, int destino, int distancia)
        {
            Vertice origenV = buscarV(origen);

            for (int i = 0; i < origenV.listArco.Count; i++)
            {
                Arco temA = origenV.listArco.ElementAt<Arco>(i);
                if (temA.destino.numero == destino)
                {
                    temA.distancia = distancia;
                }
            }
        }

        /// <summary>
        /// Inserta un vertice
        /// </summary>
        /// <param name="numero"> Identificador del vertice </param>
        public void insertarVertice(int numero)
        {
            Vertice nuevoVertice = new Vertice();
            nuevoVertice.numero = numero;
            grafo.AddLast(nuevoVertice);
        }

        /// <summary>
        /// Busca un vertice en el grafo
        /// </summary>
        /// <param name="numero"> Vertice a buscar </param>
        /// <returns></returns>
        public Vertice buscarV(int numero) 
        {
            for (int i = 0; i < cantVertices; i++)
            {
                if (grafo.ElementAt<Vertice>(i).numero == numero)
                {
                    return grafo.ElementAt<Vertice>(i);
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo que crea un arco a un vertice
        /// </summary>
        /// <param name="origen"> Punto inicial del arco </param>
        /// <param name="destino"> Punto final del arco </param>
        /// <param name="distancia"> Distancia entre los puntos de inicio y fin </param>
        public void crearArco(int origen, int destino, int distancia)
        {
            Vertice verticeO = buscarV(origen);
            Vertice verticeD = buscarV(destino);
            Arco nuevoArco = new Arco();
            nuevoArco.distancia = distancia;
            nuevoArco.destino = verticeD;

            if (verticeO.listArco == null)
            {
                verticeO.listArco.AddFirst(nuevoArco);
            }
            else
            {
                verticeO.listArco.AddLast(nuevoArco);
            }
        }

        /// <summary>
        /// Metodo que imprime el grafo
        /// </summary>
        /// <returns></returns>
        public string imprimir()
        {
            string grafoRutas = "";

            for (int i = 0; i < cantVertices; i++)
            {
                for (int j = 0; j < grafo.ElementAt<Vertice>(i).listArco.Count; j++)
                {
                    grafoRutas += (grafo.ElementAt<Vertice>(i).numero + " destino: " + grafo.ElementAt<Vertice>(i).listArco.ElementAt<Arco>(j).destino.numero + " distancia " + grafo.ElementAt<Vertice>(i).listArco.ElementAt<Arco>(j).distancia + "\r\n");
                    
                }
            }
            return grafoRutas;
        }

        /// <summary>
        /// Imprime ruta por feromonas
        /// </summary>
        /// <param name="origen"> Punto inicial del arco </param>
        /// <param name="destino"> Punto final del arco</param>
        /// <returns> Retorna la ruta entre los puntos inicial y fin </returns>
        public string imprimirLista(int origen, int destino)
        {
            int max = 1000000;
            int i = 0;
            int j = 0;
            string rutaText = "";

            Vertice temV = buscarV(origen);
            Arco menorFero = null;
            rutaText += temV.numero.ToString() + ", ";

            while (j < cantVertices)
            {
                while (i < temV.listArco.Count)
                {
                    Arco temA = temV.listArco.ElementAt<Arco>(i);
                    if (temA.feromona <= max)
                    {
                        max = temA.feromona;
                        menorFero = temA;
                    }
                    i++;
                } 
                rutaText += menorFero.destino.numero.ToString() + ", ";
                if(menorFero.destino.numero == destino)
                {
                    break;
                }
                temV = menorFero.destino;
                j++;
                i = 0;
                max = 1000000;
            }
            rutaOptimaText = rutaText;
            return rutaOptimaText;
        }

        /// <summary>
        /// Cambia el estado de visitados a false en los arcos
        /// </summary>
        public void limpiar()
        {
            compProbabilistico++;
            for (int i = 0; i < grafo.Count; i++)
            {
                Vertice temV = grafo.ElementAt<Vertice>(i);                     asigProbabilistico += 2;
                compProbabilistico += 2;
                for (int j = 0; j < temV.listArco.Count; j++)
			    {
                    temV.listArco.ElementAt<Arco>(j).visitado = false;          asigProbabilistico++; compProbabilistico++;
			    }
            }
        }

        /// <summary>
        /// Metodo pobabilistico para seleccionar una ruta
        /// </summary>
        /// <param name="temV"></param>
        public void verificarProbabilidad(Vertice temV)
        {
            compProbabilistico++;
            for (int i = 0; i < temV.listArco.Count; i++)                   
            {
                Arco temA = temV.listArco.ElementAt<Arco>(i);
                int numProbabilidad = (rango2 % temA.distancia);                    asigProbabilistico += 3;

                compProbabilistico += 2;
                asigProbabilistico++;
                for (int j = 0; j < numProbabilidad; j++)
                {
                    arcosVertice.AddFirst(temA);                                    asigProbabilistico += 2; compProbabilistico++;
                }
            }
        }

        /// <summary>
        /// Metodo que verifica la ruta y asigna feromonas
        /// </summary>
        /// <param name="ruta"> lista contenedora de una ruta </param>
        /// <param name="distancia"> distancia de la ruta </param>
        public void verificarDistancia(LinkedList<Vertice> ruta, int distancia)
        {
            int seguVert = 1;
            int i = 0;
            string rutaTEXT = "";                                               asigProbabilistico += 3;

            compProbabilistico++;
            if (distancia < distanciaRuta)
            {
                Vertice temV = buscarV(ruta.ElementAt<Vertice>(0).numero);
                rutaTEXT += temV.numero.ToString() + ", ";                      asigProbabilistico += 2;
                compProbabilistico++;
                while (i < temV.listArco.Count)
                {
                    Arco temA = temV.listArco.ElementAt<Arco>(i);               asigProbabilistico++;
                    compProbabilistico += 3;
                    if (seguVert >= ruta.Count)
                    {
                        break;
                    }
                    else if (ruta.ElementAt<Vertice>(seguVert).numero == temA.destino.numero)
                    {
                        temA.feromona += 5;
                        seguVert++;
                        temV = temA.destino;
                        rutaTEXT += temA.destino.numero.ToString() + ", ";
                        i = 0;                                                  asigProbabilistico += 5;
                    }
                    else
                    {
                        i++;                                                    asigProbabilistico++;
                    }
                }
                rutaOptimaText = rutaTEXT;
                ruta.Clear();                                                   asigProbabilistico += 3;
                distanciaRuta = distancia;
            }
        }

        /// <summary>
        /// Metodo que realiza la busqueda de las rutas
        /// </summary>
        /// <param name="origen"> punto inicial de la ruta </param>
        /// <param name="destino"> punto final de la ruta </param>
        /// <param name="cantHormigas"> cantidad de hormigas o pruebas a enviar por diferentes rutas a explorar </param>
        public void algoritmoProbabilistico(Vertice origen, Vertice destino, int cantHormigas)
        {
            int distanciaTotal = 0;
            int numRandom;
            LinkedList <Vertice> ruta = new LinkedList<Vertice>();

            Vertice temO = buscarV(origen.numero);
            Vertice temD = buscarV(destino.numero);                 asigProbabilistico += 3;
            compProbabilistico += 2;
            if ((temO == null) || (temD == null))                   
            {
                return;
            }
            compProbabilistico++;
            for (int i = 0; i < cantHormigas; i++)                  asigProbabilistico += 2;
            {
                Vertice temOri = null;
                temOri = temO;
                ruta.AddFirst(temO);
                asigProbabilistico += 4;
                compProbabilistico++;
                while (true)                                        
                {
                    arcosVertice.Clear();                           asigProbabilistico++;
                    verificarProbabilidad(temOri);
                    lock (syncLock)
                    {
                        numRandom = r.Next(0, arcosVertice.Count);
                    }
                    Arco temA = arcosVertice.ElementAt<Arco>(numRandom);
                    Vertice temV = temA.destino;                                asigProbabilistico += 3;

                    if ((temA.visitado == false))                               compProbabilistico++;
                    {
                        distanciaTotal += temA.distancia;
                        temOri = temV;
                        ruta.AddLast(temOri);
                        temA.visitado = true;                                   asigProbabilistico += 4;
                    }

                    if (temV.numero == destino.numero)                          compProbabilistico++;
                    {
                        ruta.AddLast(destino);
                        break;
                    }
                }
                verificarDistancia(ruta, distanciaTotal);
                ruta.Clear();
                distanciaTotal = 0;                                             asigProbabilistico += 2;
                limpiar();
            }
        }

/*
 ******************************** Algoritmo Genetico ****************************
 */
        /// <summary>
        /// Metodo que agrega el peso a una ruta
        /// </summary>
        /// <param name="ruta"> lista que contiene la ruta </param>
        /// <returns> retorna la ruta </returns>
        int[] agregarPeso(int[] ruta)
        {
            int peso = 0;                                       asigGenetico += 2;
            compGenetico++;
            for (int i = 0; i < ruta.Length - 2; i++)
            {
                peso += matrizValores[ruta[i], ruta[i + 1]];    asigGenetico += 2; compGenetico++;
            }
            ruta[ruta.Length - 1] = peso;
            return ruta;
        }

        /// <summary>
        /// Método que le asigna un peso a cada ruta generada
        /// </summary>
        /// <param name="poblacion">linkedList que sera ordenado</param>
        /// <returns>LinkedList ordenado por peso de forma ascendente</returns>
        LinkedList<int[]> evaluarPoblacion(LinkedList<int[]> poblacion)
        {
            int[] tempValores = new int[(poblacion.ElementAt<int[]>(0).Length)];
            int[] valor1 = new int[(poblacion.ElementAt<int[]>(0).Length)];
            int[] valor2 = new int[(poblacion.ElementAt<int[]>(0).Length)];
            LinkedList<int[]> poblacionEvaluada = new LinkedList<int[]>();                      asigGenetico += 5;

            compGenetico++;
            foreach (var item in poblacion)
            {
                poblacionEvaluada.AddFirst(agregarPeso(item));                                  asigGenetico++;
            }

            compGenetico++;
            asigGenetico++;
            for (int i = 0; i < poblacionEvaluada.Count; i++)
            {
                valor1 = poblacionEvaluada.ElementAt<int[]>(i);                                 asigGenetico += 2;
                compGenetico+=2;
                for (int b = i; b < poblacionEvaluada.Count; b++)
                {
                    valor2 = poblacionEvaluada.ElementAt<int[]>(b);                             asigGenetico += 2;
                    compGenetico += 2;
                    if (valor1[valor1.Length - 1] > valor2[valor2.Length - 1])
                    {
                        tempValores = valor2;
                        poblacionEvaluada.Remove(poblacionEvaluada.ElementAt<int[]>(b));        asigGenetico += 4;
                        poblacionEvaluada.AddFirst(tempValores);
                        i = -1;
                        break;
                    }
                }
            }
            asigGenetico++;
            return poblacionEvaluada;   
        }

        int selecionarParejaAux(int numero, int posicion, LinkedList<int[]> poblacion)
        {
            compGenetico++;
            asigGenetico++;
            for (int i = posicion + 1; i < poblacion.Count - 1; i++)
            {
                compGenetico++;
                asigGenetico++;
                for (int b = 0; b < poblacion.ElementAt<int[]>(i).Length - 2; b++)
                {
                    compGenetico+=2;
                    asigGenetico++;
                    if (poblacion.ElementAt<int[]>(i)[b] == numero)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Selecciona una pareja y la borra de la linkedlist
        /// </summary>
        /// <param name="poblacion">Recibe la poblacion</param>
        /// <returns>Retorna un linkedlist con la pareja</returns>
        LinkedList<int[]> seleccionarPareja(LinkedList<int[]> poblacion)
        {
            LinkedList<int[]> parejasFinal = new LinkedList<int[]>();
            int[] ruta1 = new int[(poblacion.ElementAt<int[]>(0).Length)];
            int[] ruta2 = new int[(poblacion.ElementAt<int[]>(0).Length)];
            int posicion;

            asigGenetico += 3; compGenetico++;
            for (int i = 0; i < poblacion.Count - 1; i++)
            {
                compGenetico+=2;
                asigGenetico++;
                for (int b = 0; b < poblacion.ElementAt<int[]>(i).Length - 2; b++)
                {
                    posicion = selecionarParejaAux(poblacion.ElementAt<int[]>(i)[b], i, poblacion); asigGenetico += 2; compGenetico += 2;
                    if (posicion != -1)
                    {
                        ruta1 = poblacion.ElementAt<int[]>(i);
                        ruta2 = poblacion.ElementAt<int[]>(posicion);
                        parejasFinal.AddFirst(ruta1);
                        parejasFinal.AddFirst(ruta2);
                        poblacion.Remove(poblacion.ElementAt<int[]>(posicion));
                        poblacion.Remove(poblacion.ElementAt<int[]>(i));
                        i = -1;
                        b = poblacion.ElementAt<int[]>(i).Length - 2;                               asigGenetico += 8;
                    }
                }
            }
            return parejasFinal;
        }

        LinkedList<int[]> cruzar(int[] ruta1, int[] ruta2)
        {
            int[] hijo1;
            int[] hijo2;
            LinkedList<int> rutaa = new LinkedList<int>();
            LinkedList<int> rutab = new LinkedList<int>();
            LinkedList<int[]> hijos = new LinkedList<int[]>();
            int posicion1 = 0;
            int posicion2 = 0;                                                  asigGenetico += 6; compGenetico++;
            for (int i = 0; i < ruta1.Length - 2; i++)
            {
                rutaa.AddLast(ruta1[i]);                                        asigGenetico += 2; compGenetico += 2;
                for (int b = 0; b < ruta2.Length - 2; b++)
                {
                    rutab.AddLast(ruta2[b]);                                    asigGenetico += 2; compGenetico += 2;
                    if (ruta1[i] == ruta2[b])
                    {
                        posicion1 = i;
                        posicion2 = b;
                        b = ruta2.Length - 1;
                        i = ruta1.Length - 1;                                   asigGenetico += 4;
                    }
                }
            }
            asigGenetico += 3;
            compGenetico += 3;
            for (int i = posicion1; i < ruta1.Length - 2; i++)
            {
                rutab.AddLast(ruta1[i]);                                        asigGenetico += 2; compGenetico++;
            }
            for (int i = posicion2; i < ruta1.Length - 2; i++)
            {
                rutaa.AddLast(ruta2[i]);                                        asigGenetico += 2; compGenetico++;
            }
            hijo1 = new int[rutaa.Count - 1];
            hijo2 = new int[rutab.Count - 1];

            for (int i = 0; i < rutaa.Count - 1; i++)
            {
                asigGenetico++; compGenetico++;
                //hijo1[i] = rutaa.ElementAt<int>(0)[i];
            }
            return hijos;
        }

        /// <summary>
        /// Método para buscar y cruzar las parejas
        /// </summary>
        /// <param name="poblacion">Recibe las rutas que van a ser cruzadas</param>
        /// <returns>Devuelve la poblacion cruzada</returns>
        LinkedList<int[]> SelecionarCruzar(LinkedList<int[]> poblacion)
        {
            LinkedList<int[]> parejas = new LinkedList<int[]>();
            int[] ruta1 = new int[(poblacion.ElementAt<int[]>(0).Length)];
            int[] ruta2 = new int[(poblacion.ElementAt<int[]>(0).Length)];
            parejas = seleccionarPareja(poblacion);                                 asigGenetico += 5;
            compGenetico++;
            for (int i = 0; i < parejas.Count - 1; i += 2)
            {
                ruta1 = parejas.ElementAt<int[]>(i);
                ruta2 = parejas.ElementAt<int[]>(i + 1);                            asigGenetico += 3; compGenetico++;
                //cruzar(ruta1, ruta2)
            }
            return parejas;
            //seleccionarPareja
        }

        /// <summary>
        /// Método principal del algoritmo genetico
        /// </summary>
        /// <param name="origen">Origen de la ruta</param>
        /// <param name="destino">Fin de la ruta</param>
        /// <param name="cantPoblacionInicial">Cantidad de genes iniciales</param>
        /// <param name="totalVerices">Cantidad de vertices de un Gen</param>
        /// <param name="generaciones">Numero de cruces que se tienen que hacer</param>
        public void algoritmoGenetico(int origen, int destino, int cantPoblacionInicial, int totalVertices, int generaciones)
        {
            LinkedList<int[]> primeraGeneracion = new LinkedList<int[]>();
            LinkedList<int[]> poblacionEvaluada = new LinkedList<int[]>();
            LinkedList<int[]> nuevaGeneracion = new LinkedList<int[]>();                    asigGenetico += 4;
            compGenetico++;
            for (int i = 0; i < cantPoblacionInicial; i++)
            {
                compGenetico++;
                asigGenetico++;
                //primeraGeneracion.AddFirst(generarGenRandom(origen, destino, totalVertices - 2));
            }

            //foreach (var item in primeraGeneracion)
            //{
            //    for (int i = 0; i < item.Length; i++)
            //    {
            //        Console.Write(item[i] + " ");
            //    }
            //    Console.WriteLine();
            //}

            primeraGeneracion = evaluarPoblacion(primeraGeneracion);
            compGenetico++;
            asigGenetico++;
            for (int i = 0; i < generaciones; i++)
            {
                compGenetico++;
                asigGenetico++;
                //cruzar(primeraGeneracion)
            }
        }
    }
}
