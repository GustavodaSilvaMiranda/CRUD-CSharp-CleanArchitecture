using System.ComponentModel.DataAnnotations;

namespace ProjChoc.Domain.Entities.Enums;

public enum StateRegistry
{
	[Display(Name = "ATIVO")]
	ACTIVE = 0,
	[Display(Name = "REMOVIDO")]
	REMOVED = 1,
	[Display(Name = "BLOQUEADO")]
	BLOCKED = 2
}
