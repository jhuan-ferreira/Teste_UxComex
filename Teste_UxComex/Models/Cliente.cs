using System.Collections.Generic;

namespace Teste_UxComex.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        public ICollection<Endereco> Endereco { get; set; } = new List<Endereco>();
    }
}
