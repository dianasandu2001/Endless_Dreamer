using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GoToMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.json"))
        {
            GameManager.manager.Load();
            Debug.Log("Loading prev data");
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            GameManager.manager.Amy = true;
            SceneManager.LoadScene("Tutorial");
        }    
    }

}

