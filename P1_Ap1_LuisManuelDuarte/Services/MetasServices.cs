
using Microsoft.EntityFrameworkCore;
using P1_Ap1_LuisManuelDuarte.DAL;
using P1_Ap1_LuisManuelDuarte.Models;
using System.Linq.Expressions;


namespace P1_Ap1_LuisManuelDuarte.Services
{
    public class MetasServices
    {
        private readonly Contexto _contexto;

        public MetasServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int metasId)
        {
            return await _contexto.Metas.AnyAsync(m => m.MetaId == metasId);
        }

        public async Task<bool> Insertar(Metas metas)
        {
            _contexto.Add(metas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Metas metas)
        {
            _contexto.Update(metas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Metas metas)
        {
            if (!await Existe(metas.MetaId))
            {
                return await Insertar(metas);
            }
            else
            {
                return await Modificar(metas);
            }
        }

        public async Task<bool> Eliminar(Metas metas)
        {
            var cantidad = await _contexto.Metas
                .Where(m => m.MetaId == metas.MetaId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Metas?> Buscar(int metaId)
        {
            return await _contexto.Metas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MetaId == metaId);
        }

        public async Task<List<Metas>> GetList(Expression<Func<Metas, bool>> criterio)
        {
            return await _contexto.Metas
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Metas?> BuscarId(int metasId)
        {
            return await _contexto.Metas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MetaId == metasId);
        }


    }
}
