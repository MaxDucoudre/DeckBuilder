using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : Player
{

    private Player player;
    private int actualMana;
    private Hand hand;
    private Deck fightDeck;

    public PlayerFight(Player player)
        : base(player.getInventory(), player.getDeck(), player.getHeroe())
    {

        this.player = player;
        this.copyPlayer();
        this.hand = new Hand();
        this.fightDeck = player.getDeck();

    }


    public void setRandomHand(int numberOfCard)
    {
        this.hand.clearHand();
        for (int i = 0; i < numberOfCard; i++) 
        {
            this.hand.addCard(this.fightDeck.drawRandomCard());
        }
    }

    public void playCardFromHand(Card card)
    {
        this.hand.removeCard(card);
    }

    public void drawCard()
    {
        this.hand.addCard(this.fightDeck.drawRandomCard());

    }

    public Hand getHand()
    {
        return this.hand;
    }


    public void copyPlayer() 
    {
        this.lifePoint = this.player.getHP();
        this.armor = this.player.getArmor();
        this.xpParty = this.player.getXPParty();
        this.money = this.player.getMoney();
        this.maxMana = this.player.getMaxMana();
        this.maxHP = this.player.getMaxHP();
        this.isDead = false;
    }

    public void setInfoToPlayer()
    {

    }

}