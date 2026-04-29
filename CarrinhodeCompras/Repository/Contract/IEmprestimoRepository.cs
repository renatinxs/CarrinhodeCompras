using CarrinhodeCompras.Models;

namespace CarrinhodeCompras.Repository.Contract
{
    public interface IEmprestimoRepository
    {

        IEnumerable<Emprestimo> ObterTodosItens();

        void Cadastrar(Emprestimo Emprestimo);
        void Atualizar(Emprestimo Emprestimo);

        Emprestimo ObterEmprestimos(int id);

        void buscaIdEmp(Emprestimo Emprestimo);

        void Excluir(int id);
    }
}
