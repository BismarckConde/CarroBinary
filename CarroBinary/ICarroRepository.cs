using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarroBinary
{
    public interface ICarroRepository
    {
      
        IEnumerable<Carro> GetAll();
        void Agregar(Carro carro );
        void Actualizar(Carro carro);
        void Borrar(int ID);
    }
}
