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
    public class ContaRepositorio : IContaRepositorio
    {
        ContaContexto _context;

        public ContaRepositorio(ContaContexto context) //: base(context)
        {
            _context = context;
        }

        public List<ContaEntidade> ConsultarContas(int id)
        {
            var listContas = new List<ContaEntidade>();

            if (id == 0)
                listContas = _context.TodasContas.Where(x => x.Ativo).OrderBy(x => x.Codigo).ToList();
            else
                listContas = _context.TodasContas.Where(x => x.Tipo == id && x.Ativo).OrderBy(x => Convert.ToDecimal(x.Codigo)).ToList();

            return listContas;
        }

        public bool InserirConta(ContaDTO conta)
        {
            ContaEntidade contaEntidade = new ContaEntidade();
            contaEntidade.Descricao = conta.Descricao;
            contaEntidade.AceitaLancamentos = conta.AceitaLancamentos;
            contaEntidade.Codigo = conta.Tipo.ToString();  
            contaEntidade.Tipo = conta.Tipo;
            contaEntidade.Ativo = true; 

            _context.Add(contaEntidade);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateConta(ContaDTO conta)
        {
            ContaEntidade contaEntidade = new ContaEntidade();
            contaEntidade.Descricao = conta.Descricao;
            contaEntidade.AceitaLancamentos = conta.AceitaLancamentos;
            contaEntidade.Codigo = conta.Tipo.ToString();
            contaEntidade.Tipo = conta.Tipo;
            contaEntidade.Ativo = conta.Ativo;

            _context.Update(contaEntidade);
            _context.SaveChanges();

            return true;
        }

        public bool InserirSubConta(ContaSubDTO conta)
        {
            ContaEntidade contaEntidade = new ContaEntidade();
            contaEntidade.Descricao = conta.Descricao;
            contaEntidade.AceitaLancamentos = conta.AceitaLancamentos;
            contaEntidade.Codigo = conta.Codigo.ToString();
            contaEntidade.Tipo = conta.Tipo;
            contaEntidade.IdPai = conta.IdContaPai;

            _context.Add(contaEntidade);

            _context.SaveChanges();

            return true;

        }
    }
}
