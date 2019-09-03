using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
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

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // buscar os dados no banco e verificar se este email e senha sao validos
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }
    }
}
