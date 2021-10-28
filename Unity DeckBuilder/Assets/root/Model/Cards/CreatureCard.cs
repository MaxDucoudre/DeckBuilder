using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCard : Card
{
    private int lifePoint;
    private int armor;
    private int damage;
    private Sprite spriteCreature;

    public CreatureCard(string idCard, string name, string description, Type type, int price, int sellprice, string spriteIllustration, string spriteCreature, int lifePoint, int armor, int damage)
         : base(idCard, name, description, type, price, sellprice, spriteIllustration)
    {
        this.lifePoint = lifePoint;
        this.armor = armor;
        this.damage = damage;
        this.spriteCreature = Resources.Load<Sprite>("Sprites/CreatureSprite/" + spriteCreature);
    }


}
