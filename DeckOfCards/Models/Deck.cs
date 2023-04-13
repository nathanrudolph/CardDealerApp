using DeckOfCards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.Models;

/// <summary>
/// Object to represent a deck of cards and its operations.
/// </summary>
public class Deck
{
    public Deck()
    {
        this.Cards = new List<Card>();
        GenerateStandardPokerDeck();
    }

    public List<Card> Cards { get; protected set; }

    /// <summary>
    /// Sets the cards in the deck to a standard poker-style playing deck.
    /// </summary>
    public void GenerateStandardPokerDeck()
    {
        this.Cards = new List<Card>();

        var suits = Enum.GetValues<CardSuit>();
        var ranks = Enum.GetValues<CardRank>();

        foreach (var suit in suits)
        {
            foreach (var value in ranks)
            {
                this.Cards.Add(new Card(value, suit));
            }
        }
    }

    /// <summary>
    /// Shuffles the deck using the Fisher-Yates algorithm.
    /// </summary>
    public void Shuffle()
    {
        if (Cards is null || !Cards.Any())
        {
            return;
        }
        int topIndex = Cards.Count - 1;
        Random random = new Random();
        for (int i = 0; i < topIndex; i++)
        {
            int j = random.Next(topIndex);
            SwapTwoCardsInDeck(i, j);
        }
    }

    /// <summary>
    /// Swaps two cards in place.
    /// </summary>
    /// <param name="cardIndex1"></param>
    /// <param name="cardIndex2"></param>
    protected void SwapTwoCardsInDeck(int cardIndex1, int cardIndex2)
    {
        if (cardIndex1 == cardIndex2)
            return;
        var card1 = Cards[cardIndex1];
        Cards[cardIndex1] = Cards[cardIndex2];
        Cards[cardIndex2] = card1;
    }

    /// <summary>
    /// Pops the top card from the deck.
    /// </summary>
    /// <returns></returns>
    public Card? DealOneCard()
    {
        if (Cards.Count < 1)
        {
            return null;
        }

        int topIndex = Cards.Count - 1;
        var topCard = Cards[topIndex];
        Cards.RemoveAt(topIndex);
        return topCard;
    }
}
