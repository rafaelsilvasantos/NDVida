using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NDVida_Site.Models
{
    [Table("PreCadastroCliente")]
    public class PreCadastroClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public virtual EmpresaModel Empresa { get; set; }
    }
}