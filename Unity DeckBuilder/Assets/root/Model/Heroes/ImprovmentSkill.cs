using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovmentSkill
   
{
    private string name;
    private string description;
    private int levelOfSkill;
    private int cost;
    private Skill parentSkill;


    public ImprovmentSkill(string name, string description, int levelOfSkill, int cost, Skill parentSkill)
    {
        this.name = name;
        this.description = description;
        this.levelOfSkill = levelOfSkill;
        this.cost = cost;
        this.parentSkill = parentSkill;
    }

    public bool isUnlockable()
    {
        if (this.levelOfSkill == this.parentSkill.getLevelOfSkill()+1)
        {
            return true;
        }
        return false;
    }

    public string getName()
    {
        return this.name;
    }

    public string getDescription()
    {
        return this.description;

    }
    
    public int getCost()
    {
        return this.cost;
    }

    public int getLevelOfSkill()
    {
        return this.levelOfSkill;
    }

}
