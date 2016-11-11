using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NDVida_Site.Models
{
    public class RegistrarViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Confirmar Email")]
        [Compare("Email", ErrorMessage = "O Email e a Confirmação do Email não estão iguais")]
        public string ConfirmEmail { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "Telefone Comercial")]
        public string TelefoneComercial { get; set; }

        [Display(Name = "Ramal")]
        public string RamalComercial { get; set; }

        [Required]
        [Display(Name = "Telefone Celular")]
        public string TelefoneCelular { get; set; }

        [Required]
        [Display(Name = "Rua")]
        public string LogradouroComercial { get; set; }

        [Required]
        [Display(Name = "Número")]
        public string NumeroComercial { get; set; }

        [Display(Name = "Complemento")]
        public string ComplementoComercial { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string CidadeComercial { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string EstadoComercial { get; set; }

        [Required]
        [Display(Name = "País")]
        public string PaisComercial { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string CepComercial { get; set; }

        [Display(Name = "Rua")]
        public string LogradouroResidencial { get; set; }

        [Display(Name = "Número")]
        public string NumeroResidencial { get; set; }

        [Display(Name = "Complemento")]
        public string ComplementoResidencial { get; set; }

        [Display(Name = "Cidade")]
        public string CidadeResidencial { get; set; }

        [Display(Name = "Estado")]
        public string EstadoResidencial { get; set; }

        [Display(Name = "País")]
        public string PaisResidencial { get; set; }

        [Display(Name = "CEP")]
        public string CepResidencial { get; set; }

        [Display(Name = "Aceito o contrato NDVida")]
        [Required(ErrorMessage = "É necessário aceitar o contrato NDVida")]
        public bool AceitaContratoNDVida { get; set; }
    }
}