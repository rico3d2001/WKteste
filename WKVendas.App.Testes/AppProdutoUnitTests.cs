using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKVendas.AppProduto;
using WKVendas.Dominio;

namespace WKVendas.App.Testes
{
    [TestClass]
    public class AppProdutoUnitTests
    {

        


        [TestMethod]
        public void A_DeveInserirProduto()
        {
            var produto = new Produto()
            {
                IdCategoria = 22,
                Guid = "a10c9dac-54b6-42e3-9366-fa3fe5d71335",
                Nome = "386 16MB RAM",
                Descricao = "Computador muito velho e ultrapadassado",
                Foto = "Foto",
                Preco = 88.5m,
                Data = DateTime.Now
            };
            var appCommandProduto = new AppCommandProduto();
            var resultado = appCommandProduto.Inserir(produto);
            var inseridos = (int)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.AreEqual(inseridos, 1);
            Assert.AreEqual(tipo, 200);
        }

        [TestMethod]
        public void C_DeveSelecionar()
        {
            var appLeituraProduto = new AppQueryProduto();
            var resultado = appLeituraProduto.Obter();
            var dados = (List<Produto>)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.IsNotNull(dados.Find(x => x.Guid == "a10c9dac-54b6-42e3-9366-fa3fe5d71335"));
            Assert.AreEqual(tipo, 200);

        }

        [TestMethod]
        public void D_DeveAtualizarProduto()
        {
            var produto = new Produto()
            {
                IdCategoria = 22,
                Guid = "a10c9dac-54b6-42e3-9366-fa3fe5d71335",
                Nome = "586 32MB RAM",
                Descricao = "Computador muito velho e ultrapadassado, monitor colorido",
                Foto = "Foto",
                Preco = 88.5m,
                Data = DateTime.Now
            };
            var appCommandProduto = new AppCommandProduto();
            var resultado = appCommandProduto.Atualizar(produto);
            var modificados = (int)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.IsFalse(erros.Count > 0 &&
                           erros.Contains("Unable to connect to any of the specified MySQL hosts."));
            Assert.AreEqual(modificados, 1);
            Assert.AreEqual(tipo, 200);

        }

        [TestMethod]
        public void E_DeveApagarProduto()
        {
            var produto = new Produto()
            {
                IdCategoria = 22,
                Guid = "a10c9dac-54b6-42e3-9366-fa3fe5d71335",
                Nome = "586 32MB RAM",
                Descricao = "Computador muito velho e ultrapadassado, monitor colorido",
                Foto = "Foto",
                Preco = 88.5m,
                Data = DateTime.Now
            };
            var appCommandProduto = new AppCommandProduto();
            var resultado = appCommandProduto.Apagar(produto);
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