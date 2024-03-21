using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarroBinary
{
    public class CarroBinaryRepository : ICarroRepository
    {
        private string _filePath;

        public CarroBinaryRepository(string filePath)
        {
            _filePath = filePath;
        }
        public void Actualizar(Carro carro)
        {
            List<Carro> carros = GetAll().ToList();
            int index = carros.FindIndex(c => c.ID == carro.ID);
            if (index != -1)
            {
                carros[index] = carro;
                GuardarCarro(carros);
            }
            else
            {
                throw new ArgumentException("Carro no encontrado");
            }
        }

        public void Agregar(Carro carro)
        {
            List<Carro> carros = GetAll().ToList();
            carro.ID = carros.Count > 0 ? carros.Max(c => c.ID) + 1 : 1;
            carros.Add(carro);

            GuardarCarro(carros);
        }
        private void GuardarCarro(List<Carro> carros)
        {
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Create))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (Carro carro in carros)
                    {
                        bw.Write(carro.ID);
                        bw.Write(carro.Modelo);
                        bw.Write(carro.Marca);
                    }

                    bw.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los carros {ex.Message}");
            }
        }

        public void Borrar(int id)
        {
            List<Carro> carros = GetAll().ToList();
            carros.RemoveAll(c =>c.ID == id);
            GuardarCarro(carros);
        }

        public IEnumerable<Carro> GetAll()
        {
            if (!File.Exists(_filePath))
                return Enumerable.Empty<Carro>();

            List<Carro> carro = new List<Carro>();

            try
            {
                using (FileStream fs = new FileStream(_filePath,
                        FileMode.Open))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        int id = br.ReadInt32();
                        string modelo = br.ReadString();
                        string marca = br.ReadString();
                       carro.Add(new Carro(id, modelo, marca));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer carros : {ex.Message}");
            }

            return carro;
        }
    }
}
