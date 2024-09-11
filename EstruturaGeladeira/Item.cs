using System;
using System.Collections.Generic;

namespace EstruturaGeladeira
{
    public class Item
    {
        public string Nome { get; set; }

        public Item(string nome)
        {
            Nome = nome;
        }

        public void AdicionarItem(List<string> itens, int posicao, string item)
        {
            if (posicao >= 0 && posicao < itens.Count)
            {
                itens[posicao] = item;
                Console.WriteLine($"Item '{item}' adicionado na posição {posicao}.");
            }
            else
            {
                Console.WriteLine("Posição inválida!");
            }
        }

        public void RemoverItem(List<string> itens, int posicao)
        {
            if (posicao >= 0 && posicao < itens.Count)
            {
                if (itens[posicao] != null)
                {
                    Console.WriteLine($"Item '{itens[posicao]}' removido da posição {posicao}.");
                    itens[posicao] = null;
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

        public List<string> ListarItens(List<string> itens)
        {
            List<string> listaItens = new List<string>();

            for (int i = 0; i < itens.Count; i++)
            {
                string item = itens[i] ?? "vazio";
                listaItens.Add($"Posição {i}: {item}");
            }

            return listaItens;
        }
    }
}
