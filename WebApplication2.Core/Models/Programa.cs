namespace WebApplication2.Core.Models
{
    public class Programa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public int DepártamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
