using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } 
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; } 
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio.")
                .MinimumLength(3).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no mínimo 3 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio.");

            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage(x => $"O campo {nameof(x.DataNascimento)} não pode ser nulo.");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser vazio.");

            RuleFor(x => x.DataContratacao)
                .NotNull().WithMessage(x => $"O campo {nameof(x.DataContratacao)} não pode ser nulo.");

            RuleFor(x => x.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage(x => $"O campo {nameof(x.ComissaoPercentual)} deve estar entre 0 e 100.");

            RuleFor(x => x.MetaMensal)
                .GreaterThanOrEqualTo(0).WithMessage(x => $"O campo {nameof(x.MetaMensal)} deve ser maior ou igual a 0.");

        }
    }
}
