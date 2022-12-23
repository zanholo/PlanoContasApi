using Microsoft.Extensions.DependencyInjection;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.Entidade;
using PlanoContas.Domain.IRepositorios;
using PlanoContas.Domain.IServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Application.Serviços
{
    public class ServicoConta : IServicoConta
    {
        private readonly IServiceProvider _serviceProvider;
        private IContaRepositorio _contaRepositorio;
        private ITipoRepositorio _tipoRepositorio;


        public ServicoConta(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _contaRepositorio = serviceProvider.GetRequiredService<IContaRepositorio>();
            _tipoRepositorio = serviceProvider.GetRequiredService<ITipoRepositorio>();
        }

        /// <summary>
        /// Busca o proximo Sequencial
        /// </summary>
        /// <param name="id">Id do Tipo</param>
        /// <returns>String contendo o proximo sequencial desse tipo </returns>
        public string buscarProximoSequencial(int id)
        {
            var consultaConta = _contaRepositorio.ConsultarContas(id);

            if (consultaConta.Count() == 0)
                return "";
            var contaMaior = consultaConta.OrderByDescending(x => x.Codigo).First();
                        
            return proximoSequencial(contaMaior.Codigo.ToString());            
        }

        /// <summary>
        /// Trazer todos as Contas Gravadas
        /// </summary>
        /// <returns>Um List de ContaDTO contendo todos as Contas</returns>
        public List<ContaPaiFilhoDTO> listarContas()
        {
            var consultaContas = _contaRepositorio.ConsultarContas(0);
            var listTipo = _tipoRepositorio.ConsultarTipo(0);

            var listContasPaisConfigurados = consultaContas.Where(x => x.IdPai == 0).ToList();

            List<ContaPaiFilhoDTO> listContaPai = new List<ContaPaiFilhoDTO>();
            List<ContaPaiFilhoDTO> listContaFilho = new List<ContaPaiFilhoDTO>();

            ContaPaiFilhoDTO conta = new ContaPaiFilhoDTO();

            foreach (var contaPai in listContasPaisConfigurados)
            {
                conta = new ContaPaiFilhoDTO();
                conta.AceitaLancamentos = contaPai.AceitaLancamentos;
                conta.Descricao = contaPai.Descricao;
                conta.Codigo = contaPai.Codigo;
                conta.Tipo = contaPai.Tipo;
                conta.Id = contaPai.Id;
                conta.IdPai = contaPai.IdPai;
                conta.listContaFilho = new List<ContaPaiFilhoDTO>();

                var listContasFilhosConfigurados = consultaContas.Where(x => x.IdPai == contaPai.Id).ToList();
                foreach (var contaFilho in listContasFilhosConfigurados)
                {
                    ContaPaiFilhoDTO filho = new ContaPaiFilhoDTO();
                    filho.AceitaLancamentos = contaFilho.AceitaLancamentos;
                    filho.Descricao = contaFilho.Descricao;
                    filho.Codigo = contaFilho.Codigo;
                    filho.Id = contaFilho.Id;
                    filho.IdPai = contaFilho.IdPai;
                    filho.Tipo = contaFilho.Tipo;

                    listContaFilho.Add(filho);

                    conta.listContaFilho.Add(filho);
                }
                listContaPai.Add(conta);
            }

            return listContaPai;
        }

        /// <summary>
        /// Excluir uma conta logicamente
        /// </summary>
        /// <returns>Excluir uma conta logicamente</returns>
        public bool excluirConta(int id)
        {
            var consultaContas = _contaRepositorio.ConsultarContas(id);

            consultaContas.First().Ativo = true;

            _contaRepositorio.UpdateConta(consultaContas.First());

            return true;
        }

        /// <summary>
        /// Insere uma Conta Pai
        /// </summary>
        /// <param name="conta"></param>
        /// <returns>True, caso inserido com sucesso, false caso ja exista um configurado</returns>
        public bool inserirConta(ContaDTO conta)
        {
            validaContaMesmoTipo(conta.Tipo);

            validaExistenciaTipo(conta.Tipo);

            _contaRepositorio.InserirConta(conta);
            return true;
        }

        /// <summary>
        /// Insere uma Conta filho, Conta
        /// </summary>
        /// <param name="subConta"></param>
        /// <returns></returns>
        public bool InserirSubConta(ContaSubDTO subConta)
        {
            if (!this.Validações(subConta))
                return false;

            _contaRepositorio.InserirSubConta(subConta);
            return true;
        }

        /* Tratamentos do Sistema*/
        private bool Validações(ContaSubDTO subConta)
        {
            var result = _contaRepositorio.ConsultarContas(subConta.IdContaPai);

            //Não existe Pai
            if (!result.Any())
                throw new Exception("Pai não encontrado");

            //Conta que aceita lancamentos não pode ter filhos
            if (result.First().AceitaLancamentos)
                throw new Exception("Conta que aceita lancamentos não pode ter filhos.");


            //Tipo do Pai diferente do que enviado no Payload
            if (result.First().Tipo != subConta.Tipo)
                throw new Exception(@"O tipo do pai é diferente do enviado." + @"\n Pai: " + result.First().Tipo + ", Enviado:" + subConta.Tipo);

            //Codigo Enviado já utilizado
            if (result.ToList().Any(x => x.Codigo == subConta.Codigo))
                throw new Exception(@"Já existe um Codigo configurado para essa conta");

            var split = subConta.Codigo.Split(".");
            //Codigo Maximo que é aceitavel
            if (Convert.ToInt32(split[split.Length - 1]) > 999)
                throw new Exception(@"Limite de Filhos Atingidos");

            return true;
        }
        private string proximoSequencial(string sequencial)
        {

            int freqPontoAparecendo = sequencial.Count(f => (f == '.'));

            switch (freqPontoAparecendo)
            {
                case 0:
                    //valor atual sendo apenas 1
                    //proximo sequencial 1.1
                    return "1.1";
                    break;
                case 1:
                    //valor atual sendo tipo 1.1
                    //proximo sequencial 1.2
                    var split = sequencial.Split('.');
                    return split[0] + "." + (Convert.ToInt32(split[1]) + 1);                    
                    break;
                case 2:
                    //valor atual sendo tipo 1.1.1
                    //proximo sequencial 1.1.1
                    split = sequencial.Split('.');
                    return split[0] + "." + split[1] + "." + (Convert.ToInt32(split[2]) + 1);
                    break;
            }            

            return "";
        }
        private bool validaContaMesmoTipo(int id)
        {
            var consultaContas = _contaRepositorio.ConsultarContas(id);

            if(consultaContas.Any())
                throw new Exception("Ja existe conta Configurada com este Tipo");

            return true;
        }
        private bool validaExistenciaTipo(int id)
        {
            var tipo = _tipoRepositorio.ConsultarTipo(id);

            if (!tipo.Any())
                throw new Exception("Não existe esse tipo Cadastrado");
            return true;
        }
    }
}
