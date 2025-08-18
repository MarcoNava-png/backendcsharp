using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/DTOs/PersonaDtos.cs
using System;

namespace WebApplication2.Core.DTOs
{
    public class PersonaCreateDto
    {
        public string Nombre { get; set; } = default!;
        public string ApellidoPaterno { get; set; } = default!;
        public string ApellidoMaterno { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }

        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }

        public int PersonaGeneroId { get; set; }
        public string? UserId { get; set; }
        public int? PersonaEstadoCivilId { get; set; }
        public int? DireccionId { get; set; }
    }

    public class PersonaUpdateDto
    {
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }

        public int? PersonaGeneroId { get; set; }
        public string? UserId { get; set; }
        public int? PersonaEstadoCivilId { get; set; }
        public int? DireccionId { get; set; }
    }

    public class PersonaViewDto
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; } = default!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? UserId { get; set; }

        public bool EsProfesor { get; set; }
        public bool EsEstudiante { get; set; }
        public bool EsAdministrativo { get; set; }
    }

    public class ProfesorCreateDto
    {
        public int? DepartamentoId { get; set; }
    }

    public class AdministrativoCreateDto
    {
        public string? Puesto { get; set; }
    }
}
