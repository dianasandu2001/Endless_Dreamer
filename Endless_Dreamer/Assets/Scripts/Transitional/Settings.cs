using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject coin_count_display;
    public GameObject gem_count_display;
    public GameObject distance_count_display;

    public AudioMixer mixer;

    public Player_Move Player_Move;
    void Start()
    {
        coin_count_display.GetComponent<Text>().text = "" + GameManager.manager.coins;
        gem_count_display.GetComponent<Text>().text = "" + GameManager.manager.gems;
        distance_count_display.GetComponent<Text>().text = "" + (int)GameManager.manager.distance + " m";
    }

    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Forest");
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Upgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }

    public void Challenges()
    {
        SceneManager.LoadScene("Challenges");
    }

    public void Exit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
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
    public void EndRun()
    {
        SceneManager.LoadScene("MainMenu"); // or where the character levels up to show levels
        Debug.Log("I ended the run");
        GameManager.manager.coins += Collectable_Control.coin_count;
        GameManager.manager.gems += Collectable_Control.gem_count;
        if (Collectable_Control.distance_count> GameManager.manager.distance)
        {
            GameManager.manager.distance = Collectable_Control.distance_count;
            Debug.Log("New highscore");
        }
        GameManager.manager.Save();
    }

    public void Volume(float volumeLevel)
    {
        mixer.SetFloat("BackgroundMusic", Mathf.Log10(volumeLevel) * 20);
        GameManager.manager.volume = volumeLevel;
    }
    public void SoundEffects(float sounfEffectsLevel)
    {
        mixer.SetFloat("SoundEffects", Mathf.Log10(sounfEffectsLevel) * 20);
        GameManager.manager.soundEffects = sounfEffectsLevel;
    }

    public void HELP()
    {
        Player_Move.grounded = true;
    }
}
