using FluentValidation;
using Store.Application.Features.Orders.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Validation
{
    public class CreateOederCommandValidator : AbstractValidator<CreateOederCommand>
    {
        public CreateOederCommandValidator()
        {
            
        }
    }
}
