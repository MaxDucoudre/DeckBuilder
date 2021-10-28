using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class Deck 
{

    private int deckMaxSize = 30;
    private int numberOfCardInDeck;
    private List<Card> cardList;

    public Deck()
    {
        this.numberOfCardInDeck = 0;
        this.deckMaxSize = 30;
        this.cardList = new List<Card>();
        this.cardList.Capacity = deckMaxSize;
    }

    public void addCard(Card card)
    {
        this.cardList.Add(card);
        this.numberOfCardInDeck = this.cardList.Count;
    }

    public void removeCard(Card card)
    {
        this.cardList.Remove(card);
        this.numberOfCardInDeck = this.cardList.Count;
    }

    public void setDeckSize(int newSize)
    {
        this.cardList.Capacity = newSize;
        this.deckMaxSize = newSize;
    }

    public Card getRandomCard()
    {
        Card[] cards = this.cardList.ToArray();
        int rand = Random.Range(0, cards.Length-1);

        return cards[rand];
    }

    public Card drawRandomCard()
    {
        Card[] cards = this.cardList.ToArray();
        int rand = Random.Range(0, cards.Length - 1);

        this.removeCard(cards[rand]);
        return cards[rand];
    }


}
