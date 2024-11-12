using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //character tab var
    public GameObject coin_count_display;
    public GameObject gem_count_display;

    public Animator Amy;
    public Animator Aj;
    public Animator Claire;
    public Animator Granny;
    public Animator Michelle;

    //apothecary tab var
    public GameObject coin_display_apothecary;
    public GameObject gem_display_apothecary;

    public GameObject stone_dust_display_apothecary;
    public GameObject flower_dust_display_apothecary;
    public GameObject living_dust_display_apothecary;

    public GameObject health_potion_display_apothecary;
    public GameObject score_potion_display_apothecary;
    public GameObject debuff_potion_display_apothecary;

    //changing tabs
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    void Start()
    {
        // character tab
        coin_count_display.GetComponent<Text>().text = "" + GameManager.manager.coins;
        gem_count_display.GetComponent<Text>().text = "" + GameManager.manager.gems;

        Amy.SetBool("Menu", true);
        Aj.SetBool("Menu", true);
        Claire.SetBool("Menu", true);
        Granny.SetBool("Menu", true);
        Michelle.SetBool("Menu", true);

        // apothecary tab
        coin_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.coins;
        gem_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.gems;

        stone_dust_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.stoneDust;
        flower_dust_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.flowerDust;
        living_dust_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.livingDust;

        health_potion_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.redPotion;
        score_potion_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.yellowPotion;
        debuff_potion_display_apothecary.GetComponent<Text>().text = "" + GameManager.manager.greenPotion;
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

    public void Upgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }
    public void AdventurerTab()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }
    public void ApothecaryTab()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
    }
    public void CurrencyTab()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
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

    public void BuyAmy()
    {
        if(GameManager.manager.Amy == true)
        {
            GameManager.manager.currentCharacter = 0;
            GameManager.manager.Save();
        }
        else
        {
            //Currency amount here
            //she is default so no need to get 
            GameManager.manager.Amy = true;
            GameManager.manager.currentCharacter = 0;
            GameManager.manager.Save();
        }
    }
    public void BuyClaire()
    {
        if (GameManager.manager.Claire == true)
        {
            GameManager.manager.currentCharacter = 1;
            GameManager.manager.Save();
        }
        else
        {
            //Currency amount here
            GameManager.manager.Claire = true;
            GameManager.manager.currentCharacter = 1;
            GameManager.manager.Save();
        }
    }
    public void BuyAj()
    {
        if (GameManager.manager.Aj == true)
        {
            GameManager.manager.currentCharacter = 2;
            GameManager.manager.Save();
        }
        else
        {
            //Currency amount here
            GameManager.manager.Aj = true;
            GameManager.manager.currentCharacter = 2;
            GameManager.manager.Save();
        }
    }
    public void BuyGranny()
    {
        if (GameManager.manager.Granny == true)
        {
            GameManager.manager.currentCharacter = 3;
            GameManager.manager.Save();
        }
        else
        {
            //Currency amount here
            GameManager.manager.Granny = true;
            GameManager.manager.currentCharacter = 3;
            GameManager.manager.Save();
        }
    }
    public void BuyMichelle()
    {
        if (GameManager.manager.Michelle == true)
        {
            GameManager.manager.currentCharacter = 4;
            GameManager.manager.Save();
        }
        else
        {
            //Currency amount here
            GameManager.manager.Michelle = true;
            GameManager.manager.currentCharacter = 4;
            GameManager.manager.Save();
        }
    }
}
