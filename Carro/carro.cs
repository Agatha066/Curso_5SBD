using System;
using AutoMapper;

public class Carro
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
}

public class CarroViewModel
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
}

public static class MapeamentoCarro
{
    private static readonly IMapper _mapper;

    static MapeamentoCarro()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Carro, CarroViewModel>();
        });

        _mapper = config.CreateMapper();
    }

    public static CarroViewModel MapearParaViewModel(Carro carro)
    {
        return _mapper.Map<CarroViewModel>(carro);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Carro carro = new Carro
        {
            Marca = "Toyota",
            Modelo = "Corolla",
            Ano = 2021
        };

        CarroViewModel carroViewModel = MapeamentoCarro.MapearParaViewModel(carro);

        Console.WriteLine($"Marca: {carroViewModel.Marca}");
        Console.WriteLine($"Modelo: {carroViewModel.Modelo}");
        Console.WriteLine($"Ano: {carroViewModel.Ano}");
    }
}
