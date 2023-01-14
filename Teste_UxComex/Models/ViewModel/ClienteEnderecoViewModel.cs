using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_UxComex.Models.ViewModel
{
    public class ClienteEnderecoViewModel
    {
        public  Cliente Cliente { get; set; }
        public IEnumerable< Endereco >Endereco { get; set; }
    }
}
