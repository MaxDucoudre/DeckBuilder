using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class Hand
{
    private int handMaxSize;
    private int numberOfCardInHand;
    private List<Card> cardList;

    public Hand()
    {

        this.numberOfCardInHand = 0;
        this.handMaxSize = 6;
        this.cardList = new List<Card>();
        this.cardList.Capacity = handMaxSize;
    }

    public void addCard(Card card)
    {
        this.cardList.Add(card);
        this.numberOfCardInHand = this.cardList.Count;
    }

    public void removeCard(Card card)
    {
        if (this.cardList.Contains(card) == true)
        {
            this.cardList.Remove(card);
            this.numberOfCardInHand = this.cardList.Count;
        }
        else
        {
            Debug.Log("This card is not in the hand!");
        }
    }

    public void clearHand()
    {
        this.cardList.Clear();
        
    }



    public void setHandSize(int newSize)
    {
        this.cardList.Capacity = newSize;
        this.handMaxSize = newSize;
    }






}
