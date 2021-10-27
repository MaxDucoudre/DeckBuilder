using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type 
{
    private string idType;
    private string name;
    private string description;
    private int strenghtMultiplicator;
    private int weaknessMultiplicator;

    public Type(string idType, string name, string description, int strenghtMultiplicator, int weaknessMultiplicator)
    {
        this.idType = idType;
        this.description = description;
        this.name = name;
        this.strenghtMultiplicator = strenghtMultiplicator;
        this.weaknessMultiplicator = weaknessMultiplicator;
    }

    public string getIdType()
    {
        return idType;
    }

    public string getName()
    {
        return this.name;
    }
    public string getDescription()
    {
        return this.description;
    }
    public int getStrenghtMultiplicator()
    {
        return this.strenghtMultiplicator;
    }
    public int getWeaknessMultiplicator()
    {
        return this.weaknessMultiplicator;
    }

}
