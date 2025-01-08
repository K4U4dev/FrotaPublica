using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Manter dados de marcas das pe�as e insumos no banco de dados
    /// </summary>
    public class ManutencaoService : IManutencaoService
    {
        private readonly FrotaContext context;

        public ManutencaoService(FrotaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar registro de Manutencao no banco
        /// </summary>
        /// <param name="manutencao">Inst�ncia de Manutencao</param>
        /// <returns>Id da Manutencao</returns>
        public uint Create(Manutencao manutencao, int idFrota)
        {
            manutencao.IdFrota = (uint)idFrota;
            context.Add(manutencao);
            context.SaveChanges();
            return manutencao.Id;
        }

        /// <summary>
        /// Excluir Manutencao da base de dados
        /// </summary>
        /// <param name="id">Id do Manutencao</param>
        public void Delete(uint id)
        {
            var entity = context.Manutencaos.Find(id);
            if (entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do Manutencao na base de dados
        /// </summary>
        /// <param name="manutencao">Inst�ncia de Manutencao</param>
        public void Edit(Manutencao manutencao, int idFrota)
        {
            manutencao.IdFrota = (uint)idFrota;
            context.Update(manutencao);
            context.SaveChanges();
        }

        /// <summary>
        /// Obter dados de um Manutencao
        /// </summary>
        /// <param name="id">Id do Manutencao</param>
        /// <returns>Inst�ncia de Manutencao ou null, caso n�o exista</returns>
        public Manutencao? Get(uint id)
        {
            return context.Manutencaos.Find(id);
        }

        /// <summary>
        /// Obter todos os Manutencao da base de dados
        /// </summary>
        /// <returns>Lista de todos os Manutencao</returns>
        public IEnumerable<Manutencao> GetAll(int idFrota)
        {
            return context.Manutencaos
                          .Where(manutencao => manutencao.IdFrota == idFrota)
                          .AsNoTracking();
        }
    }
}
