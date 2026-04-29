using System.ComponentModel;

namespace CarrinhodeCompras.Models

{
    public class Livro
    {
        public int codLivro { get; set; }
        public object CodLivro { get; internal set; }
        [DisplayName("XYZ")]
        public string nomeLivro { get; set; }
        public string imagemLivro { get; set; }

        public int quantidade { get; set; }
        public int Quantidade { get; internal set; }
    }
}
