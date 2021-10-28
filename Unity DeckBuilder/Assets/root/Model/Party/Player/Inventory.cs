using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int space = 5;
    private int numberOfItemInInventory;
    private List<Item> itemList;

    public Inventory()
    {
        this.numberOfItemInInventory = 0;
        this.space = 30;
        this.itemList = new List<Item>();
        this.itemList.Capacity = space;
    }

    public void addItem(Item item)
    {
        this.itemList.Add(item);
        this.numberOfItemInInventory = this.itemList.Count;
    }

    public void removeItem(Item item)
    {
        this.itemList.Remove(item);
        this.numberOfItemInInventory = this.itemList.Count;
    }

    public void setInventorySpace(int newSize)
    {
        this.space = newSize;
        this.itemList.Capacity = this.space;
    }

}
