using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Shared
{
	public class Korisnik
	{
		public int ID { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class ValidatorZaKorisnika : AbstractValidator<Korisnik>
	{
		public ValidatorZaKorisnika()
		{
			RuleFor(k => k.Email).EmailAddress().WithMessage("Unesite validan mejl!");
			RuleFor(k => k.Username).MinimumLength(3).WithMessage("Prekratko korisnicko!");
			RuleFor(k => k.Password).MinimumLength(3).WithMessage("Prekratka sifra!");
		}
	}
}
