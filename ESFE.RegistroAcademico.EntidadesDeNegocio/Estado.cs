using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;    
namespace ESFE.RegistroAcademico.EntidadesDeNegocio
{
    public class Estado
    {
        public byte Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(75, ErrorMessage = "El nombre no puede tener más de 75 caracteres")]
        public string Nombre { get; set; }
    }
}
