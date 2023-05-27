using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5.Model
{
	public class Klient
	{
		[Key]
		public int KlientId { get; set; }
		public string Nazwa { get; set; }
		public long NIP { get; set; }
		public string Adres { get; set; }
	}
}
