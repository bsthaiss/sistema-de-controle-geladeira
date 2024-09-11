namespace EstruturaGeladeira
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
    }
}