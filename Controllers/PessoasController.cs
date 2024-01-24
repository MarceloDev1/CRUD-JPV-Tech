using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using CRUDPessoas.Models;
using CRUDPessoas.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace CRUDPessoas.Controllers
{
    public class PessoasController : Controller
    {
        private IPessoasRepository _repositorio;
        public PessoasController(IPessoasRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var listaPessoas = await BuscarPessoas();
            return View("ListarPessoas", listaPessoas);
        }

        public async Task<List<PessoasModel>> BuscarPessoas()
        {
            var listaPessoas = new List<PessoasModel>();
            listaPessoas = await _repositorio.BuscarPessoas();
            return listaPessoas;
        }

        [HttpPost]
        public async Task<ActionResult> BuscarPessoa(FiltroPessoasModel filtro)
        {
            filtro.ListaPessoas = await _repositorio.BuscarPessoa(filtro);
            return View("ListarPessoas", filtro);
        }

        [HttpGet]
        public IActionResult CadastrarPessoas()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarPessoa(PessoasModel pessoa)
        {
            _repositorio.CriarPessoa(pessoa);
            var modelo = new FiltroPessoasModel();
            return View("ListarPessoas", modelo);
        }        

        [HttpGet]
        public async Task<ActionResult> ListarPessoas(FiltroPessoasModel filtroPessoasModel)
        {
            filtroPessoasModel.ListaPessoas = await BuscarPessoas();
            return View(filtroPessoasModel);
        }        

        [HttpGet]
        public async Task<ActionResult> EditarPessoa(int idPessoa)
        {
            var modelo = await _repositorio.BuscarPessoa(idPessoa);            
            return View("EditarPessoas", modelo);
        }
        [HttpPost]
        public async Task<ActionResult> EditarPessoa(PessoasModel modelo)
        {
            await _repositorio.SalvarPessoa(modelo);
            return RedirectToAction("EditarPessoa", new { @idPessoa = modelo.PessoaId });
        }

        [HttpGet]
        public async Task<ActionResult> ExcluirPessoa(int idPessoa)
        {
            await _repositorio.ExcluirPessoa(idPessoa);
            return RedirectToAction("ListarPessoas");
        }        
    }
}
