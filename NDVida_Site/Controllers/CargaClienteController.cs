using Excel;
using NDVida_Site.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDVida_Site.Controllers
{
    public class CargaClienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CargaCliente
        public ActionResult Index()
        {
            return View(new CargaClienteViewModel());
        }

        // POST: CargaCliente
        [HttpPost]
        public ActionResult Index(CargaClienteViewModel model, HttpPostedFileBase arquivo)
        {
            if (arquivo != null && arquivo.ContentLength > 0 && (arquivo.FileName.EndsWith(".xls") || arquivo.FileName.EndsWith(".xlsx")))
            {
                try
                {

                    if (!db.Empresas.Any(e => e.Codigo == model.CodigoEmpresa))
                    {
                        EmpresaModel novaEmpresa = new EmpresaModel();
                        novaEmpresa.Codigo = model.CodigoEmpresa;
                        db.Empresas.Add(novaEmpresa);
                        db.SaveChanges();

                        var empresa = db.Empresas.SingleOrDefault(e => e.Codigo == model.CodigoEmpresa);

                        CampanhaModel novaCampanha = new CampanhaModel();
                        novaCampanha.Codigo = model.CodigoCampanha;
                        novaCampanha.Descricao = model.CodigoCampanha;
                        novaCampanha.DataCadastro = DateTime.Now;
                        novaCampanha.Ativo = true;
                        novaCampanha.Empresa = db.Empresas.Find(empresa.Id);
                        db.Campanhas.Add(novaCampanha);
                        db.SaveChanges();
                    }


                    //if (db.Empresas.Any(e => e.Codigo == model.CodigoEmpresa))
                    //{

                    Guid arquivoGuid = Guid.NewGuid();
                    string arquivoPath = Path.Combine(Server.MapPath("~/Carga"), arquivoGuid.ToString() + ".xlsx");

                    // Grava arquivo no servidor
                    arquivo.SaveAs(arquivoPath);

                    // Efetua carga
                    model.ListaMensagemProcessamento = EfetuarCargaCliente(model.CodigoEmpresa, arquivoPath);
                    model.CodigoEmpresa = string.Empty;

                    //}
                    //else
                    //{
                    //    model.ListaMensagemProcessamento.Add("ERRO: Empresa não cadastrada");
                    //}

                }
                catch (Exception ex)
                {
                    model.ListaMensagemProcessamento.Add("ERRO:" + ex.Message.ToString());
                }
            }
            else
            {
                model.ListaMensagemProcessamento.Add("Selecione uma planilha para carga");
            }

            return View(model);
        }

        private List<string> EfetuarCargaCliente(string codigoEmpresa, string arquivoPath)
        {
            List<string> mensagens = new List<string>();
            List<PreCadastroClienteModel> lista = new List<PreCadastroClienteModel>();

            FileStream stream = System.IO.File.Open(arquivoPath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            excelReader.Read();

            while (excelReader.Read())
            {

                if (excelReader != null && excelReader[0] != null && excelReader[1] != null && excelReader[2] != null)
                {

                    if (excelReader[0].ToString() == codigoEmpresa)
                    {
                        lista.Add(new PreCadastroClienteModel
                        {
                            Nome = excelReader[1].ToString(),
                            Email = excelReader[2].ToString()
                        });
                    }
                }
                else
                {
                    break;
                }
            }

            excelReader.Close();
            System.IO.File.Delete(arquivoPath);

            var empresa = db.Empresas.SingleOrDefault(e => e.Codigo == codigoEmpresa);

            if (lista.Count > 0)
            {
                int usuariosCadastrado = lista.Count;

                foreach (var item in lista)
                {
                    if (!db.PreCadastroClientes.Any(pc => pc.Email == item.Email && pc.Empresa.Id == empresa.Id))
                    {
                        item.Empresa = db.Empresas.Find(empresa.Id);
                        item.DataCadastro = DateTime.Now;
                        
                        db.PreCadastroClientes.Add(item);
                    }
                    else
                    {
                        usuariosCadastrado = usuariosCadastrado - 1;
                        mensagens.Add(string.Format("O usuário {0}/{1} já está pré-cadastrado na base", item.Nome, item.Email));
                    }
                }

                db.SaveChanges();

                if (usuariosCadastrado > 0)
                {
                    mensagens.Add(string.Format("{0} clientes carregados com sucesso", lista.Count));
                }
            }
            else
            {
                mensagens.Add("Não há usuários na planilha para efetuar carga");
            }

            return mensagens;
        }
    }
}