using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NDVida_Site.Models
{
    public class CargaClienteViewModel
    {
        public CargaClienteViewModel()
        {
            ListaMensagemProcessamento = new List<string>();
        }

        [Required(ErrorMessage = "O código da empresa é obrigatório.")]
        [Display(Name = "Empresa:")]
        public string CodigoEmpresa { get; set; }

        [Required(ErrorMessage = "O código da campanha é obrigatório.")]
        [Display(Name = "Campanha:")]
        public string CodigoCampanha { get; set; }

        [Display(Name = "Mensagens")]
        public List<string> ListaMensagemProcessamento { get; set; }
    }
}