using FluentValidation;
using Oppslagstavle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Validators
{
    public class OppslagValidator : AbstractValidator<Oppslag>
    {
        public OppslagValidator()
        {
            RuleFor(o => o.Bygg).NotEmpty();

            RuleFor(o => o.Publisert).NotEmpty(); // trengs kanskje ikke?

            RuleFor(o => o.Sluttdato).NotEmpty();

            RuleFor(o => o.Tittel)
                .NotEmpty()                
                .Matches("^[A-Åa-å0-9 @/._-]{1,100}$");

            RuleFor(o => o.Tekst)
                .NotEmpty()
                .Matches("^[A-Åa-å0-9 @/._-]{1,900}$");

            RuleFor(o => o.Bilde); 
        }
    }
}
