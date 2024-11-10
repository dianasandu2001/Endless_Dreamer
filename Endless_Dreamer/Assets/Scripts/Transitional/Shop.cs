using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    void Start()
    {

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
        }
        else
        {
            //Currency amount here
            //she is default so no need to get 
            GameManager.manager.Amy = true;
        }
    }
    public void BuyClaire()
    {
        if (GameManager.manager.Claire == true)
        {
            GameManager.manager.currentCharacter = 1;
        }
        else
        {
            //Currency amount here
            GameManager.manager.Claire = true;
        }
    }
    public void BuyAj()
    {
        if (GameManager.manager.Aj == true)
        {
            GameManager.manager.currentCharacter = 2;
        }
        else
        {
            //Currency amount here
            GameManager.manager.Aj = true;
        }
    }
    public void BuyGranny()
    {
        if (GameManager.manager.Granny == true)
        {
            GameManager.manager.currentCharacter = 3;
        }
        else
        {
            //Currency amount here
            GameManager.manager.Granny = true;
        }
    }
    public void BuyMichelle()
    {
        if (GameManager.manager.Michelle == true)
        {
            GameManager.manager.currentCharacter = 4;
        }
        else
        {
            //Currency amount here
            GameManager.manager.Michelle = true;
        }
    }
}
