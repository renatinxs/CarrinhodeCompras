using CarrinhodeCompras.GerenciaArquivos;
using CarrinhodeCompras.Models;
using CarrinhodeCompras.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CarrinhodeCompras.Controllers
{
    public class LivrosController : Controller
    {
        private ILivroRepository _livroRepository;
        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return View();
              

            
        }

     
        public IActionResult CadLivro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadLivro(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return View();



        }
    }
}
