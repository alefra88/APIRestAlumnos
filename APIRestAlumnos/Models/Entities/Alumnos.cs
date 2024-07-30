using System;
using System.Collections.Generic;

namespace APIRestAlumnos.Models.Entities
{
    public partial class Alumnos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Curp { get; set; } = null!;
        public decimal? SueldoMensual { get; set; }
        public short? IdEstadoOrigen { get; set; }
        public short? IdEstatus { get; set; }
    }
}
