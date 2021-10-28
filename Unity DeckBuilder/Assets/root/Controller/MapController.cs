using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject mapObject = GameObject.Find("Map");
        int tailleMap = 10;

        new FloorView(1, mapObject, tailleMap);
        new FloorView(2, mapObject, tailleMap);
        new FloorView(3, mapObject, tailleMap);
        new FloorView(4, mapObject, tailleMap);
        new FloorView(5, mapObject, tailleMap);
        new FloorView(6, mapObject, tailleMap);
        new FloorView(7, mapObject, tailleMap);
        new FloorView(8, mapObject, tailleMap);
        new FloorView(9, mapObject, tailleMap);
        new FloorView(10, mapObject, tailleMap);

        /*
        FloorView[] floorsView = new FloorView[tailleMap];

        for (int i = 0; i < tailleMap; i++) 
        {
            floorsView[i] = new FloorView(i + 1, mapObject, tailleMap);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
