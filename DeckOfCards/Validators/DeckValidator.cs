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
        RuleForEach(d => d.Cards).SetValidator(new CardValidator());
        RuleFor(d => d.Cards)
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(cardList => cardList.Count <= 52).WithMessage("{PropertyName} cannot contain more than 52 cards.")
            .Must(ContainNoDuplicates).WithMessage("{PropertyName} cannot contain duplicate cards.");
    }

    protected bool ContainNoDuplicates(List<Card> cards)
    {
        return cards.Distinct().Count() == cards.Count;
    }
}
