using CarroBinary;

string filePath = "Carros.bin";

ICarroRepository carroRepository = new CarroBinaryRepository(filePath);


carroRepository.Agregar(new Carro { ID = 1, Marca = "BMW", Modelo = "Serie 5" });
carroRepository.Agregar(new Carro { ID = 2, Marca = "Dacia", Modelo = "Logan" });
carroRepository.Agregar(new Carro { ID = 3, Marca = "Ferrari", Modelo = "F 12" });


Console.WriteLine($"Datos de carros guardados en {filePath}");
foreach (Carro carro in carroRepository.GetAll())
    Console.WriteLine($"Id: {carro.ID}, Modelo: {carro.Modelo}, Marca: {carro.Marca}");