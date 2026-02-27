using System.ComponentModel.DataAnnotations;

namespace BibliotecaApp.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        public int AnoPublicacao { get; set; }
    }
}