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

            for (int i = 0; i < numeroAndares; i++)
            {
                Andares.Add(new Andar(numeroContainers, numeroPosicoes));
            }
        }

        public void ListarItens()
        {
            for (int i = 0; i < Andares.Count; i++)
            {
                Console.WriteLine($"Andar {i + 1}:");
                Andares[i].ListarItens();
                Console.WriteLine();
            }
        }
    }
}