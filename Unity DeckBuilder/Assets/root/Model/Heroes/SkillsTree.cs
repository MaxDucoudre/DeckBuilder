using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SkillsTree
{
    private int numberOfSkills;
    private int pointsToAttribute;
    private int experiencePoint;
    private Skill[] skills;

    private int index;

    public SkillsTree(int numberOfSkills)
    {

        this.pointsToAttribute = 0;
        this.experiencePoint = 0;

        this.index = 0;
        this.numberOfSkills = numberOfSkills;
        this.skills = new Skill[this.numberOfSkills];

    }

    public void loadSkillTree(StreamReader file)
    {
        string line;
        string[] subs;

        line = file.ReadLine();  // points
        subs = line.Split('\"');
        int.TryParse(subs[1], out this.pointsToAttribute);


        line = file.ReadLine();  // xp
        subs = line.Split('\"');
        int.TryParse(subs[1], out this.experiencePoint);

        for (int i = 0; i < index; i++)
        {
            this.skills[i].loadSkill(file);
        }
    }
    
    public void saveSkillTree(StreamWriter file)
    {

        file.WriteLine("points=" + "\"" + this.pointsToAttribute + "\"");
        file.WriteLine("xp=" + "\"" + this.experiencePoint + "\"");

        for (int i = 0; i < index; i++) {
            this.skills[i].saveSkill(file);
            }
    }

    public void addSkill(Skill skill)
    {
        if(this.index < this.numberOfSkills)
        {
            this.skills[this.index] = skill;
            this.index++;
        } else
        {
            Debug.Log("This SkillTree is full!");
        }
    }

    public void unlockSkill(int indexOfSkillInTab)
    {
        if(indexOfSkillInTab < this.numberOfSkills)
        {
            this.skills[indexOfSkillInTab].unlock();
        }
    }

    public int getExperiencePoint()
    {
        return this.experiencePoint;
    }

    public void setPointsToAttribute(int newPointToAttribute)
    {
        this.pointsToAttribute = newPointToAttribute;
    }

    public int getPointsToAttribute()
    {
        return this.pointsToAttribute;
    }

    public int getNumberOfSkills()
    {

        return numberOfSkills;
    }

    public Skill[] getSkills()
    {
        return skills;
    }
}
