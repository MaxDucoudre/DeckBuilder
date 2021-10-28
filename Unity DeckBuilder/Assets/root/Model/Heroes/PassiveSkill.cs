using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    public PassiveSkill(string idSkill, string name, string description, int maxlevelofskill, int cost, Skill parentSkill, string pathsprite) 
         : base(idSkill, name, description, maxlevelofskill, cost, parentSkill, pathsprite)
    {
        
    }
}
