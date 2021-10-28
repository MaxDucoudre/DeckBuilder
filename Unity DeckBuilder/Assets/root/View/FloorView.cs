using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorView
{
    private GameObject floorViewObject;
    private int maxZone = 3;

    public FloorView(int numFloor, GameObject map, int sizeOfPartyMap)
    {

        // Creation de l'objet
        this.floorViewObject = new GameObject("Floor" + numFloor.ToString(), typeof(RectTransform));

       this.floorViewObject.transform.SetParent(map.transform);     // Je rend l'object fils de la map


        // je récupère la taille de la map
        GameObject imageObj = GameObject.Find("BackgroundImage");
        RectTransform rtMap = (RectTransform)map.transform;
        RectTransform rtImage = (RectTransform)imageObj.transform;
        float widthMap = rtImage.rect.width;
        float heightMap = rtImage.rect.height;
        float mapX = rtImage.localPosition.x;
        float mapY = rtImage.localPosition.y;
        

        // j'applique les mesures au floor
        RectTransform rtFloor = (RectTransform)this.floorViewObject.transform;

        rtFloor.localPosition = new Vector2((mapX + (widthMap / sizeOfPartyMap) * (numFloor - 1)) - 456, mapY); // a revoir
        rtFloor.sizeDelta = new Vector2((int)widthMap / sizeOfPartyMap, heightMap);


        //floorViewObject.GetComponent(RectTransform).sizeDelta = new Vector2( (int)widthMap/sizeOfPartyMap, heightMap);



    }

    public void addZone(ZoneView zoneView) 
    {
        GameObject zoneViewObject = zoneView.getZoneViewObject(); // je recupère le gameObject de la zone
        zoneViewObject.transform.parent = this.floorViewObject.transform; // je rend la zone fils du floor

    }


    public GameObject getFloorViewObject()
    {
        return this.floorViewObject;
    }

}
