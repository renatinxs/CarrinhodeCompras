using CarrinhodeCompras.Models;
using Newtonsoft.Json;

namespace CarrinhodeCompras.CarrinhoCompra
{
    public class CookieCarrinhoCompra
    {
        //criar uma chave
        private string Key = "Carrinho.Compras";
        private Cookie.Cookie _cookie;

        public CookieCarrinhoCompra(Cookie.Cookie cookie)
        {
            _cookie = cookie;
        }

        public void Salvar(List<Livro> Lista)
        {
            string Valor = JsonConvert.SerializeObject(Lista);
            _cookie.Cadastrar(Key, Valor);
        }

        //consulta
        public List<Livro> Consultar()
        {
            if(_cookie.Existe(Key))
            {
                string valor = _cookie.Consultar(Key);
                return JsonConvert.DeserializeObject<List<Livro>>(valor);
            }
            else
            {
                return new List<Livro>();   
            }
        }

        //cadastrar
        public void Cadastrar(Livro itens)
        {
            List<Livro> Lista;
            if (_cookie.Existe(Key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.CodLivro == itens.CodLivro);

                if (ItemLocalizado == null)
                {
                    Lista.Add(itens);
                }
                else
                {
                    ItemLocalizado.Quantidade = ItemLocalizado.Quantidade + 1;
                }
            }
            else
            {
                Lista = new List<Livro>();
                Lista.Add(itens);
            }
            Salvar(Lista);

        }

        //atualizar
        public void Remover (Livro itens)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.codLivro == itens.codLivro);
            
            if(ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }
        //verifica se existe
        public bool Existe(string Key)
        {
            if (_cookie.Existe(Key))
            {
                return false;
            }
            return true;
        }

        public void RemoverTodos()
        {
            _cookie.Remover(Key);
        }
    }
}
