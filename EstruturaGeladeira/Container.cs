namespace EstruturaGeladeira
{
    public class Container
    {
        public List<string> Itens { get; set; }

        public Container(int numeroPosicoes)
        {
            Itens = new List<string>(new string[numeroPosicoes]);
        }
    }
}