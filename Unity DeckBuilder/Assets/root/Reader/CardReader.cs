using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class CardReader 
{

    private string idCard;
    private string name;
    private string description;
    private Type type;
    private string illustration;
    private bool isCreature;
    private string idHero;
    private int price;
    private int sellprice;
    private string creatureSprite;

    private int lifePoint;
    private int armor;
    private int damage;
    private string spriteInAction;

    private Type[] types;

    private string path = "Assets/root/data/CardData/cards.xml";
    private int numberOfCard;

    public CardReader(Type[] types)
    {
        var reader = XmlReader.Create(this.path);
        while (reader.ReadToFollowing("Card")) { this.numberOfCard++; }
        this.types = types;
    }

    public Card InstantiateCard(string idCard)
    {
        Card card = null;
        try
        {
            var reader = XmlReader.Create(path);

            while (reader.ReadToFollowing("Card"))
            {
                reader.MoveToFirstAttribute();
                if(reader.Value == idCard)
                {
                    reader.MoveToNextAttribute();
                    this.name = reader.Value;

                    reader.MoveToNextAttribute();
                    this.description = reader.Value;

                    reader.MoveToNextAttribute();
                    foreach(Type type in this.types)
                    {
                        if(this.type.getIdType() == reader.Value)
                        {
                            this.type = type;
                        }
                    }

                    reader.MoveToNextAttribute();
                    this.illustration = reader.Value;

                    reader.MoveToNextAttribute();
                    if(reader.Value == "false")
                    {
                        this.isCreature = false;
                    } else if(reader.Value == "true") {
                        this.isCreature = true;
                    }

                    reader.MoveToNextAttribute();
                    int.TryParse(reader.Value, out this.price);

                    reader.MoveToNextAttribute();
                    int.TryParse(reader.Value, out this.sellprice);

                    reader.MoveToNextAttribute();
                    if(reader.Value == "null")
                    {
                        this.creatureSprite = null;
                    } else
                    {
                        this.creatureSprite = reader.Value;
                    }

                    if(this.isCreature == true)
                    {
                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out this.lifePoint);

                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out this.armor);

                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out this.damage);

                        reader.MoveToNextAttribute();
                        this.spriteInAction = reader.Value;
                    }
                }
            }

            reader.Close();
        }
        catch
        {
            Debug.Log("Xml Reading Failed!");
            return card;
        }

        if(this.isCreature == false)
        {
            card = new SpellCard(idCard, this.name, this.description, this.type, this.price, this.sellprice, this.illustration);
        } else if(this.isCreature == true)
        {
            card = new CreatureCard(idCard, this.name, this.description, this.type, this.price, this.sellprice, this.illustration, this.spriteInAction, this.lifePoint, this.armor, this.damage);
        }

        return card;
    }

    public Card InstantiateRandomCard()
    {
        return null;

    }

    public Card InstantiateRandomCardByType(string idType)
    {
        Card card = null;
        try
        {
            var reader = XmlReader.Create(path);

            while (reader.ReadToFollowing("Card"))
            {
                reader.MoveToFirstAttribute();
                reader.MoveToNextAttribute();
                reader.MoveToNextAttribute();
                reader.MoveToNextAttribute();

                if (reader.Value == idType)
                { 

                    reader.MoveToFirstAttribute();
                    this.idCard = reader.Value;

                    reader.MoveToNextAttribute();
                    this.name = reader.Value;

                    reader.MoveToNextAttribute();
                    this.description = reader.Value;

                    reader.MoveToNextAttribute();
                    foreach (Type type in this.types)
                    {
                        if (this.type.getIdType() == reader.Value)
                        {
                            this.type = type;
                        }
                    }

                    reader.MoveToNextAttribute();
                    this.illustration = reader.Value;

                    reader.MoveToNextAttribute();
                    if (reader.Value == "false")
                    {
                        this.isCreature = false;
                    }
                    else if (reader.Value == "true")
                    {
                        this.isCreature = true;
                    }

                    reader.MoveToNextAttribute();
                    int.TryParse(reader.Value, out this.price);

                    reader.MoveToNextAttribute();
                    int.TryParse(reader.Value, out this.sellprice);

                    reader.MoveToNextAttribute();
                    if (reader.Value == "null")
                    {
                        this.creatureSprite = null;
                    }
                    else
                    {
                        this.creatureSprite = reader.Value;
                    }

                    if (this.isCreature == true)
                    {
                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out this.lifePoint);

                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out this.armor);

                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out this.damage);

                        reader.MoveToNextAttribute();
                        this.spriteInAction = reader.Value;
                    }
                }
            }
        }
        catch
        {
            Debug.Log("Xml Reading Failed!");
            return card;
        }

        if (this.isCreature == false)
        {
            card = new SpellCard(this.idCard, this.name, this.description, this.type, this.price, this.sellprice, this.illustration);
        }
        else if (this.isCreature == true)
        {
            card = new CreatureCard(this.idCard, this.name, this.description, this.type, this.price, this.sellprice, this.illustration, this.spriteInAction, this.lifePoint, this.armor, this.damage);
        }

        return card;
    }


    public Card InstantiateRandomCardByHero(string heroID)
    {
        return null;

    }


}
