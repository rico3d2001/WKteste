using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WKVendas.Dominio;

namespace WKVendas.App.Testes
{
    [TestClass]
    public class AppCategoriaUnitTests
    {
        [TestMethod]
        public void DeveConectarOBanco()
        {
            AppLeituraCategoria appLeituraCategoria = new AppLeituraCategoria();    
            var resultado = appLeituraCategoria.GetCategorias();
            var dados = (List<Categoria>)resultado.Result.Dados;
            var tipo = resultado.Result.Tipo;
            var erros = resultado.Result.Erros;
            Assert.AreNotEqual(dados.Count, 0);
            Assert.AreNotEqual(tipo, 500);
            Assert.AreNotEqual(erros[0], "Unable to connect to any of the specified MySQL hosts.");
        }

        [TestMethod]
        public void DeveInserirCategoria()
        {
            Categoria categoria = new Categoria("Computador")
            {
                Descricao = "Desktop de mesa",
                Foto = "Foto"
            };
            AppLeituraCategoria appLeituraCategoria = new AppLeituraCategoria();
            var resultado = appLeituraCategoria.GetCategorias();

        }


    }
}