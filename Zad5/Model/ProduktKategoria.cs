using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5.Model
{
	public class ProduktKategoria
	{
		[Key]
		public int ProduktKategoriaId { get; set; }
		public string Name { get; set; }

		[ForeignKey("KategoriaProduktuId")]
		public virtual ICollection<Produkt> Produkty { get; set; }

	}
}
