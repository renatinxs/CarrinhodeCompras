using CarrinhodeCompras.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;
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

        public void Cadastrar(Itens item)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into itensEmp values(default, @codEmp, @codLivro)", conexao);

                cmd.Parameters.Add("@codEmp", MySqlDbType.VarChar).Value = item.codEmp;
                cmd.Parameters.Add("@codLivro", MySqlDbType.VarChar).Value = item.codLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
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
