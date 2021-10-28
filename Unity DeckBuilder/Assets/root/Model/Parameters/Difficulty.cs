using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty 
{
    private int damageMultiplicator,
                ennemiesDamageMultiplicator,
                moneyMultiplicator,
                xpMultiplicator;

    private string name,
                   description;

    public Difficulty(string name, string description, int dmgMult, int enDmgMult, int monMult, int xpMult)
    {
        this.name = name;
        this.description = description;
        this.setDamageMultiplicator(dmgMult);
        this.setEnnemiesDamageMultiplicator(enDmgMult);
        this.setMoneyMultiplicator(monMult);
        this.setxpMultiplicator(xpMult);

    }


    public string getName()
    {
        return this.name;
    }

    public int getDamageMultiplicator()
    {
        return damageMultiplicator;
    }

    public void setDamageMultiplicator(int value)
    {
        if (value < 0)
        {
            Debug.Log("DamageMultiplicator : value can't be under 0");
            Application.Quit();
        }
        this.damageMultiplicator = value;
    }

    public int getEnnemiesDamageMultiplicator()
    {
        return ennemiesDamageMultiplicator;
    }

    public void setEnnemiesDamageMultiplicator(int value)
    {
        if (value < 0)
        {
            Debug.Log("ennemiesDamageMultiplicator : value can't be under 0");
            Application.Quit();
        }
        this.ennemiesDamageMultiplicator = value;
    }

    public int getMoneyMultiplicator()
    {
        return moneyMultiplicator;
    }

    public void setMoneyMultiplicator(int value)
    {
        if (value < 0)
        {
            Debug.Log("moneyMultiplicator : value can't be under 0");
            Application.Quit();
        }
        this.moneyMultiplicator = value;
    }

    public int getxpMultiplicator()
    {
        return xpMultiplicator;
    }

    public void setxpMultiplicator(int value)
    {
        if (value < 0)
        {
            Debug.Log("xpMultiplicator : value can't be under 0");
            Application.Quit();
        }
        this.xpMultiplicator = value;
    }

    public string getDescription()
    {
        return this.description;
    }

}
