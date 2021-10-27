using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Heroe
{
    private string id;
    private string name;
    private string desc;
    private bool isUnlocked;
    private int defaultHP;
    private int defaultMana;
    private SkillsTree skillTree;
    private Sprite sprite;

    public Heroe(string id, string name, string desc, int defaultHP, int defaultMana, SkillsTree skilltree, string heroesprite)
    {
        
        // default temporary
        this.isUnlocked = true;

        this.id = id;
        this.name = name;
        this.defaultHP = defaultHP;
        this.defaultMana = defaultMana; 
        this.skillTree = skilltree;
        this.desc = desc;
        this.sprite = Resources.Load<Sprite>("Sprites/HeroeSprites/" + heroesprite);


        this.loadHeroe();
    }


    public void loadHeroe()
    {
        try
        {
            StreamReader file = new StreamReader("Assets/root/Data/HeroeData/save/" + id + ".txt");
            string line;
            string[] subs;
            line = file.ReadLine(); // id
            line = file.ReadLine(); // isUnlocked

            subs = line.Split('\"');
            if(subs[1] == "True")
            {
                this.isUnlocked = true;
            } else
            {
                this.isUnlocked = false;
            }

            this.skillTree.loadSkillTree(file);

            file.Close();
        }
        catch
        {
            Debug.Log("Error updating hero!");
        }
    }

    public void saveHeroe()
    {
        try
        {
            StreamWriter file = new StreamWriter("Assets/root/Data/HeroeData/save/" + id + ".txt");
            file.WriteLine("id=" + "\"" + this.id + "\"");
            file.WriteLine("isUnlocked=" + "\"" + this.isUnlocked + "\"");

            this.skillTree.saveSkillTree(file);

            file.Close();

        } catch
        {
            Debug.Log("Error during heroe save!");

        }

    }

    public void unlock()
    {
        if (this.isUnlocked == false)
        {
            this.isUnlocked = true;
        }
        else
        {
            Debug.Log("This heroe is already unlocked!");
        }
    }


    public string getName()
    {
        return this.name;
    }

    
    public string getDescription()
    {
        return desc;
    }
    
    public bool getIsUnlocked()
    {
        return isUnlocked;
    }

    public int getDefaultHP()
    {
        return defaultHP;
    }

    public int getDefaultMana()
    {
        return defaultMana;
    }

    public SkillsTree getSkillTree()
    {
        return skillTree;
    }

    public Sprite getSprite()
    {
        return this.sprite;
    }
}
