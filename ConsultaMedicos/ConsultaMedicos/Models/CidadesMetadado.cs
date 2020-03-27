using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaMedicos.Models
{
    [MetadataType(typeof(CidadesMetadado))]
    public partial class Cidades
    {
    }

    public class CidadesMetadado
    {
        [Required(ErrorMessage ="Favor informar o nome")]
        [StringLength(100, ErrorMessage ="O nome não pode ultrapassar 100 caracteres")]
        public string Nome { get; set; }
    }
}