using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
          {Guid.Parse("0ca314-9252-952"), new Jogo {Id= Guid.Parse("0vb12-0258-265-256"), Nome = "FICA 21", Produtora = "EA", Preco =200 } },
          {Guid.Parse("0ca314-9252-952"), new Jogo {Id= Guid.Parse("0vb12-0258-265-256"), Nome = "FICA 20", Produtora = "EA", Preco =190 } },
          {Guid.Parse("0ca314-9252-952"), new Jogo {Id= Guid.Parse("0vb12-0258-265-256"), Nome = "FICA 19", Produtora = "EA", Preco =180 } },
          {Guid.Parse("0ca314-9252-952"), new Jogo {Id= Guid.Parse("0vb12-0258-265-256"), Nome = "FICA 18", Produtora = "EA", Preco =170 } },
          {Guid.Parse("0ca314-9252-952"), new Jogo {Id= Guid.Parse("0vb12-0258-265-256"), Nome = "Street Fighter V", Produtora = "CAPCOM", Preco =80 } },
          {Guid.Parse("0ca314-9252-952"), new Jogo {Id= Guid.Parse("0vb12-0258-265-256"), Nome = "GTA V", Produtora = "ROCKSTAR", Preco =190 } },
          };
public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;
            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(String nome , string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }
            return Task.FromResult(retorno);
        }

        public Task Inserir (Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //fechar conexão com o banco
        }
    }
}
