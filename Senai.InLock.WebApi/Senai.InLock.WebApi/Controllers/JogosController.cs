﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository JogoRepository = new JogoRepository();

        [Authorize(Roles = "ADMINISTRADOR, CLIENTE")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(JogoRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            try
            {
                JogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu algum erro :(" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogos Jogo = JogoRepository.BuscarPorId(id);
            if (Jogo == null)
                return NotFound();
            return Ok(Jogo);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Jogos jogo)
        {
            jogo.JogoId = id;
            JogoRepository.Alterar(jogo);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            JogoRepository.Deletar(id);
            return Ok();
        }
    }
}