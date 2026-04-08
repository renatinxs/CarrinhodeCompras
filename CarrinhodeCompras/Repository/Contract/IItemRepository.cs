using CarrinhodeCompras.Models;
namespace CarrinhodeCompras.Repository.Contract
{
    public interface IItemRepository 
    {
        //CRUD

        IEnumerable<Itens> ObterTodosItens();

        void Cadastrar(Itens itens);
        void Atualizar(Itens itens);

        Itens ObterItens(int id);

        void Excluir(int id);
    }
}
