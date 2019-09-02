using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuarios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                // SELECT * FROM Usuarios
                return ctx.Usuarios.ToList();
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // INSERT INTO
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }
}
