using Microsoft.EntityFrameworkCore;
using parcial1_Ap1_BryanOvalle_Recuperacion.Models;

namespace parcial1_Ap1_BryanOvalle_Recuperacion.DAL;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options)
	{
	}
	public DbSet<Metas> Metas { get; set; }
}