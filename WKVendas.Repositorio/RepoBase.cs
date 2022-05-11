namespace WKVendas.Repositorio
{
    public class RepoBase
    {
        protected readonly string _strConection;
        public RepoBase()
        {
            _strConection = "Server=localhost;Database=testewk;Uid=root;Pwd=umsa45;";
        }
    }
}
