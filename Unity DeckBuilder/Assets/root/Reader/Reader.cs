using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class Reader
{

    public Reader()
    {

    }

    public Heroe[] InstantiateHeroes()
    {

        Heroe[] heroes = null;
        string id_heroe;
        string nom_heroe;
        string desc_heroe;
        int maxHP_heroe;
        int maxMana_heroe;
        string sprite_heroe;

        SkillsTree[] skilltree;
        int numberOfSkill;
        int i, j, k;

        Skill[] skills;
        string id_skill;
        string name_skill;
        string desc_skill;
        bool isPassive_skill;
        int maxLevel_skill;
        int cost_skill;
        bool isPrimarySkill;
        string sprite_skill;

        ImprovmentSkill[] improvments;
        string name_improvment;
        string desc_improvment;
        int level_improvment;
        int cost_improvment;

        string path = "Assets/root/data/HeroeData/heroes.xml";
        try
        {

            int numberofHeroes = 0;
            var reader = XmlReader.Create(path);
            while (reader.ReadToFollowing("Heroe")) {numberofHeroes++;}
            
            heroes = new Heroe[numberofHeroes];
            skilltree = new SkillsTree[numberofHeroes];

            reader = XmlReader.Create(path);
            k = 0;
            while (reader.ReadToFollowing("Heroe"))
            {
                // Heroe
                reader.MoveToFirstAttribute();
                id_heroe = reader.Value;

                reader.MoveToNextAttribute();
                nom_heroe = reader.Value;

                reader.MoveToNextAttribute();
                desc_heroe = reader.Value;

                reader.MoveToNextAttribute();
                int.TryParse(reader.Value, out maxHP_heroe);

                reader.MoveToNextAttribute();
                int.TryParse(reader.Value, out maxMana_heroe);

                reader.MoveToNextAttribute();
                sprite_heroe = reader.Value;

                // Skill tree
                reader.ReadToFollowing("skills");

                reader.MoveToFirstAttribute();
                int.TryParse(reader.Value, out numberOfSkill);
                skilltree[k] = new SkillsTree(numberOfSkill);


                // Skills

                skills = new Skill[numberOfSkill];
                for (i = 0; i < numberOfSkill; i++)
                {
                    reader.ReadToFollowing("skill");

                    reader.MoveToFirstAttribute();
                    id_skill = reader.Value;

                    reader.MoveToNextAttribute();
                    name_skill = reader.Value;

                    reader.MoveToNextAttribute();
                    desc_skill = reader.Value;

                    reader.MoveToNextAttribute();
                    if(reader.Value == "true")
                    {
                        isPassive_skill = true;
                    } else
                    {
                        isPassive_skill = false;
                    }


                    reader.MoveToNextAttribute();
                    int.TryParse(reader.Value, out maxLevel_skill);

                    reader.MoveToNextAttribute();
                    int.TryParse(reader.Value, out cost_skill);

                    reader.MoveToNextAttribute();
                    if (reader.Value == "true")
                    {
                        isPrimarySkill = true;
                    }
                    else
                    {
                        isPrimarySkill = false;
                    }

                    reader.MoveToNextAttribute();
                    sprite_skill = reader.Value;


                    if (isPrimarySkill == true) {
                        skills[i] = new PrimarySkill(id_skill, name_skill, desc_skill, maxLevel_skill, cost_skill, null, sprite_skill);
                    }
                    else  if (isPassive_skill == true)
                    {
                        skills[i] = new PassiveSkill(id_skill, name_skill, desc_skill, maxLevel_skill, cost_skill, null, sprite_skill);
                    }
                    else if (isPassive_skill == false)
                    {
                        skills[i] = new ActiveSkill(id_skill, name_skill, desc_skill, maxLevel_skill, cost_skill, null, sprite_skill);
                    } 



                    skilltree[k].addSkill(skills[i]);

                    // Improvments
                    improvments = new ImprovmentSkill[maxLevel_skill - 1];
                    for (j = 0; j < maxLevel_skill - 1; j++)
                    {
                        reader.ReadToFollowing("improvment");

                        reader.MoveToFirstAttribute();
                        name_improvment = reader.Value;

                        reader.MoveToNextAttribute();
                        desc_improvment = reader.Value;

                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out level_improvment);

                        reader.MoveToNextAttribute();
                        int.TryParse(reader.Value, out cost_improvment);

                        //improvments[j] = new ImprovmentSkill(name_improvment, desc_improvment, cost_improvment);
                        skills[i].addImprovment(new ImprovmentSkill(name_improvment, desc_improvment, level_improvment, cost_improvment, skills[i]));


                    }


                }


                //(string id, string nom, string desc, int defaultHP, int defaultMana, SkillsTree skilltree)

                heroes[k] = new Heroe(id_heroe, nom_heroe, desc_heroe, maxHP_heroe, maxMana_heroe, skilltree[k], sprite_heroe);

                k++;
            }



            reader.Close();

        }
        catch 
        {
            Debug.Log("Xml Reading Failed!");

        }

        return heroes;

    }
}
