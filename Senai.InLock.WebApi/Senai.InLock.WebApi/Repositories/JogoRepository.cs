using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                // SELECT * FROM Jogos
                return ctx.Jogos.Include(x => x.Estudio).ToList();
            }
        }

        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // INSERT INTO
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // select com where
                // id da nossa tabela seja igual ao id enviado pelo usuario
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }

        public void Atualizar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // busco a categoria
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogo.JogoId);
                // SET
                JogoBuscado.NomeJogo = jogo.NomeJogo;
                // atualizo no contexto
                ctx.Jogos.Update(JogoBuscado);
                // efetivo no database
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // DELETE FROM Categorias WHERE IdCategoria = @Id;
                // encontrar quem eu quero deletar
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                // remover o fofinho do contexto
                ctx.Jogos.Remove(JogoBuscado);
                // efetivar no banco essa mudança
                ctx.SaveChanges();
            }
        }
    }
}
