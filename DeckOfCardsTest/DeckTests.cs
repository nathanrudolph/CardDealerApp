using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCards;
using DeckOfCards.Models;

namespace DeckOfCardsTest;

public class DeckTests
{
    [Fact]
    public void NewDeck_ShouldHave52Cards()
    {
        var deck = new Deck();

        deck.GenerateStandardPokerDeck();

        deck.Cards.Should().HaveCount(52);
    }

    [Fact]
    public void NewDeck_ShouldContainNoDuplicateCards()
    {
        var deck = new Deck();

        deck.GenerateStandardPokerDeck();

        deck.Cards.Should().OnlyHaveUniqueItems();
    }

    [Fact] 
    public void ShuffledDeck_ShouldHaveTheSameNumberOfCards()
    {
        var deck = new Deck();
        int originalCount = deck.Cards.Count;

        deck.GenerateStandardPokerDeck();
        deck.Shuffle();

        deck.Cards.Should().HaveCount(originalCount);
    }

    [Fact]
    public void ShuffledDeck_ShouldContainSameCards()
    {
        var deck = new Deck();
        var originalCards = deck.Cards;

        throw new NotImplementedException();
    }


    [Fact]
    public void DealOneCard_ShouldRemoveExactlyOneCardFromDeck()
    {
        var deck = new Deck();
        int originalCount = deck.Cards.Count;

        deck.DealOneCard();

        deck.Cards.Should().HaveCount(originalCount - 1);
    }

    [Fact]
    public void DealOneCard_ShouldRemoveLastCardFromDeck()
    {
        var deck = new Deck();
        var lastCard = deck.Cards.LastOrDefault();

        var dealtCard = deck.DealOneCard();

        dealtCard.Should().Be(lastCard);
    }

    [Fact]
    public void DealOneCard_ShouldReturnNullWhenDeckIsEmpty()
    {
        var deck = new Deck();
        int total = deck.Cards.Count;

        for (int i = 0; i < total; i++)
        {
            deck.DealOneCard();
        }
        var card = deck.DealOneCard();

        card.Should().BeNull();
    }
}
