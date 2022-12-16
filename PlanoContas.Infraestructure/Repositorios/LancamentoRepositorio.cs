using PlanoContas.Domain.DTO;
using PlanoContas.Domain.Entidade;
using PlanoContas.Domain.IRepositorios;
using PlanoContas.Infraestructure.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Infraestructure.Repositorios
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        LancamentoContexto _context;

        public LancamentoRepositorio(LancamentoContexto context) //: base(context)
        {
            _context = context;
        }

        public List<LancamentoEntidade> ConsultarLancamentos(int id)
        {
            var listLancamentos = new List<LancamentoEntidade>();

            if (id == 0)
                listLancamentos = _context.TodosLancamentos.ToList();
            //else
                //listLancamentos = _context.Find(  id).ToList();

            return listLancamentos;
        }

        public bool InserirLancamento(LancamentoDTO lancamento)
        {
            LancamentoEntidade lancamentoEntidade = new LancamentoEntidade();
            lancamentoEntidade.Descricao = lancamento.Descricao;
            lancamentoEntidade.AceitaLancamentos = lancamento.AceitaLancamentos;
            lancamentoEntidade.Codigo = lancamento.Codigo;  
            lancamentoEntidade.Tipo = lancamento.Tipo;  

            _context.Add(lancamentoEntidade);

            _context.SaveChanges();

            return true;
        }

        public bool InserirSubLancamento(SubLancamentoDTO lancamento)
        {
            throw new NotImplementedException();
        }
    }
}
