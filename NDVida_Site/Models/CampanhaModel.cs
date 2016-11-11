using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NDVida_Site.Models
{
    [Table("Campanha")]
    public class CampanhaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public virtual EmpresaModel Empresa { get; set; }
    }
}