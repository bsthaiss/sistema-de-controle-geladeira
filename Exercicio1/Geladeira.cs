using System;
using System.Collections.Generic;

namespace SistemaGeladeira
{
    public class Geladeira
    {
        public List<Andar> Andares { get; private set; }

        public Geladeira(int numeroAndares, int numeroContainers, int numeroPosicoes)
        {
            Andares = new List<Andar>();

            for (int contador = 0; contador < numeroAndares; contador++)
            {
                Andares.Add(new Andar(numeroContainers, numeroPosicoes));
            }
        }

        public void ListarItens()
        {
            for (int contador = 0; contador < Andares.Count; contador++)
            {
                Console.WriteLine($"Andar {contador + 1}:");
                Andares[contador].ListarItens();
                Console.WriteLine();
            }
        }
    }
}