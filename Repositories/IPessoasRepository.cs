
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDPessoas.Models;

namespace CRUDPessoas.Repositories
{
    public interface IPessoasRepository
    {
        void CriarPessoa(PessoasModel pessoa);
        Task<List<PessoasModel>> BuscarPessoa(FiltroPessoasModel filtro);
        Task<PessoasModel> BuscarPessoa(int idPessoa);
        Task<List<PessoasModel>> BuscarPessoas();
        Task ExcluirPessoa(int idPessoa);
        Task SalvarPessoa(PessoasModel modelo);
    }
}