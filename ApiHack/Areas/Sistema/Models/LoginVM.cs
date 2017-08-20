using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace ApiHack.Areas.Sistema.Models{
	[Validator(typeof(LoginValidator))]
	public class LoginVM{

        public string login {get; set;}
		
		public string senha {get; set;}

		public string returnUrl {get; set;}
	}

	//
	internal class LoginValidator : AbstractValidator<LoginVM> {

		//
		public LoginValidator() {

			RuleFor(x => x.login)
				.NotEmpty().WithMessage("Informe qual é o login.");

            RuleFor(x => x.senha)
                .NotEmpty().WithMessage("Informe a sua senha.");
		}
	}
}