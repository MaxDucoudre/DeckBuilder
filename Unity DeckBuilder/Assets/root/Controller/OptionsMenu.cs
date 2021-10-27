using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private Parameters parameters;

    void Start()
    {
        this.parameters = new Parameters();
    }

    void Update()
    {
        this.selectButtonDifficultyDefault();
    }

    public void selectButtonDifficultyDefault()
    {
        string textDiff = this.parameters.getNameOfNPDifficulty();
        GameObject easydesc = GameObject.Find("EasyDescription");
        GameObject normaldesc = GameObject.Find("NormalDescription");
        GameObject harddesc = GameObject.Find("HardDescription");

        GameObject myEventSystem = GameObject.Find("EventSystem");
        if (textDiff == "easy")
        {
            GameObject buttonObject = GameObject.Find("EasyButton");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(buttonObject);
            easydesc.transform.localScale = new Vector3(1, 1, 1);
            normaldesc.transform.localScale = new Vector3(0, 0, 0);
            harddesc.transform.localScale = new Vector3(0, 0, 0);

        } else if (textDiff == "normal") {
            GameObject buttonObject = GameObject.Find("NormalButton");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(buttonObject);
            easydesc.transform.localScale = new Vector3(0, 0, 0);
            normaldesc.transform.localScale = new Vector3(1, 1, 1);
            harddesc.transform.localScale = new Vector3(0, 0, 0);


        } else if (textDiff == "hard") {
            GameObject buttonObject = GameObject.Find("HardButton");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(buttonObject);
            easydesc.transform.localScale = new Vector3(0, 0, 0);
            normaldesc.transform.localScale = new Vector3(0, 0, 0);
            harddesc.transform.localScale = new Vector3(1, 1, 1);

        }
    }


    public void useButtonHard()
    {
        this.parameters.selectDifficulty("hard");
    }

    public void useButtonNormal()
    {
        this.parameters.selectDifficulty("normal");
    }

    public void useButtonEasy()
    {
        this.parameters.selectDifficulty("easy");
    }

    public void useButtonCancel()
    {
        this.parameters.cancelParameters();
    }

    public void useButtonValidate()
    {
        this.parameters.validateParameters();
    }
}
