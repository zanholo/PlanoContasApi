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
    public class TipoRepositorio : ITipoRepositorio
    {
        TipoContexto _context;
        public TipoRepositorio(TipoContexto context) //: base(context)
        {
            _context = context;
        }

        public bool InserirTipo(TipoDTO tipoDto)
        {
            TipoEntidade tipo = new TipoEntidade();
            tipo.Descricao = tipoDto.Descricao;

            _context.Add(tipo);
            _context.SaveChanges();
            return true;
        }

        public List<TipoEntidade> ConsultarTipo(int id)
        {
            var listConta = new List<TipoEntidade>();

            if (id == 0)
                listConta = _context.TodosTipos.ToList();
            else
                listConta = _context.TodosTipos.Where(x => x.Id == id).ToList();

            return listConta;
        }
}
}
