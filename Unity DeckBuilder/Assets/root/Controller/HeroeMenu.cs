using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HeroeMenu : MonoBehaviour
{

    private Heroe[] heroes;
    private int numberOfHero, index;
    private Heroe actualhero;

    private GameObject currentSelected;
    private Skill currentSelectedSkill;
    private ImprovmentSkill currentSelectedImprovmentSkill;

    private GameObject unlockButtonSkill;
    private GameObject heroeImage;
    private TextMeshProUGUI textheroname;
    private TextMeshProUGUI textHpStat;
    private TextMeshProUGUI textManaStat;
    private TextMeshProUGUI textDesc;
    private TextMeshProUGUI textlock;
    private TextMeshProUGUI textXPStat;

    private TextMeshProUGUI textAttributePoint;
    private TextMeshProUGUI textSkillName;
    private TextMeshProUGUI textSkillDesc;


    private Skill[] skills;
    private Skill[] primarySkills = new Skill[3];
    private Skill[] basicSkills = new Skill[3];


    private GameObject skillsCanvas;
    private GameObject primaryskillsCanvas;

    private int numberOfSkillToDisplay = 3;
    private int numberOfImprovToDisplay = 3;

    private GameObject[] allButtons;

    private GameObject[] gameObjectSkills;
    private GameObject[] gameObjectPrimarySkills;
    private GameObject[,] improvmentObject;


    // Start is called before the first frame update
    void Start()
    {

        this.skillsCanvas = GameObject.Find("Skills");
        this.primaryskillsCanvas = GameObject.Find("PrimarySkills");

        this.index = 0;
        Reader reader = new Reader();
        this.heroes = reader.InstantiateHeroes();
        this.numberOfHero = this.heroes.Length;
        this.actualhero = heroes[this.index];
        this.skills = this.actualhero.getSkillTree().getSkills();


        for (int i = 0; i < this.numberOfHero; i++)
        {
            heroes[i].loadHeroe();
        }



        this.allButtons = GameObject.FindGameObjectsWithTag("buttonSkill");

        Color32 invisible = new Color32(255, 255, 255, 0);

        foreach (GameObject buttonObject in this.allButtons)
        {
            buttonObject.GetComponentInChildren<Outline>().effectColor = invisible;
        }

        this.unlockButtonSkill = GameObject.Find("ValidateSkill");

        this.textheroname = GameObject.Find("NameHero").GetComponent<TextMeshProUGUI>();
        this.textHpStat = GameObject.Find("hpText").GetComponent<TextMeshProUGUI>();
        this.textManaStat = GameObject.Find("manaText").GetComponent<TextMeshProUGUI>();
        this.textXPStat = GameObject.Find("xpText").GetComponent<TextMeshProUGUI>();
        this.textDesc = GameObject.Find("descriptionText").GetComponent<TextMeshProUGUI>();
        this.textlock = GameObject.Find("UnlockedText").GetComponent<TextMeshProUGUI>();
        this.heroeImage = GameObject.Find("Heroeimage");

        this.textAttributePoint = GameObject.Find("pointsText").GetComponent<TextMeshProUGUI>();
        this.textSkillName = GameObject.Find("skillname").GetComponent<TextMeshProUGUI>();
        this.textSkillDesc = GameObject.Find("descriptionSkill").GetComponent<TextMeshProUGUI>();

        
        this.setSkillGameObject();
        this.endSelectSkill();
        this.setHeroePanel();
    }

    public void setSkillGameObject()
    {
        gameObjectSkills = new GameObject[numberOfSkillToDisplay];
        gameObjectPrimarySkills = new GameObject[numberOfSkillToDisplay];
        improvmentObject = new GameObject[numberOfSkillToDisplay, numberOfImprovToDisplay];
        int indexBas = 1;
        int indexPrim = 1;
        int indexImprov = 1;
        int i = 0;
        int j = 0;
        for (i = 0; i < numberOfSkillToDisplay; i++)
        {
            indexImprov = 1;
            for (j = 0; j < numberOfImprovToDisplay; j++)
            {
                improvmentObject[i, j] = GameObject.Find("improvment" + indexBas + "_" + indexImprov);
                indexImprov++;
            }
            gameObjectSkills[i] = GameObject.Find("skill" + indexBas);

            gameObjectPrimarySkills[i] = GameObject.Find("primaryskill" + indexPrim);
            
            indexBas++;
            indexPrim++;
        }
    }

    void Update()
    {

        this.currentSelected = EventSystem.current.currentSelectedGameObject;
        if (this.currentSelected != null)
        {
            this.setTextDescWithButton(this.currentSelected);
        }



    }
    /*
    public Skill getSelectedSkill()
    {

    }
    */

    public void eraseOutlines()
    {
        Color32 invisible = new Color32(255, 255, 255, 0);
        Color32 color_grised = new Color32(116, 116, 116, 255);

        foreach (GameObject buttonObject in this.allButtons)
        {
            buttonObject.GetComponentInChildren<Outline>().effectColor = invisible;
        }
        this.unlockButtonSkill.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = color_grised;


    }

    public void setTextDescWithButton(GameObject selectedButton)
    {

        Color32 outline_color = new Color32(120, 120, 120, 255);
        Color32 color_normal = new Color32(225, 255, 255, 255);

        this.eraseOutlines();


        int i = 0;
        int j = 0;
        int num = 0;
        int num2 = 0;
        string buttonName;


        ImprovmentSkill[] improvments;
        if (skills != null)
        {
            if (selectedButton != null)
            {

                if (selectedButton.tag == "buttonSkill")
                {
                        selectedButton.GetComponentInChildren<Outline>().effectColor = outline_color;

                    
                        buttonName = selectedButton.name;


                        foreach (Skill skill in skills)
                        {
                            if (skill.getIfPrimarySkill() == true)
                            {
                                primarySkills[i] = skill;
                                i++;
                            }
                            else if (skill.getIfPrimarySkill() == false)
                            {
                                basicSkills[j] = skill;
                                j++;
                            }
                        }

                        if (buttonName.Substring(0, 5) == "skill")
                        {
                            int.TryParse(buttonName.Substring(5, 1), out num);
                            this.setTextDescSkill(basicSkills[num - 1]);
                            this.currentSelectedSkill = basicSkills[num - 1];
                            if (this.actualhero.getSkillTree().getPointsToAttribute() >= this.currentSelectedSkill.getCost())
                            {
                                this.unlockButtonSkill.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = color_normal;
                            }
                    }

                    else if (buttonName.Substring(0, 7) == "primary")
                        {
                            int.TryParse(buttonName.Substring(12, 1), out num);
                            this.setTextDescSkill(primarySkills[num - 1]);
                            this.currentSelectedSkill = primarySkills[num - 1];
                            this.currentSelectedImprovmentSkill = null;

                        if (this.actualhero.getSkillTree().getPointsToAttribute() >= this.currentSelectedSkill.getCost())
                            {
                                this.unlockButtonSkill.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = color_normal;
                            }
                    }



                    else if (buttonName.Substring(0, 10) == "improvment")
                        {
                            if (selectedButton.transform.parent.name.Substring(0, 5) == "skill")
                            {
                                int.TryParse(selectedButton.transform.parent.name.Substring(5, 1), out num);
                                int.TryParse(buttonName.Substring(12, 1), out num2);

                                improvments = basicSkills[num - 1].getImprovments();

                                this.setTextDescImprovment(improvments[num2 - 1], basicSkills[num - 1]);



                            // Debug.Log(basicSkills[num - 1].getLevelOfSkill().ToString() + improvments[num2 - 1].getLevelOfSkill().ToString());

                            if (improvments[num2 - 1].isUnlockable() == true)
                            {
                                if (improvments[num2 - 1].getCost() <= this.actualhero.getSkillTree().getPointsToAttribute())
                                {
                                    this.unlockButtonSkill.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = color_normal;
                                }
                                this.currentSelectedSkill = basicSkills[num - 1];
                                this.currentSelectedImprovmentSkill = improvments[num2 - 1];
                            } else
                            {
                                this.currentSelectedImprovmentSkill = null;
                                this.currentSelectedSkill = null;
                            }
                            

                            
                            }
                    }
                }
            } else
            {
                //this.endSelectSkill();
            }

        }
    }

    public void endSelectSkill()
    {
        Color32 color_grised = new Color32(116, 116, 116, 255);
        this.eraseOutlines();
        this.currentSelectedImprovmentSkill = null;
        this.currentSelectedSkill = null;
        this.eraseTextDescSkill();
        this.unlockButtonSkill.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = color_grised;

    }

    public void eraseTextDescSkill()
    {
        this.textSkillName.text = " ";
        this.textSkillDesc.text = " ";
    }

    public void setTextDescSkill(Skill skill)
    {
        if(skill.getIfPrimarySkill() == false) { 
            this.textSkillName.text = skill.getName() + " : Level 1";
        } else
        {
            this.textSkillName.text = skill.getName();
        }
        this.textSkillDesc.text = skill.getDesc();
    }

    public void setTextDescImprovment(ImprovmentSkill improvment, Skill skill)
    {

        this.textSkillName.text = skill.getName() + " : Level " + improvment.getLevelOfSkill();
        this.textSkillDesc.text = improvment.getDescription();
    }

    public void setHeroePanel()
    {
        // The hero
        Image image;

        image = this.heroeImage.GetComponent<Image>();
        image.sprite = this.actualhero.getSprite();

        this.textheroname.text = this.actualhero.getName();
        this.textHpStat.text = "HP : " + Convert.ToString(this.actualhero.getDefaultHP());
        this.textManaStat.text = "Mana : " + Convert.ToString(this.actualhero.getDefaultMana());
        this.textXPStat.text = "XP : " + Convert.ToString(this.actualhero.getSkillTree().getExperiencePoint());
        this.textDesc.text = Convert.ToString(this.actualhero.getDescription());
        if (this.actualhero.getIsUnlocked() == true)
        {
            this.textlock.text = "Unlocked";
        }
        else
        {
            this.textlock.text = "Locked";
        }

        // The skilltree
        //this.eraseTextDescSkill();

        this.textAttributePoint.text = Convert.ToString(this.actualhero.getSkillTree().getPointsToAttribute());

        this.skills = this.actualhero.getSkillTree().getSkills();

        TextMeshProUGUI childText;
        int indexBas = 1;
        int indexPrim = 1;
        int indexImprov = 1;
        int i = 0;
        int j = 0;
        for (i = 0; i < numberOfSkillToDisplay; i++)
        {

            indexImprov = 1;
            for (j = 0; j < numberOfImprovToDisplay; j++)
            {
                improvmentObject[i, j].SetActive(false);
                indexImprov++;
            }
            gameObjectSkills[i].SetActive(false);
            gameObjectPrimarySkills[i].SetActive(false);
            indexBas++;
            indexPrim++;
        }
            ImprovmentSkill[] improvments;

         indexBas = 1;
         indexPrim = 1;
         indexImprov = 1;
         i = 0;
         j = 0;
        Color32 locked_color = new Color32(156, 156, 156, 255);
        Color32 unlocked_color = new Color32(255, 255, 255, 255);

        for (i = 0; i < this.actualhero.getSkillTree().getNumberOfSkills(); i++)
        {
            if (skills[i].getIfPrimarySkill() == true)
            {
                gameObjectPrimarySkills[indexPrim - 1].SetActive(true);
                image = gameObjectPrimarySkills[indexPrim - 1].GetComponent<Image>();

                childText = gameObjectPrimarySkills[indexPrim - 1].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                if (this.skills[i].getIsUnlocked() == true)
                {
                    gameObjectPrimarySkills[indexPrim - 1].GetComponent<Image>().color = unlocked_color;
                    childText.text = "";
                }
                else
                {
                    gameObjectPrimarySkills[indexPrim - 1].GetComponent<Image>().color = locked_color;

                    childText.text = this.skills[i].getCost().ToString();
                }


                image.sprite = this.skills[i].getSprite();
                indexPrim++;
            }

            if (skills[i].getIfPrimarySkill() == false)
            {

                indexImprov = 1;
                for (j = 0; j < this.skills[i].getMaxLevelOfSkill()-1; j++)
                {
                    improvmentObject[indexBas - 1, indexImprov - 1].SetActive(true);
                    image = improvmentObject[indexBas - 1, indexImprov - 1].GetComponent<Image>();
                    image.sprite = this.skills[i].getSprite();

                    childText = improvmentObject[indexBas - 1, indexImprov - 1].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

                    improvments = this.skills[i].getImprovments();

                   // Debug.Log("Skill Level : " + this.skills[i].getLevelOfSkill().ToString() + " Improvmentlevel : " + improvments[j].getLevelOfSkill());
                    if (this.skills[i].getLevelOfSkill() >= improvments[j].getLevelOfSkill())
                    {
                        improvmentObject[indexBas - 1, indexImprov - 1].GetComponent<Image>().color = unlocked_color;
                        childText.text ="";
                    }
                    else
                    {
                        improvmentObject[indexBas - 1, indexImprov - 1].GetComponent<Image>().color = locked_color;
                        childText.text = improvments[j].getCost().ToString();
                    }



                    indexImprov++;
                }

                gameObjectSkills[indexBas - 1].SetActive(true);
                image = gameObjectSkills[indexBas - 1].GetComponent<Image>();
                image.sprite = this.skills[i].getSprite();

                childText = gameObjectSkills[indexBas - 1].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                if (this.skills[i].getIsUnlocked() == true)
                {

                    gameObjectSkills[indexBas - 1].GetComponent<Image>().color = unlocked_color;
                    childText.text = "";
                }
                else
                {
                    gameObjectSkills[indexBas - 1].GetComponent<Image>().color = locked_color;
                    childText.text = this.skills[i].getCost().ToString();
                }


                indexBas++;

            }
        }
        
    }


    public void nextHeroe()
    {

        this.index++;
        if(this.index >= this.numberOfHero)
        {
            this.index = 0;
        }

        this.actualhero = heroes[this.index];

        this.endSelectSkill();
        this.setHeroePanel();
    }

    public void previousHeroe()
    {
        this.index--;
        if (this.index < 0)
        {
            this.index = this.numberOfHero-1;
        }

        this.actualhero = heroes[this.index];
        this.endSelectSkill();
        this.setHeroePanel();
    }



    public void selectHeroe()
    {
        this.leftMenu();
        Party party = new Party();

        SceneManager.LoadScene("Scene/MapScene");
    }

    public void backButton()
    {
    }

    public void validateSkill()
    {
        for (int i = 0; i < this.numberOfHero; i++)
        {
            heroes[i].saveHeroe();
        }


        this.setHeroePanel();
    }

    public void unlockSkillButton()
    {

        if (this.currentSelectedSkill != null)
        {
            if (this.actualhero.getSkillTree().getPointsToAttribute() >= this.currentSelectedSkill.getCost() && this.currentSelectedImprovmentSkill == null)
            {
                if (this.currentSelectedSkill.getIsUnlocked() == false)
                {

                    this.actualhero.getSkillTree().setPointsToAttribute(this.actualhero.getSkillTree().getPointsToAttribute() - this.currentSelectedSkill.getCost());
                    this.currentSelectedSkill.unlock();
                    this.actualhero.saveHeroe();
                    this.setHeroePanel();
                }
            }
            else
            {
               // Debug.Log("Not enough attribute points!");
            }
        }
        else
        {
         //   Debug.Log("You have to select attribute!");
        }

        if (this.currentSelectedImprovmentSkill != null && this.currentSelectedSkill != null)
        {
            if (this.currentSelectedImprovmentSkill.isUnlockable() == true)
            {
                if (this.currentSelectedImprovmentSkill.getCost() <= this.actualhero.getSkillTree().getPointsToAttribute()) {
                    this.actualhero.getSkillTree().setPointsToAttribute(this.actualhero.getSkillTree().getPointsToAttribute() - this.currentSelectedImprovmentSkill.getCost());
                    this.currentSelectedSkill.improveSkill();
                    this.actualhero.saveHeroe();
                    this.setHeroePanel();
                }
                
            }
            else
            {
               // Debug.Log("You have to unlock previous skills!");
            }
        }
        else
        {
           //Debug.Log("You have to select an improvment!");
        }
    }

        public void leftMenu()
    {
        this.endSelectSkill();
        this.actualhero.saveHeroe();
        //validateSkill();
    }


}
