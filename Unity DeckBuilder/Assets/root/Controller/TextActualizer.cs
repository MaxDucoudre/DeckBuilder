using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextActualizer
{
    void start()
    {

    }

    public void setText(Text changingText, string text)
    {
        changingText.text = text;
    }

    public void setText(GameObject changingTextGameObject, string text)
    {
       changingTextGameObject.GetComponent<Text>().text = text;
    }

}
