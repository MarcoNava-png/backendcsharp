namespace WebApplication2.Core.Requests.Estudiante
{
    public class EstudianteSignupRequest
    {
        public string Matricula { get; set; }
        public Guid PersonaId { get; set; }
        public int NivelEducativoId { get; set; }
    }
}
