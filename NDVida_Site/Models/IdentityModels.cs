using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NDVida_Site.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfileInfo UserProfileInfo { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("NDVidaConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserProfileInfo> UserProfileInfoes { get; set; }

        public DbSet<EmpresaModel> Empresas { get; set; }

        public DbSet<CampanhaModel> Campanhas { get; set; }

        public DbSet<PreCadastroClienteModel> PreCadastroClientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    [Table("UserProfileInfo")]
    public class UserProfileInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public Genero Genero { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string TelefoneComercial { get; set; }

        public string RamalComercial { get; set; }

        [Required]
        public string TelefoneCelular { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public bool AceitaNewsletterNDVida { get; set; }

        public virtual Endereco EnderecoComercial { get; set; }

        public virtual Endereco EnderecoResidencial { get; set; }

        [Required]
        public bool CadastroWymbeOK { get; set; }

        [Required]
        public int Empr_Id { get; set; }
    }

    public enum Genero
    {
        Masculino = 1,
        Feminino = 2
    }

    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EnderecoCompleto { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public Estado Estado { get; set; }

        [Required]
        public string Pais { get; set; }
    }

    public enum Estado : int
    {
        AC = 1,
        AL = 2,
        AP = 3,
        AM = 4,
        BA = 5,
        CE = 6,
        DF = 7,
        ES = 8,
        GO = 9,
        MA = 10,
        MT = 11,
        MS = 12,
        MG = 13,
        PA = 14,
        PB = 15,
        PR = 16,
        PE = 17,
        PI = 18,
        RJ = 19,
        RN = 20,
        RS = 21,
        RO = 22,
        RR = 23,
        SC = 24,
        SP = 25,
        SE = 26,
        TO = 27,
        Outro = 28
    }
}
