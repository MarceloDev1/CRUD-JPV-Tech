using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDPessoas.Models
{
    public class PessoasModel
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public decimal ValorRenda { get; set; }

        public static implicit operator List<object>(PessoasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
