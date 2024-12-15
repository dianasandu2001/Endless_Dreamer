using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Text coin_count_display;
    public Text gem_count_display;
    public Text distance_count_display;
    public Text score_count_display;

    public AudioMixer mixer;

    public Player_Move Player_Move;
    public GameObject spawn_menu;
    public GameObject player_menu;
    public Animator animator_menu;

    public TMP_Text XP;
    public TMP_Text levels;
    public TMP_Text XPToNext;

    private int levelsGained;
    void Start()
    {
        coin_count_display.text = "" + GameManager.manager.coins;
        gem_count_display.text = "" + GameManager.manager.gems;
        distance_count_display.text = "" + (int)GameManager.manager.distance + " m";
        score_count_display.text = "" + (int)GameManager.manager.score;

        //spawning currently selected character
        player_menu = Instantiate(GameManager.manager.characters[GameManager.manager.currentCharacter], spawn_menu.transform);
        player_menu.GetComponent<Player_Move>().enabled = false;
        animator_menu = player_menu.GetComponent<Animator>();
        Player_Move = player_menu.GetComponent<Player_Move>();
        animator_menu.SetBool("Menu", true);

        levelsGained = 0;
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
        SceneManager.LoadScene(GameManager.manager.mapScenes[GameManager.manager.currentMap]);
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Upgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }

    public void Craft()
    {
        SceneManager.LoadScene("Craft");
    }
    public void Maps()
    {
        SceneManager.LoadScene("Maps");
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
        //SceneManager.LoadScene("MainMenu"); // or where the character levels up to show levels
        Debug.Log("I ended the run");
        GameManager.manager.currentLevelXP[GameManager.manager.currentCharacter] += Collectable_Control.score_count;

        while(GameManager.manager.currentLevelXP[GameManager.manager.currentCharacter] >= GameManager.manager.levelRequirements[GameManager.manager.level[GameManager.manager.currentCharacter]])
        {
            GameManager.manager.currentLevelXP[GameManager.manager.currentCharacter] -= GameManager.manager.levelRequirements[GameManager.manager.level[GameManager.manager.currentCharacter]];
            GameManager.manager.level[GameManager.manager.currentCharacter]++;
            levelsGained++;
        }
        XP.text = (int)Collectable_Control.score_count + " XP earned!";
        if(levelsGained >= 1) { levels.text = levelsGained + " levels gained!"; }
        else { levels.text = ""; }
        XPToNext.text = (int)(GameManager.manager.levelRequirements[GameManager.manager.level[GameManager.manager.currentCharacter]] - GameManager.manager.currentLevelXP[GameManager.manager.currentCharacter]) + " XP until next level";

        GameManager.manager.coins += Collectable_Control.coin_count;
        GameManager.manager.gems += Collectable_Control.gem_count;
        if (Collectable_Control.distance_count> GameManager.manager.distance)
        {
            GameManager.manager.distance = Collectable_Control.distance_count;
            Debug.Log("New highscore (distance)");
        }
        if (Collectable_Control.score_count > GameManager.manager.score)
        {
            GameManager.manager.score = Collectable_Control.score_count;
            Debug.Log("New highscore (score)");
        }
        GameManager.manager.Save();
    }

    public void Volume(float volumeLevel)
    {
        //volumeLevel = GameManager.manager.volume;
        mixer.SetFloat("BackgroundMusic", Mathf.Log10(volumeLevel) * 20);
        GameManager.manager.volume = volumeLevel;
        GameManager.manager.Save();
    }
    public void SoundEffects(float soundEffectsLevel)
    {
        mixer.SetFloat("SoundEffects", Mathf.Log10(soundEffectsLevel) * 20);
        GameManager.manager.soundEffects = soundEffectsLevel;
        GameManager.manager.Save();
    }

    public void HELP()
    {
        Player_Move.grounded = true;
    }
}
