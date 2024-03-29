﻿using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_InLock;User Id=sa;Pwd=132;";

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
             
        public void Alterar(Jogos jogo)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE Jogos SET NomeJogo = @NomeJogo WHERE JogoId = @JogoId";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@JogoId", jogo.JogoId);
                cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // DELETE FROM Jogos WHERE IdCategoria = @Id;
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
