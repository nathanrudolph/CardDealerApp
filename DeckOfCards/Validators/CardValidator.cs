using DeckOfCards.Enums;
using DeckOfCards.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.Validators;

public class CardValidator : AbstractValidator<Card>
{
    public CardValidator()
    {
        RuleFor(c => c.Rank).IsInEnum();
        RuleFor(c => c.Suit).IsInEnum();
    }
}
