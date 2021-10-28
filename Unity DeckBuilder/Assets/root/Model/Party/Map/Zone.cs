using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone 
{
    private List<Zone> childZone = new List<Zone>();
    private int maxchildZone = 3;
    protected string zoneType = null;

    public Zone()
    {
        this.childZone.Capacity = this.maxchildZone;
    }


    public void addParentZone(Zone zone)
    {
        this.childZone.Add(zone);
    }

    public List<Zone> getChildZones()
    {
        return this.childZone;
    }
}
