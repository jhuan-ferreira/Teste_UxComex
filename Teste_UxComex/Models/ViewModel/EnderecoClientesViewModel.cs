using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_UxComex.Models.ViewModel
{
    public class EnderecoClientesViewModel
    {
        public ICollection <Cliente> Cliente { get; set; }
        public Endereco Endereco { get; set; }
    }
}
