using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_InLock;User Id=sa;Pwd=132;";

        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                // SELECT * FROM Estudios
                return ctx.Estudios.ToList();
            }
        }

        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // INSERT INTO
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // select com where
                // id da nossa tabela seja igual ao id enviado pelo usuario
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }

        public void Alterar(Estudios estudio)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE Estudios SET NomeEstudio = @NomeEstudio WHERE EstudioId = @EstudioId";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@EstudioId", estudio.EstudioId);
                cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // DELETE FROM Estudios WHERE EstudioId = @Id;
                // encontrar quem eu quero deletar
                Estudios EstudioBuscado = ctx.Estudios.Find(id);
                // remover o fofinho do contexto
                ctx.Estudios.Remove(EstudioBuscado);
                // efetivar no banco essa mudança
                ctx.SaveChanges();
            }
        }
    }
}
