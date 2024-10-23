using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
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

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Challenges()
    {
        SceneManager.LoadScene("Challenges");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowOptions(GameObject settingsPanel)
    {
        if (settingsPanel.activeSelf == false)
        {
            settingsPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            settingsPanel.SetActive(false);
            //add 3 sec and countdown
            Time.timeScale = 1f;
        }
    }

    public void ShowSettings(GameObject settingsPanel)
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
}
