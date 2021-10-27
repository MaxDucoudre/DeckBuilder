using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string name;
    private string description;
    private int price;
    private int sellprice;

    public Item(string name, string description, int price, int sellprice)
    {
        this.name = name;
        this.description = description;
        this.price = price;
        this.sellprice = sellprice;
    }

    
}
