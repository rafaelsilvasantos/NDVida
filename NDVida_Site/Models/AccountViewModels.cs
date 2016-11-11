using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NDVida_Site.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email não possui um email válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email não possui um email válido")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "O campo Código da Empresa é obrigatório")]
        [Display(Name = "Código da Empresa")]
        public string CodigoEmpresa { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }


        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email não possui um email válido")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Confirmar Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Confirmar Email não possui um email válido")]
        [Display(Name = "Confirmar Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "O campo Email e o campo Confirmar Email não conferem")]
        public string ConfirmeEmail { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage="Teste")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }


        [Required(ErrorMessage = "O campo Telefone Comercial é obrigatório")]
        [Display(Name = "Telefone Comercial")]
        public string TelefoneComercial { get; set; }

        [Display(Name = "Ramal")]
        public string RamalComercial { get; set; }

        [Required(ErrorMessage = "O campo Telefone Celular é obrigatório")]
        [Display(Name = "Telefone Celular")]
        public string TelefoneCelular { get; set; }

        [Required(ErrorMessage = "O campo Endereço Comercial é obrigatório")]
        [Display(Name ="Endereço Comercial")]
        public string EnderecoComercial { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        [Display(Name = "Cidade Comercial")]
        public string CidadeComercial { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        [Display(Name = "Estado Comercial")]
        public Estado EstadoComercial { get; set; }

        [Required(ErrorMessage = "O campo País é obrigatório")]
        [Display(Name = "País Comercial")]
        public string PaisComercial { get; set; }
        
        [Display(Name = "Endereço Residencial")]
        public string EnderecoResidencial { get; set; }
        
        [Display(Name = "Cidade Residencial")]
        public string CidadeResidencial { get; set; }

        [Display(Name = "Estado Residencial")]
        public Estado EstadoResidencial { get; set; }

        [Display(Name = "País Residencial")]
        public string PaisResidencial { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no mínimo {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "O campo Senha e o campo Confirmar Senha não conferem")]
        public string ConfirmPassword { get; set; }


        [Display(Name ="Aceito o contrato NDVida")]
        [BooleanAttribute(Value = true, ErrorMessage = "É necessário aceitar o contrato NDVida")]
        public bool AceitaContratoNDVida { get; set; }

        public bool AceitaNewsletterNDVida { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no mínimo {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
