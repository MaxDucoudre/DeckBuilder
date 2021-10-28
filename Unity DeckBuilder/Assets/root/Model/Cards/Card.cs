using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    private int price;
    private int sellprice;
    private Sprite illustration;
    private string name;
    private string description;
    private Type type;
    protected string idCard;


    public Card(string idCard, string name, string description, Type type, int price, int sellprice, string spriteIllustration)
    {
        this.idCard = idCard;
        this.name = name;
        this.description = description;
        this.type = type;
        this.price = price;
        this.sellprice = sellprice;
        this.illustration = Resources.Load<Sprite>("Sprites/CardSprite/" + spriteIllustration);
    }


}
