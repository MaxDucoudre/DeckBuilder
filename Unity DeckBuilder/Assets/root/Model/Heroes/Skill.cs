using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public abstract class Skill
{
    private string skillId;
    private string description;
    private string name;
    private int levelOfSkill;
    protected int maxLevelOfSkill;
    private int cost;
    private ImprovmentSkill[] improvments;
    protected bool isPrimarySkill;
    protected Sprite sprite;

    private bool isUnlocked;
    private Skill parentSkill;

    private int index;


    public Skill(string idSkill, string name, string description, int maxlevelofskill, int cost, Skill parentSkill, string pathsprite)
    {

        this.isPrimarySkill = false;
        this.skillId = idSkill;
        this.name = name;
        this.description = description;
        this.levelOfSkill = 0;
        this.maxLevelOfSkill = maxlevelofskill;
        this.improvments = new ImprovmentSkill[this.maxLevelOfSkill];
        this.index = 0;
        this.cost = cost;
        this.parentSkill = parentSkill;

        this.sprite = Resources.Load<Sprite>("Sprites/SkillSprites/"+pathsprite);

        // default temporary
        this.isUnlocked = false;
        this.levelOfSkill = 0;

    }


    public void loadSkill(StreamReader file)
    {
        string line;
        string[] subs;

        line = file.ReadLine();  // void
        line = file.ReadLine();  // id
        subs = line.Split('\"');
        //Debug.Log("id = " + subs[1]);

        line = file.ReadLine();  // level
        subs = line.Split('\"');
        int.TryParse(subs[1], out this.levelOfSkill);
        //Debug.Log(this.levelOfSkill.ToString() + "=" + subs[1]);
        line = file.ReadLine();  // unlocked
        subs = line.Split('\"');
        subs = line.Split('\"');
        if (subs[1] == "True")
        {
            this.isUnlocked = true;
        }
        else
        {
            this.isUnlocked = false;
        }

    }

    public void saveSkill(StreamWriter file)
    {
        file.WriteLine("");
        file.WriteLine("idSkill=" + "\"" + this.skillId + "\"");
        file.WriteLine("level=" + "\"" + this.levelOfSkill + "\"");
        file.WriteLine("unlocked=" + "\"" + this.isUnlocked + "\"");
    }


    public void unlock()
    {
        if(this.getIsUnlocked() == true)
        {
            Debug.Log("Already Unlocked !");
        } else
        {
            this.isUnlocked = true;
            this.levelOfSkill = 1;
        }
    }

    public void addImprovment(ImprovmentSkill improvmentskill)
    {
        if (this.index < this.maxLevelOfSkill) 
        {
            this.improvments[this.index] = improvmentskill;
            this.index++;
        } else
        {
            Debug.Log("You can't add more improvment to this skill!");

        }

    }

    public void improveSkill()
    {
        if(this.levelOfSkill < this.maxLevelOfSkill)
        {
            this.levelOfSkill++;
            // unlock Improvment skill
        } else
        {
            Debug.Log("You already reached the max level for this skill!");
        }
    }


    public int getLevelOfSkill()
    {
        return this.levelOfSkill;
    }

    public int getMaxLevelOfSkill()
    {
        return this.maxLevelOfSkill;
    }

    public bool getIsUnlocked()
    {
        return isUnlocked;
    }

    public bool getIfPrimarySkill()
    {
        return this.isPrimarySkill;
    }

    // During party
    public void enableSkill()
    {

    }


    public Sprite getSprite()
    {
        return this.sprite;
    }

    public string getName()
    {
        return this.name;
    }
    public string getDesc()
    {
        return this.description;
    }

    public ImprovmentSkill[] getImprovments()
    {
        return this.improvments;
    }

    public int getCost()
    {
        return this.cost;
    }
}
