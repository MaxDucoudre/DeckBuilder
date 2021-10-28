using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneView 
{
    private GameObject zoneViewObject;

    public ZoneView(Zone zone)
    {
        this.zoneViewObject = new GameObject("Zone");
        this.zoneViewObject.AddComponent<RectTransform>();
        //this.zoneViewObject.AddComponent<Image>();
        //RectTransform rtFloorViewObject = (RectTransform)floorViewObject.transform;


    }

    public GameObject getZoneViewObject()
    {
        return this.zoneViewObject;
    }

}
