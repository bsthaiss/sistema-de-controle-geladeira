using System;
using System.Collections.Generic;
using EstruturaGeladeira;

namespace Repository.Models;

public class ItensGeladeira
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Andar { get; set; }

    public int Container { get; set; }

    public int Posicao { get; set; }
}