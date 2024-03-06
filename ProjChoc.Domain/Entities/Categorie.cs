using ProjChoc.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjChoc.Domain.Entities
{
	public class Categorie
	{
		public int Id { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime LastUpDate { get; set; }
		public StateRegistry StateRegistry { get; set; }
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
