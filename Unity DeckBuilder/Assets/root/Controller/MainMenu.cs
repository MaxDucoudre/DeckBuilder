using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {


    }

    public void PlayButton()
    {
        // SceneManager.LoadScene("Scene/MapScene");





    }

    public void OptionButton()
    {
    }

    public void QuitButton() 
    {
        Debug.Log("Quit !");
        Application.Quit();
    }



 }
