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

    public Animator Amy;
    public Animator Aj;
    public Animator Claire;
    public Animator Granny;
    public Animator Michelle;

    public TMP_Text AmyButton;
    public TMP_Text AjButton;
    public TMP_Text ClaireButton;
    public TMP_Text GrannyButton;
    public TMP_Text MichelleButton;

    public TMP_Text AmyLevel;
    public TMP_Text AjLevel;
    public TMP_Text ClaireLevel;
    public TMP_Text GrannyLevel;
    public TMP_Text MichelleLevel;

    //apothecary tab var
    public Text coin_display_apothecary;
    public Text gem_display_apothecary;

    public Text stone_dust_display_apothecary;
    public Text flower_dust_display_apothecary;
    public Text living_dust_display_apothecary;

    public Text health_potion_display_apothecary;
    public Text score_potion_display_apothecary;
    public Text debuff_potion_display_apothecary;

    public Text coin_display_shop;
    public Text gem_display_shop;

    //changing tabs
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    // potion purchase buttons
    public TMP_Text health_button;
    public TMP_Text score_button;
    public TMP_Text debuff_button;

    //dust purchase buttons
    public TMP_Text stone_button;
    public TMP_Text flower_button;
    public TMP_Text living_button;

    //coins purchase buttons
    public TMP_Text coins100;
    public TMP_Text coins500;
    public TMP_Text coins1000;
    void Start()
    {
        // character tab
        coin_count_display.text = "" + GameManager.manager.coins;
        gem_count_display.text = "" + GameManager.manager.gems;

        AmyLevel.text = "" + GameManager.manager.level[0];
        AjLevel.text = "" + GameManager.manager.level[1];
        ClaireLevel.text = "" + GameManager.manager.level[2];
        GrannyLevel.text = "" + GameManager.manager.level[3];
        MichelleLevel.text = "" + GameManager.manager.level[4];

        Amy.SetBool("Menu", true);
        Aj.SetBool("Menu", true);
        Claire.SetBool("Menu", true);
        Granny.SetBool("Menu", true);
        Michelle.SetBool("Menu", true);

        UpdateCharacterButtons();
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
    public void BuyAmy()
    {
        GameManager.manager.currentCharacter = 0;
        GameManager.manager.Save();
        UpdateCharacterButtons();
    }
    public void BuyClaire()
    {
        if (GameManager.manager.Claire == true)
        {
            GameManager.manager.currentCharacter = 1;
        }
        else
        {
            if (GameManager.manager.coins >= costs.ClaireCost)
            {
                GameManager.manager.coins -= costs.ClaireCost;
                GameManager.manager.Claire = true;
                GameManager.manager.level[1] = 1;
                GameManager.manager.currentCharacter = 1;
            }
        }
        GameManager.manager.Save();
        UpdateCharacterButtons();
    }
    public void BuyAj()
    {
        if (GameManager.manager.Aj == true)
        {
            GameManager.manager.currentCharacter = 2;
        }
        else
        {
            if (GameManager.manager.coins >= costs.AjCost)
            {
                GameManager.manager.coins -= costs.AjCost;
                GameManager.manager.Aj = true;
                GameManager.manager.level[2] = 1;
                GameManager.manager.currentCharacter = 2;
            }
        }
        GameManager.manager.Save();
        UpdateCharacterButtons();
    }
    public void BuyGranny()
    {
        if (GameManager.manager.Granny == true)
        {
            GameManager.manager.currentCharacter = 3;
        }
        else
        {
            if (GameManager.manager.gems >= costs.GrannyCost)
            {
                GameManager.manager.gems -= costs.GrannyCost;
                GameManager.manager.Granny = true;
                GameManager.manager.level[3] = 1;
                GameManager.manager.currentCharacter = 3;
            }
        }
        GameManager.manager.Save();
        UpdateCharacterButtons();
    }
    public void BuyMichelle()
    {
        if (GameManager.manager.Michelle == true)
        {
            GameManager.manager.currentCharacter = 4;
        }
        else
        {
            if (GameManager.manager.gems >= costs.MichelleCost)
            {
                GameManager.manager.gems -= costs.MichelleCost;
                GameManager.manager.Michelle = true;
                GameManager.manager.level[4] = 1;
                GameManager.manager.currentCharacter = 4;
            }
        }
        GameManager.manager.Save();
        UpdateCharacterButtons();
    }

    private void UpdateCharacterButtons()
    {
        UpdateButtonText(AmyButton, GameManager.manager.Amy, 0, 0);
        UpdateButtonText(ClaireButton, GameManager.manager.Claire, costs.ClaireCost, 1);
        UpdateButtonText(AjButton, GameManager.manager.Aj, costs.AjCost, 2);
        UpdateButtonText(GrannyButton, GameManager.manager.Granny, costs.GrannyCost, 3);
        UpdateButtonText(MichelleButton, GameManager.manager.Michelle, costs.MichelleCost, 4);
    }

    private void UpdateButtonText(TMP_Text button, bool isOwned, float cost, int characterIndex, bool isGemCost = false)
    {
        if (GameManager.manager.currentCharacter == characterIndex)
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

