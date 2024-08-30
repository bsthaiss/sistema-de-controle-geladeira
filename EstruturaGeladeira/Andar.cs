namespace EstruturaGeladeira
{
    public class Andar
    {
        public List<Container> Containers { get; private set; }

        public Andar(int numeroContainers, int numeroPosicoes)
        {
            Containers = new List<Container>();

            for (int contador = 0; contador < numeroContainers; contador++)
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

        public List<string> ListarItens()
        {
            List<string> itens = new List<string>();


            for (int contador = 0; contador < Containers.Count; contador++)
            {
                itens.Add($"Container {contador + 1}:");
                itens.AddRange(Containers[contador].ListarItens());
            }

            return itens;
        }
    }
}