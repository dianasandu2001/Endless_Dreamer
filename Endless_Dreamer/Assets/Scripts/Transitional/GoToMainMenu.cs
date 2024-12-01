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
            GameManager.manager.forest = true;
            GameManager.manager.currentMap = 0; //just in case
            GameManager.manager.Amy = true;
            GameManager.manager.currentCharacter = 0; //just in case
            SceneManager.LoadScene("Tutorial");
        }    
    }

}

