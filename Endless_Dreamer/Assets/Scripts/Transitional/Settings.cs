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
            Time.timeScale = 1f;
        }
    }
}
