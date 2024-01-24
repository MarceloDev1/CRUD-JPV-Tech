using CRUDPessoas.Models;
using System;
using System.Collections.Generic;

namespace CRUDPessoas.Models
{
    public class FiltroPessoasModel
    {
        public FiltroPessoasModel()
        {
            ListaPessoas = new List<PessoasModel>();
        }
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal ValorRenda { get; set; }
        public List<PessoasModel> ListaPessoas { get; set; }
    }
}