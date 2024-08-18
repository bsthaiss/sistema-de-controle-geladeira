/*
    Nome: Thais Barbosa dos Santos
*/

using System;

namespace SistemaGeladeira
{
    class Program
    {
        static void Main()
        {
            Geladeira geladeira = new Geladeira(3, 2, 4);

            AdicionarItens(geladeira);
            ListarItens(geladeira);
        }

        static void AdicionarItens(Geladeira geladeira)
        {
            // Andar inicial
            AdicionarItem(geladeira, 0, 0, 0, "Ameixa");
            AdicionarItem(geladeira, 0, 0, 1, "Banana");
            AdicionarItem(geladeira, 0, 0, 2, "Caju");
            AdicionarItem(geladeira, 0, 0, 3, "Damasco");

            AdicionarItem(geladeira, 0, 1, 0, "Alface");
            AdicionarItem(geladeira, 0, 1, 1, "Batata");
            AdicionarItem(geladeira, 0, 1, 2, "Jiló");
            AdicionarItem(geladeira, 0, 1, 3, "Tomate");

            // Primeiro andar
            AdicionarItem(geladeira, 1, 0, 0, "Atum");
            AdicionarItem(geladeira, 1, 0, 1, "Leite");
            AdicionarItem(geladeira, 1, 0, 2, "Manteiga");
            AdicionarItem(geladeira, 1, 0, 3, "Requeijão");

            AdicionarItem(geladeira, 1, 1, 0, "Azeitona");
            AdicionarItem(geladeira, 1, 1, 1, "Ketchup");
            AdicionarItem(geladeira, 1, 1, 2, "Maionese");
            AdicionarItem(geladeira, 1, 1, 3, "Sardinha");

            // Segundo andar
            AdicionarItem(geladeira, 2, 0, 0, "Mortadela");
            AdicionarItem(geladeira, 2, 0, 1, "Ovo");
            AdicionarItem(geladeira, 2, 0, 2, "Presunto");
            AdicionarItem(geladeira, 2, 0, 3, "Queijo");

            AdicionarItem(geladeira, 2, 1, 0, "Bacon");
            AdicionarItem(geladeira, 2, 1, 1, "Bife");
            AdicionarItem(geladeira, 2, 1, 2, "Linguiça");
            AdicionarItem(geladeira, 2, 1, 3, "Salame");
        }

        static void AdicionarItem(Geladeira geladeira, int andar, int container, int posicao, string item)
        {
            geladeira.Andares[andar].AdicionarItem(container, posicao, item);
        }

        static void ListarItens(Geladeira geladeira)
        {
            Console.WriteLine("Itens na geladeira:");
            geladeira.ListarItens();
        }
    }
}