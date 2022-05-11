using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WKVendas.AppCategoria;
using WKVendas.Dominio;

namespace WKVendas.App.Testes
{
    [TestClass]
    public class AppCategoriaUnitTests
    {
        

        [TestMethod]
        public void A_DeveInserirCategoria()
        {
            var categoria = new Categoria()
            {
                Nome = "Computador",
                Descricao = "Desktop de mesa",
                Foto = "Foto"
            };
            var appMudancaCategorias = new AppCommandCategorias();
            var resultado = appMudancaCategorias.Inserir(categoria);
            var inseridos = (int)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.AreEqual(inseridos, 1);
            Assert.AreEqual(tipo, 200);
        }

        [TestMethod]
        public void B_NAO_DEVE_InserirCategoria_MESMO_NOME()
        {
            var categoria = new Categoria()
            {
                Nome = "Computador",
                Descricao = "Desktop de mesa",
                Foto = "Foto"
            };
            var appMudancaCategorias = new AppCommandCategorias();
            var resultado = appMudancaCategorias.Inserir(categoria);
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsTrue(erros.Count > 0 &&
                           erros.Contains("Duplicate entry 'Computador' for key 'categoria.nome_UNIQUE'"));
            Assert.AreEqual(tipo, 500);
        }

        [TestMethod]
        public void C_DeveSelecionar()
        {
            var appLeituraCategoria = new AppQueryCategoria();
            var resultado = appLeituraCategoria.Obter();
            var dados = (List<Categoria>)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.IsNotNull(dados.Find(x => x.Nome == "Computador"));
            Assert.AreEqual(tipo, 200);
           
        }

        [TestMethod]
        public void D_DeveAtualizarCategoria()
        {
            var categoria = new Categoria()
            {
                Nome = "Desktop",
                Descricao = "Desktop de mesa",
                Foto = "Foto"
            };
            var appMudancaCategorias = new AppCommandCategorias();
            var resultado = appMudancaCategorias.Atualizar("Computador", categoria);
            var modificados = (int)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.AreEqual(modificados, 1);
            Assert.AreEqual(tipo, 200);

        }

        [TestMethod]
        public void E_DeveApagarCategoria()
        {
            var categoria = new Categoria()
            {
                Nome = "Desktop",
                Descricao = "Desktop de mesa",
                Foto = "Foto"
            };
            var appMudancaCategorias = new AppCommandCategorias();
            var resultado = appMudancaCategorias.Apagar(categoria);
            var apagados = (int)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.AreEqual(apagados, 1);
            Assert.AreEqual(tipo, 200);

        }

        


    }
}