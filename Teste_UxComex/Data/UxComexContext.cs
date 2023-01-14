using Microsoft.EntityFrameworkCore;
using Teste_UxComex.Models;

namespace Teste_UxComex.Data
{
    public class UxComexContext :DbContext
    {
        public UxComexContext(DbContextOptions<UxComexContext> options)
            :base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
