using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCard : Card
{
    

    public SpellCard(string idCard, string name, string description, Type type, int price, int sellprice, string spriteIllustration)
         : base(idCard, name, description, type, price, sellprice, spriteIllustration)
    {

    }

 
}
