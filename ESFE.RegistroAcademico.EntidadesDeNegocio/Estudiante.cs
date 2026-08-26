using System;
using System.Collections.Generic;
using System.Text;

namespace ESFE.RegistroAcademico.EntidadesDeNegocio
{
    public class Estudiante
    {
        public int Id { get; set; }
        public Int16 IdCarrera { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
