using ChatApp.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Server
{
	public class ChatHub : Hub
	{
		public void Test(Poruka p)
		{
			Console.WriteLine("Javlja se klijent sa porukom: " + p.Sadrzaj);
			Clients.All.SendAsync("KlijentMetoda", p.Sadrzaj);
		}

		public void Registracija(Korisnik k)
		{
			Baza db = new Baza();
			if (db.Korisniks.Where(kor => kor.Email == k.Email || kor.Username == k.Username).Count() != 0)
			{
				Clients.Caller.SendAsync("Poruka", "Korisnik vec postoji!");
			} else
			{
				db.Korisniks.Add(k);
				db.SaveChanges();
			}
		}
		public void Login(Korisnik k)
		{
			Baza db = new Baza();
			var korisnik = db.Korisniks.Where(kor => k.Username == kor.Username && k.Password == kor.Password).FirstOrDefault();
			if (korisnik != null)
			{
				Clients.Caller.SendAsync("Uloguj", korisnik);
			}
			else
			{
				Clients.Caller.SendAsync("Poruka", "Nope :(");
			}
		}

		public void PorukaOdKlijenta(Poruka p)
			=> Clients.All.SendAsync("ChatPoruka", p);
	}
}
