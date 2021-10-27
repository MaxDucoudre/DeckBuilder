using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    private int cooldown;

    public ActiveSkill(string idSkill, string name, string description, int maxlevelofskill, int cost, Skill parentSkill, string pathsprite)
         : base(idSkill, name, description, maxlevelofskill, cost, parentSkill, pathsprite)
    {

    }

    public void useSkill()
    {

    }

    public int getCooldown()
    {
        return this.cooldown;
    }

}
