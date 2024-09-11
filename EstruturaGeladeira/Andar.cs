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
    }
}