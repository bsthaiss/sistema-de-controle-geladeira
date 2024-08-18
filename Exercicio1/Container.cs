using System;
using System.Collections.Generic;

namespace SistemaGeladeira
{
    public class Container
    {
        private List<string> Itens { get; set; }

        public Container(int numeroPosicoes)
        {
            Itens = new List<string>(new string[numeroPosicoes]);
        }

        public void AdicionarItem(int posicao, string item)
        {
            if (posicao >= 0 && posicao < Itens.Count)
            {
                if (Itens[posicao] == null)
                {
                    Itens[posicao] = item;
                    Console.WriteLine($"Item '{item}' adicionado na posição {posicao}.");
                }
                else
                {
                    Console.WriteLine("Posição já ocupada!");
                }
            }
            else
            {
                Console.WriteLine("Posição inválida!");
            }
        }

        public void RemoverItem(int posicao)
        {
            if (posicao >= 0 && posicao < Itens.Count)
            {
                if (Itens[posicao] != null)
                {
                    Console.WriteLine($"Item '{Itens[posicao]}' removido da posição {posicao}.");
                    Itens[posicao] = null;
                }
                else
                {
                    Console.WriteLine("Posição já está vazia!");
                }
            }
            else
            {
                Console.WriteLine("Posição inválida!");
            }
        }

        public void ListarItens()
        {
            for (int i = 0; i < Itens.Count; i++)
            {
                string item = Itens[i] ?? "vazio";
                Console.WriteLine($"Posição {i}: {item}");
            }
        }
    }
}