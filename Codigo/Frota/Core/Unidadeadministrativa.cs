﻿namespace Core;

public partial class Unidadeadministrativa
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Cep { get; set; }

    public string? Rua { get; set; }

    public string? Bairro { get; set; }

    public string? Complemento { get; set; }

    public string? Numero { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public float? Latitude { get; set; }

    public float? Longitude { get; set; }

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
