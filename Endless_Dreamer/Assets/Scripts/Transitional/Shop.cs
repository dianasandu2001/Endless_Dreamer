using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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

    //public void Buy(float currency, float item)
    //{
    //    GameManager.manager.currency -= currency;
    //    GameManager.manager.item += item;
    //}
}
