namespace Repository.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string SenhaHash { get; set; }
        public required string SenhaSalt { get; set; }
        public required string UserName { get; set; }
    }
}
