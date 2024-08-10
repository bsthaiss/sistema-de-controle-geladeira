/*
    Nome: Thais Barbosa dos Santos
    Data: 09/08/2024
*/

using System;
class Program
{
    static void Main()
    {
        string[,,] itensGeladeira = new string[3, 2, 4];

        // Andar Inicial
        itensGeladeira[0, 0, 0] = "Ameixa";
        itensGeladeira[0, 0, 1] = "Banana";
        itensGeladeira[0, 0, 2] = "Caju";
        itensGeladeira[0, 0, 3] = "Damasco";

        itensGeladeira[0, 1, 0] = "Alface";
        itensGeladeira[0, 1, 1] = "Batata";
        itensGeladeira[0, 1, 2] = "Jiló";
        itensGeladeira[0, 1, 3] = "Tomate";

        // Primeiro andar
        itensGeladeira[1, 0, 0] = "Atum";
        itensGeladeira[1, 0, 1] = "Leite";
        itensGeladeira[1, 0, 2] = "Manteiga";
        itensGeladeira[1, 0, 3] = "Requeijão";

        itensGeladeira[1, 1, 0] = "Azeitona";
        itensGeladeira[1, 1, 1] = "Ketchup";
        itensGeladeira[1, 1, 2] = "Maionese";
        itensGeladeira[1, 1, 3] = "Sardinha";

        // Segundo andar
        itensGeladeira[2, 0, 0] = "Mortadela";
        itensGeladeira[2, 0, 1] = "Ovo";
        itensGeladeira[2, 0, 2] = "Presunto";
        itensGeladeira[2, 0, 3] = "Queijo";

        itensGeladeira[2, 1, 0] = "Bacon";
        itensGeladeira[2, 1, 1] = "Bife";
        itensGeladeira[2, 1, 2] = "Linguiça";
        itensGeladeira[2, 1, 3] = "Salame";

        listarItens(itensGeladeira);
    }
    
    static void listarItens(string[,,] itensGeladeira)
    {
        for (int a = 0; a < 3; a++)
        {
            for (int c = 0; c < 2; c++) 
            {
                for (int p = 0; p < 4; p++)
                {
                    Console.WriteLine($"Andar: {a}, Container: {c}, Posição: {p}, Item: {itensGeladeira[a, c, p]}");
                }
            }
        }
    }
}