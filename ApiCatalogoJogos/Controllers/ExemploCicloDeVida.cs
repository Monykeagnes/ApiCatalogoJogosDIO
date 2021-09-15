using System;

namespace ApiCatalogoJogos.Controllers
{
    public class ExemploCicloDeVida : IExemploSingleton, IExemploScoped,IExemploTransient
    {
        private readonly Guid _guid;
        public ExemploCicloDeVida()
        {
            _guid = Guid.NewGuid();
         }
        public Guid iD => _guid;
    }
}
