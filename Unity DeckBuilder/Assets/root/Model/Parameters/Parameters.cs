using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
 
public class Parameters
{
    private Difficulty difficulty;
    private Difficulty npDifficulty = null;
    //private Language langage;

    public Parameters()
    {
        this.selectDifficulty(this.getSavedDifficulty());
        this.validateParameters();
        Debug.Log("Parameters created !");
    }

    public string getNameOfNPDifficulty()
    {
        if(this.npDifficulty == null)
        {
            return this.getSavedDifficulty();
        } else
        {
            return this.npDifficulty.getName();
        }
    }

    public void saveDifficulty(Difficulty difficulty)
    { 
        string text = difficulty.getName();
        File.WriteAllText("Assets/root/Data/Parameters/saveDifficulty.txt", text);
        Debug.Log("Difficulty saved in file!");

    }

    public string getSavedDifficulty()
    {
        string text = System.IO.File.ReadAllText("Assets/root/Data/Parameters/saveDifficulty.txt");
        Debug.Log(text);
        return text;

    }

    public void validateParameters()
    {
        if (this.npDifficulty != null)
        {
            this.difficulty = this.npDifficulty;
        }
        this.saveDifficulty(this.difficulty);
        Debug.Log("Parameters were validated!");
    }

    public void cancelParameters()
    {
        this.npDifficulty = null;
        Debug.Log("Parameters were canceled!");
    }

    public void selectDifficulty(string dstring)
    {
        Difficulty d;
        if (dstring == "easy")
        {
            d = new Difficulty("easy", "The difficulty for casual players", 0, 0, 0, 0);
            this.npDifficulty = d;
        }
        else if (dstring == "normal")
        {
            d = new Difficulty("normal", "The classic experience of the game", 10, 10, 10, 10);
            this.npDifficulty = d;
        }
        else if (dstring == "hard")
        {
            d = new Difficulty("hard", "Only for experimented players", 20, 20, 20, 20);
            this.npDifficulty = d;
        }
        else
        {
            Debug.Log("Wrong argument in selectDifficulty, this difficulty doesn't exist!");
            Application.Quit();
        }

        Debug.Log("Difficulty selected!");
    }

    public Difficulty getDifficulty()
    {
        return this.difficulty;
    }

    
    //public void selectLanguage(){}
    //public Language getLanguage(){}
    
}
