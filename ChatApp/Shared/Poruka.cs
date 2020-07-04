using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Shared
{
	public class Poruka
	{
		public string Sadrzaj { get; set; }
		public Korisnik Posiljaoc { get; set; }
		public DateTime VremeSlanja { get; set; }
	}
}
