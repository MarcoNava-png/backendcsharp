namespace WebApplication2.Core.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public int? CodigoPostalId { get; set; }   // FK INT? -> CodigoPostal.Id
        //public CodigoPostal? CodigoPostal { get; set; }
        public ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}
