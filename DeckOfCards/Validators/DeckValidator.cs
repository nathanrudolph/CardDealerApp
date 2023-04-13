using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCards.Models;
using FluentValidation;

namespace DeckOfCards.Validators;

public class DeckValidator : AbstractValidator<Deck>
{
    public DeckValidator()
    {
        RuleFor(d => d.Cards)
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(cards => cards.Count <= 52).WithMessage("{PropertyName} cannot contain more than 52 cards.")
            .Must(cards => ContainNoDuplicates(cards)).WithMessage("{PropertyName} cannot ");
    }

    public bool ContainNoDuplicates(List<Card> cards)
    {
        throw new NotImplementedException();
    }
}
