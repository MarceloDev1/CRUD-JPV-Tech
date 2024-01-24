using System.Collections.Generic;
using System.Data;
using Dapper;
using CRUDPessoas.Models;
using CRUDPessoas.Data;
using CRUDPessoas.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CRUDPessoas.Repositories
{
    public class PessoasRepository : IPessoasRepository
    {
        private readonly IDbConnection _db;

        public PessoasRepository()
        {
            _db = ConnectionFactory.GetConnection();
        }
        public void CriarPessoa(PessoasModel pessoa)
        {
            _db.Execute("INSERT INTO Pessoas(Nome, CPF, DataNascimento, ValorRenda) VALUES (@Nome, @CPF, @DataNascimento, @ValorRenda)", pessoa);
        }

        
        public async Task<List<PessoasModel>> BuscarPessoa(FiltroPessoasModel filtro)
        {
            var retorno = await _db.QueryAsync<PessoasModel>("SELECT * FROM Pessoas WHERE Nome LIKE @Nome AND CPF LIKE @CPF ", new { Nome = $"%{filtro.Nome}%", CPF = $"%{filtro.CPF}%" });
            return retorno.ToList();
        }
        public async Task<PessoasModel> BuscarPessoa(int idPessoas)
        {
           return await _db.QuerySingleOrDefaultAsync<PessoasModel>("SELECT * FROM Pessoas WHERE PessoaId = @IdPessoas ", new { IdPessoas = idPessoas });            
        }        

        public async Task ExcluirPessoa(int idPessoa)
        {
            await _db.ExecuteAsync("DELETE FROM Pessoas WHERE PessoaId = @idPessoa", new { idPessoa });
        }

        public async Task<List<PessoasModel>> BuscarPessoas()
        {
            var retorno = await _db.QueryAsync<PessoasModel>("SELECT * FROM Pessoas");
            return retorno.ToList();
        }

        public async Task SalvarPessoa(PessoasModel modelo)
        {
            await _db.ExecuteAsync("UPDATE Pessoas SET Nome = @Nome, CPF = @CPF, ValorRenda = @ValorRenda, DataNascimento = @DataNascimento WHERE PessoaId = @PessoaId", new { @PessoaId = modelo.PessoaId, @Nome = modelo.Nome, @CPF = modelo.CPF, @ValorRenda = modelo.ValorRenda, @DataNascimento = modelo.DataNascimento });
        }
    }
}