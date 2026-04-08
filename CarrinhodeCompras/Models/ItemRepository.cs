using CarrinhodeCompras.Repository.Contract;
using static CarrinhodeCompras.Models.ItemRepository;
namespace CarrinhodeCompras.Models

{
    public class ItemRepository : IItemRepository
    {
        private readonly string _conexaoMySQL;

        public ItemRepository (IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar (Itens itens)
        {

        }

        public void Atualizar (Itens itens)
        {
         
        }

        public void Excluir (int Id )
        {

        }

        public Itens ObterItens(int Id) 
        {
            Itens itens = new Itens();
            return itens;
        }

        public IEnumerable<Itens> ObterTodosItens()
        {

            List<Itens> itens = new List<Itens>();
            return itens;
        }

    }

   
}
