using Microsoft.Extensions.DependencyInjection;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.IRepositorios;
using PlanoContas.Domain.IServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Application.Serviços
{
    public class ServicoTipo : IServicoTipo
    {
        private readonly IServiceProvider _serviceProvider;
        private ITipoRepositorio _tipoRepositorio;


        public ServicoTipo(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _tipoRepositorio = serviceProvider.GetRequiredService<ITipoRepositorio>();
        }
        

        public bool inserirTipo(TipoDTO tipo)
        {
            var teste = _tipoRepositorio.InserirTipo(tipo);
            return true;
        }
        

        public List<TipoDTO> listarTipos()
        {
            var consultaTipo = _tipoRepositorio.ConsultarTipo(0);

            List<TipoDTO> listaTipoDTO = new List<TipoDTO>();

            foreach (var tipo in consultaTipo)
            {
                TipoDTO TipoDTO = new TipoDTO();

                TipoDTO.Descricao = tipo.Descricao;
                TipoDTO.Id = tipo.Id;
                listaTipoDTO.Add(TipoDTO);
            }

            return listaTipoDTO;
        }
    }
}
