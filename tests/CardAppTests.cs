using System.Linq;
using CardApp;

namespace CardAppTests;

[TestClass]
public class CardAppTests
{
    private readonly Deck _deck;

    public CardAppTests()
    {
        _deck = new Deck();
    }
    
    [TestMethod]
    public void Init_Deck()
    {
        Assert.AreEqual(52, _deck.Count());
    }
    
    [TestMethod]
    public void Draw_Card()
    {
        int i = 52;
        while (--i >= 0)
        {
            _deck.DrawCard();
            Assert.AreEqual(i, _deck.Count());
        }
        
        _deck.DrawCard();
        Assert.AreEqual(0, _deck.Count());
    }
    
    [TestMethod]
    public void Draw_Cards()
    {
        var cards = _deck.DrawCards();
        Assert.AreEqual(0, _deck.Count());
        Assert.AreEqual(52, cards.ToList().Count());

        _deck.Init();
        cards = _deck.DrawCards(1);
        Assert.AreEqual(51, _deck.Count());
        Assert.AreEqual(1, cards.ToList().Count());
        
        _deck.Init();
        cards = _deck.DrawCards(10);
        Assert.AreEqual(42, _deck.Count());
        Assert.AreEqual(10, cards.ToList().Count());
        
        _deck.Init();
        cards = _deck.DrawCards(0);
        Assert.AreEqual(52, _deck.Count());
        Assert.AreEqual(0, cards.ToList().Count());
        
        _deck.Init();
        cards = _deck.DrawCards(52);
        Assert.AreEqual(0, _deck.Count());
        Assert.AreEqual(52, cards.ToList().Count());
        
        _deck.Init();
        cards = _deck.DrawCards(100);
        Assert.AreEqual(0, _deck.Count());
        Assert.AreEqual(52, cards.ToList().Count());
        
        _deck.Init();
        cards = _deck.DrawCards(-1);
        Assert.AreEqual(52, _deck.Count());
        Assert.AreEqual(0, cards.ToList().Count());


        _deck.Init();
        cards = _deck.DrawCards(1);
        Assert.AreEqual(51, _deck.Count());
        cards = _deck.DrawCards(10);
        Assert.AreEqual(41, _deck.Count());
        cards = _deck.DrawCards(20);
        Assert.AreEqual(21, _deck.Count());
        cards = _deck.DrawCards(0);
        Assert.AreEqual(21, _deck.Count());
        cards = _deck.DrawCards(100);
        Assert.AreEqual(0, _deck.Count());
        cards = _deck.DrawCards(100);
        Assert.AreEqual(0, _deck.Count());
    }
}
