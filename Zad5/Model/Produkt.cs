using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5.Model
{
	public class Produkt
	{
		[Key]
		public int ProduktId { get; set; }
		public string Nazwa { get; set; }
		public int IloscNaStanie { get; set; }
		public double CenaJednostkowa { get; set; }
		public double VAT { get; set; }

		[ForeignKey("ProduktKategoria")]
		public virtual int KategoriaProduktuId { get; set; }
		public virtual ProduktKategoria ProduktKategoria { get; set; }
		
	}
}
