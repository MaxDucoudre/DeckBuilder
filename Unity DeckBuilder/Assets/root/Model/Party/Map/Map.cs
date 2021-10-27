using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map 
{
    private int mapLenght = 10;

    private int proportionEventZone;
    private int proportionFightZone;
    private int proportionShopZone;
    private int proportionRandomZone;

    private string idMap;
    private string name;
    private string description;

    private Zone actualZone;
    private List<Zone> listOfZones = new List<Zone>();
    

    public Map(string idMap, string name, string description, int mapLenght, int proportionFightZone, int proportionShopZone, int proportionEventZone)
    {
        this.idMap = idMap;
        this.name = name;
        this.mapLenght = mapLenght;
        this.description = description;

        this.proportionEventZone = proportionEventZone;
        this.proportionFightZone = proportionFightZone;
        this.proportionShopZone = proportionShopZone;

        if (proportionFightZone + proportionShopZone + proportionEventZone < 100)
        {
            this.proportionRandomZone = 100-(proportionEventZone + proportionEventZone + proportionShopZone);
        }

        this.generateZones();

    }

    public void generateZones()
    {
     

    }



}
