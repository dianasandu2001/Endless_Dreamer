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
            GameManager.manager.Amy = true; // Amy is "purchased
            GameManager.manager.level[0] = 1; // Amy is level 1
            GameManager.manager.currentCharacter = 0; //The current character is Amy
            SceneManager.LoadScene("Tutorial");
        }    
    }

}

