using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Costs costs;

    //character tab var
    public Text coin_count_display;
    public Text gem_count_display;

    public TMP_Text forestButton;
    public TMP_Text desertButton;
    public TMP_Text cloudsButton;
    public TMP_Text dungeonButton;

    void Start()
    {
        // character tab
        coin_count_display.text = "" + GameManager.manager.coins;
        gem_count_display.text = "" + GameManager.manager.gems;

        UpdateMapButtons();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Upgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }

    public void ShowRewards(GameObject settingsPanel)
    {
        if (settingsPanel.activeSelf == false)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }
    public void HoverOn(GameObject settingsPanel)
    {
        settingsPanel.SetActive(true);
    }
    public void HoverOff(GameObject settingsPanel)
    {
        settingsPanel.SetActive(false);
    }
    // Buying and/or switching to chacters
    public void BuyForest()
    {
        GameManager.manager.currentMap = 0;
        GameManager.manager.Save();
        UpdateMapButtons();
    }
    public void BuyDesert()
    {
        if (GameManager.manager.desert == true)
        {
            GameManager.manager.currentMap = 1;
        }
        else
        {
            if (GameManager.manager.coins >= costs.desertCost)
            {
                GameManager.manager.coins -= costs.desertCost;
                GameManager.manager.desert = true;
                GameManager.manager.currentMap = 1;
            }
        }
        GameManager.manager.Save();
        UpdateMapButtons();
    }
    public void BuyClouds()
    {
        if (GameManager.manager.clouds == true)
        {
            GameManager.manager.currentMap = 2;
        }
        else
        {
            if (GameManager.manager.coins >= costs.cloudsCost)
            {
                GameManager.manager.coins -= costs.cloudsCost;
                GameManager.manager.clouds = true;
                GameManager.manager.currentMap = 2;
            }
        }
        GameManager.manager.Save();
        UpdateMapButtons();
    }
    public void BuyDungeon()
    {
        if (GameManager.manager.dungeon == true)
        {
            GameManager.manager.currentMap = 3;
        }
        else
        {
            if (GameManager.manager.gems >= costs.dungeonCost)
            {
                GameManager.manager.gems -= costs.dungeonCost;
                GameManager.manager.dungeon = true;
                GameManager.manager.currentMap = 3;
            }
        }
        GameManager.manager.Save();
        UpdateMapButtons();
    }
    private void UpdateMapButtons()
    {
        UpdateButtonText(forestButton, GameManager.manager.forest, 0, 0);
        UpdateButtonText(desertButton, GameManager.manager.desert, costs.desertCost, 1);
        UpdateButtonText(cloudsButton, GameManager.manager.clouds, costs.cloudsCost, 2);
        UpdateButtonText(dungeonButton, GameManager.manager.dungeon, costs.dungeonCost, 3);
    }

    private void UpdateButtonText(TMP_Text button, bool isOwned, float cost, int characterIndex)
    {
        if (GameManager.manager.currentMap == characterIndex)
        {
            button.text = "Active";
        }
        else if (isOwned == true)
        {
            button.text = "Switch";
        }
        else
        {
            button.text = "" + cost;
        }
    }
}

