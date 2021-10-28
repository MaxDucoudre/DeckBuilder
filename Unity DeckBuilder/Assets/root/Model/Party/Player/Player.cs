using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    protected int lifePoint;
    protected int armor;
    protected int xpParty;
    protected int money;
    protected int maxMana;
    protected int maxHP;
    protected bool isDead;

    protected Inventory inventory;
    private Deck deck;
    protected Heroe hero;

    public Player(Inventory inventory, Deck deck, Heroe hero)
    {
        this.inventory = inventory;
        this.deck = deck;
        this.hero = hero;


        this.isDead = false;
        this.lifePoint = this.hero.getDefaultHP();
        this.armor = 0;
        this.xpParty = 0;
        this.money = 0;

    }


    

    public void decreaseHP(int hp)
    {
        this.lifePoint = hp;
        if(lifePoint <= 0)
        {
            isDead = true;
        }
    }

    public void increaseHP(int hp)
    {
        if(this.lifePoint+hp > this.maxHP)
        {
            this.lifePoint = this.maxHP;
        } else
        {
            this.lifePoint = this.lifePoint + hp;
        }
    }

    public void increaseXP(int xp)
    {
        this.xpParty = this.xpParty + xp;
    }

    public void setMoney(int money)
    {
        this.money = money;
    }

    public void setArmor(int armor)
    {
        this.armor = armor;
    }

    public int getHP()
    {
        return this.lifePoint;
    }

    public int getMoney()
    {
        return this.money;
    }

    public int getXPParty()
    {
        return this.xpParty;
    }

    public int getArmor()
    {
        return this.armor;
    }

    public int getMaxHP()
    {
        return this.maxHP;
    }
    public int getMaxMana()
    {
        return this.maxMana;
    }

    public bool getIsDead()
    {
        return this.isDead;
    }

    public Inventory getInventory()
    {
        return this.inventory;
    }

    public Deck getDeck()
    {
        return this.deck;
    }

    public Heroe getHeroe()
    {
        return this.hero;
    }

}
