using System;
using System.Collections.Generic;
using System.Linq;


namespace CardApp
{
    public enum Suit
    {
        Spade = 1,
        Diamond,
        Heart,
        Club
    }

    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public struct Card
    {
        public const int CARD_COUNT = 52;
        
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public void Print()
        {
            Console.WriteLine($"{Rank} of {Suit}s");
        }        
        
        Suit Suit { get; init; }
        Rank Rank { get; init; }
    };

    /// <summary>
    ///     Models a standard 52-deck of playing cards without Jokers.
    ///     Supports shuffling and dealing cards. Cards are removed from the Deck when dealt.
    ///     Re-stock the deck by calling Init().
    /// </summary>
    public class Deck
    {
        public Deck()
        {
            Init();
        }

        /// <summary>
        ///     Add all cards to the Deck and Shuffle them
        /// </summary>
        public void Init()
        {
            _cards.Clear();
            
            foreach (int suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (int rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card((Suit)suit, (Rank) rank));
                }
            }

            Shuffle();
        }

        /// <summary>
        ///     Randomize order of cards
        /// </summary>
        public void Shuffle()
        {
            _cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
        }

        /// <summary>
        ///     Returns the first card of the Deck, if any are remaining, or null.
        ///     Card is removed from the Deck 
        /// </summary>
        public Card? DrawCard()
        {
            if (_cards.Count == 0)
            {
                return null;
            }
            
            var card = _cards.First();
            _cards.RemoveAt(0);
            return card;
        }

        /// <summary>
        ///     Return number of cards requested or the maximum cards left in the deck.
        ///     Cards are removed from this Deck.
        ///     Empty container returned if no cards are left or no cards requested.
        /// </summary>
        /// <param name="count">Number of cards requested, all cards by default</param>
        public IEnumerable<Card> DrawCards(int count = Card.CARD_COUNT)
        {
            if (count <= 0 || _cards.Count == 0)
            {
                return Enumerable.Empty<Card>();
            }

            if (count > _cards.Count)
            {
                count = _cards.Count;
            }

            var drawn = _cards.GetRange(0, count);
            _cards.RemoveRange(0, count);
            return drawn;
        }

        public int Count()
        {
            return _cards.Count;
        }

        /// <summary>
        ///     Deck of cards, always contains from 0 to 52 cards, never null
        /// </summary>
        private List<Card> _cards = new List<Card>();
    };
    
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            Console.WriteLine($"Cards in deck: {deck.Count()}");
            
            var card = deck.DrawCard();
            card?.Print();
            Console.WriteLine($"Cards in deck: {deck.Count()}");

            foreach (var c in deck.DrawCards(5))
            {
                c.Print();
            }
            Console.WriteLine($"Cards in deck: {deck.Count()}");
        }
    }
}
