using FluentValidation;
using Oppslagstavle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Validators
{
    public class ArrangementValidator : AbstractValidator<Arrangement>
    {
        public ArrangementValidator()
        {
            RuleFor(a => a.Hvor)
                .NotEmpty()
                .Matches("^[A-Åa-å0-9 @/._-]{1,50}$");

            RuleFor(a => a.Når).NotEmpty();
        }
    }
}
