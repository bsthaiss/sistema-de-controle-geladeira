using System;
using System.Collections.Generic;

namespace SistemaGeladeira
{
    public class Andar
    {
        public List<Container> Containers { get; private set; }

        public Andar(int numeroContainers, int numeroPosicoes)
        {
            Containers = new List<Container>();

            for (int i = 0; i < numeroContainers; i++)
            {
                Containers.Add(new Container(numeroPosicoes));
            }
        }

        public void AdicionarItem(int containerIndex, int posicao, string item)
        {
            if (containerIndex >= 0 && containerIndex < Containers.Count)
            {
                Containers[containerIndex].AdicionarItem(posicao, item);
            }
            else
            {
                Console.WriteLine("Container inválido!");
            }
        }

        public void RemoverItem(int containerIndex, int posicao)
        {
            if (containerIndex >= 0 && containerIndex < Containers.Count)
            {
                Containers[containerIndex].RemoverItem(posicao);
            }
            else
            {
                Console.WriteLine("Container inválido!");
            }
        }

        public void ListarItens()
        {
            for (int i = 0; i < Containers.Count; i++)
            {
                Console.WriteLine($"Container {i + 1}:");
                Containers[i].ListarItens();
            }
        }
    }
}