using Microsoft.EntityFrameworkCore;
using parcial1_Ap1_BryanOvalle_Recuperacion.DAL;
using parcial1_Ap1_BryanOvalle_Recuperacion.Models;
using System.Linq.Expressions;

namespace parcial1_Ap1_BryanOvalle_Recuperacion.Services;

public class MetasServices
{
	private readonly Contexto _contexto;
	public MetasServices(Contexto contexto)
	{
		_contexto = contexto;
	}
	public async Task<bool> Existe(int id)
	{
		return await _contexto.Metas.AnyAsync(m => m.MetaId == id);
	}
	public async Task<bool> Crear(Metas meta)
	{
		if (!await Existe(meta.MetaId))
			return await Insertar(meta);
		else
			return await Modificar(meta);
	}
	public async Task<bool> Insertar(Metas meta)
	{
		_contexto.Metas.Add(meta);
		return await _contexto.SaveChangesAsync() > 0;
	}
	public async Task<bool> Modificar(Metas meta)
	{
		_contexto.Metas.Update(meta);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(meta).State = EntityState.Detached;
		return modificado;
	}
	public async Task<bool> Eliminar(Metas metas)
	{
		return await _contexto.Metas
			.AsNoTracking()
			.Where(m => m.MetaId == metas.MetaId)
			.ExecuteDeleteAsync() > 0;
	}
	public async Task<Metas?> Buscar(int id)
	{
		return await _contexto.Metas
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.MetaId == id);
	}
	public async Task<Metas?> BuscarDescripcion(string descripcion)
	{
		return await _contexto.Metas
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.Descripcion == descripcion);
	}
	public async Task<List<Metas>> ObtenerLista(Expression<Func<Metas, bool>> criterio)
	{
		return await _contexto.Metas.
			AsNoTracking().
			Where(criterio).
			ToListAsync();
	}
}
