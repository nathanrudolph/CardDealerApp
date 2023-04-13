using DeckOfCards;
using DeckOfCards.Models;

var deck = new Deck();

Console.WriteLine("Shuffling the deck...");
deck.Shuffle();

var quit = false;
while (!quit)
{
    Console.WriteLine("\nPress Enter to draw from the deck.");
    Console.ReadLine();
    var card = deck.DealOneCard();
    if (card == null)
    {
        Console.WriteLine("Deck was empty. Press any key to exit.");
        Console.ReadLine();
        quit = true;
        return;
    }
    Console.WriteLine($"Dealt card: {card.ToString()}");
}