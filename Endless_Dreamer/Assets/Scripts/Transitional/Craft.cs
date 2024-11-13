using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Craft : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;

    public Text stone_dust_craft;
    public Text flower_dust_craft;
    public Text living_dust_craft;

    public Text score_potion_craft;
    public Text debuff_potion_craft;
    public Text health_potion_craft;

    public Text stone_dust_mill;
    public Text flower_dust_mill;
    public Text living_dust_mill;

    public Text glowstone_mill;
    public Text orchid_mill;
    public Text firefly_mill;

    void Start()
    {
        stone_dust_craft.text = "" + GameManager.manager.stoneDust;
        flower_dust_craft.text = "" + GameManager.manager.flowerDust;
        living_dust_craft.text = "" + GameManager.manager.livingDust;

        score_potion_craft.text = "" + GameManager.manager.yellowPotion;
        debuff_potion_craft.text = "" + GameManager.manager.greenPotion;
        health_potion_craft.text = "" + GameManager.manager.redPotion;

        stone_dust_mill.text = "" + GameManager.manager.stoneDust;
        flower_dust_mill.text = "" + GameManager.manager.flowerDust;
        living_dust_mill.text = "" + GameManager.manager.livingDust;

        glowstone_mill.text = "" + GameManager.manager.glowStones;
        orchid_mill.text = "" + GameManager.manager.orchids;
        firefly_mill.text = "" + GameManager.manager.fireflies;
    }

    void Update()
    {

    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void CraftingTab()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
    }
    public void MillingTab()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
    }

    public void HoverOn(GameObject settingsPanel)
    {
        settingsPanel.SetActive(true);
    }
    public void HoverOff(GameObject settingsPanel)
    {
        settingsPanel.SetActive(false);
    }

    //crafting functions
    public void ScorePotion()
    {
        if (GameManager.manager.stoneDust >= 2 && GameManager.manager.flowerDust >= 1 && GameManager.manager.livingDust >= 2)
        {
            GameManager.manager.stoneDust -= 2;
            GameManager.manager.flowerDust -= 1;
            GameManager.manager.livingDust -= 2;
            GameManager.manager.yellowPotion += 1;

            stone_dust_craft.text = "" + GameManager.manager.stoneDust;
            flower_dust_craft.text = "" + GameManager.manager.flowerDust;
            living_dust_craft.text = "" + GameManager.manager.livingDust;
            score_potion_craft.text = "" + GameManager.manager.yellowPotion;

            GameManager.manager.Save();
        }
        else
        {
            Debug.Log("Not enough resources to craft Score Potion.");
        }
    }
    public void DebuffPotion()
    {
        if (GameManager.manager.stoneDust >= 1 && GameManager.manager.flowerDust >= 3 && GameManager.manager.livingDust >= 2)
        {
            GameManager.manager.stoneDust -= 1;
            GameManager.manager.flowerDust -= 3;
            GameManager.manager.livingDust -= 2;
            GameManager.manager.greenPotion += 1;

            stone_dust_craft.text = "" + GameManager.manager.stoneDust;
            flower_dust_craft.text = "" + GameManager.manager.flowerDust;
            living_dust_craft.text = "" + GameManager.manager.livingDust;
            debuff_potion_craft.text = "" + GameManager.manager.greenPotion;

            GameManager.manager.Save();
        }
        else
        {
            Debug.Log("Not enough resources to craft Score Potion.");
        }
    }
    public void HealthPotion()
    {
        if (GameManager.manager.stoneDust >= 2 && GameManager.manager.flowerDust >= 2 && GameManager.manager.livingDust >= 3)
        {
            GameManager.manager.stoneDust -= 2;
            GameManager.manager.flowerDust -= 2;
            GameManager.manager.livingDust -= 3;
            GameManager.manager.redPotion += 1;

            stone_dust_craft.text = "" + GameManager.manager.stoneDust;
            flower_dust_craft.text = "" + GameManager.manager.flowerDust;
            living_dust_craft.text = "" + GameManager.manager.livingDust;
            health_potion_craft.text = "" + GameManager.manager.redPotion;

            GameManager.manager.Save();
        }
        else
        {
            Debug.Log("Not enough resources to craft Score Potion.");
        }
    }

    //milling functions
    public void GlowStone()
    {
        if (GameManager.manager.glowStones >= 1)
        {
            GameManager.manager.glowStones -= 1;
            GameManager.manager.stoneDust += 1;

            stone_dust_mill.text = "" + GameManager.manager.stoneDust;
            glowstone_mill.text = "" + GameManager.manager.glowStones;

            GameManager.manager.Save();
        }
    }
    public void Orchid()
    {
        if (GameManager.manager.orchids >= 1)
        {
            GameManager.manager.orchids -= 1;
            GameManager.manager.flowerDust += 1;

            flower_dust_mill.text = "" + GameManager.manager.flowerDust;
            orchid_mill.text = "" + GameManager.manager.orchids;

            GameManager.manager.Save();
        }
    }
    public void FireFly()
    {
        if (GameManager.manager.fireflies >= 1)
        {
            GameManager.manager.fireflies -= 1;
            GameManager.manager.livingDust += 1;

            living_dust_mill.text = "" + GameManager.manager.livingDust;
            firefly_mill.text = "" + GameManager.manager.fireflies;

            GameManager.manager.Save();
        }
    }
}
