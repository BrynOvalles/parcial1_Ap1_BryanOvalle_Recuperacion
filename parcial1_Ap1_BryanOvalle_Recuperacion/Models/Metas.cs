using System.ComponentModel.DataAnnotations;
namespace parcial1_Ap1_BryanOvalle_Recuperacion.Models;

public class Metas
{
	[Key]
	public int MetaId { get; set; }
	[Required(ErrorMessage = "Es requerido intruducir una fecha")]
	[DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
	public DateTime Fecha { get; set; } = DateTime.Now;
	[Required(ErrorMessage = "Es requerido que tenga una descripción")]
	[MinLength(3, ErrorMessage = "La descripción es muy corta")]
	[MaxLength(100, ErrorMessage = "La descripción es muy larga")]
	public string? Descripcion { get; set; }
	[Required(ErrorMessage = "Es requerido que ingreses un monto para tu meta")]
	[Range(minimum: 0.01, maximum: 10000000000000000000, ErrorMessage = "El monto debe ser mayor a 0 o es demasiado alto para el sistema")]
	public decimal Monto { get; set; }
}