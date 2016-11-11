using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NDVida_Site.Models
{
    [Table("Empresa")]
    public class EmpresaModel
    {
        public EmpresaModel()
        {
            PreCadastroClientes = new List<PreCadastroClienteModel>();            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<PreCadastroClienteModel> PreCadastroClientes { get; set; }
        
        public virtual ICollection<CampanhaModel> Campanhas { get; set; }
    }
}