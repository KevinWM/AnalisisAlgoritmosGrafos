using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograAnalisisFinal
{
    class Arco
    {
        public int distancia;
        public Vertice destino;
        public bool visitado;
        public int feromona = 0;
        
        public Arco()
        {

        }
    }
}
