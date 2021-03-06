﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaMedicos.Models
{
    [MetadataType(typeof(UsuariosMetadado))]
    public partial class Usuarios
    {
    }

    public class UsuariosMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o login")]
        [StringLength(30, ErrorMessage = "O Login deve possuir no máximo 30 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        [StringLength(80, ErrorMessage = "A Senha deve possuir no máximo 100 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Email")]
        [StringLength(100, ErrorMessage = "O Email deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }
    }
}