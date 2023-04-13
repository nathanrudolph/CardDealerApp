using DeckOfCards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.Models;

public record Card(CardRank Rank, CardSuit Suit)
{
    public override string ToString() => $"{Rank} of {Suit}s";
}
