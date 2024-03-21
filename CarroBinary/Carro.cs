using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarroBinary
{
    public class Carro
    {
        public int ID { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public Carro() : this(0, string.Empty, string.Empty) { }

        public Carro(int id, string modelo, string marca)
        {
                ID= id;
            Modelo= modelo;
            Marca= marca;
        }
    }
}
