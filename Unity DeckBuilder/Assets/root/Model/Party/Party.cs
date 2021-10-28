using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party 
{
    private int ennemiesDamageMultiplicator = 0;
    private int damageMultipicator = 0;
    private int moneyMultiplicator = 0;
    private int xpMultiplicator = 0;

    private CardReader cardGenerator;
    private TypeReader typeReader;
    private Map map;


    public Party()
    {
        this.typeReader = new TypeReader();
        this.cardGenerator = new CardReader(this.typeReader.InstantiateTypes());
        startParty();
    }

    


    public void startParty()
    {

        this.map = new Map("map1", "Gondor", "Bienvenue au Gondor", 10, 50, 40, 10);
    }

    public void applyDifficulty(Difficulty difficulty)
    {

    }
}
