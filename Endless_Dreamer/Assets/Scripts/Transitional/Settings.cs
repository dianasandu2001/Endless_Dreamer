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

    public GameObject spawn;
    public GameObject player;
    public Animator animator;

    public Collectable_Control control;
    public float healthPotionUsage;
    public TMP_Text healthPotionButton;
    void Start()
    {
        coin_count_display.text = "" + GameManager.manager.coins;
        gem_count_display.text = "" + GameManager.manager.gems;
        distance_count_display.text = "" + (int)GameManager.manager.distance + " m";
        score_count_display.text = "" + (int)GameManager.manager.score;

        //spawning currently selected character
        player = Instantiate(GameManager.manager.characters[GameManager.manager.currentCharacter], spawn.transform);
        player.GetComponent<Player_Move>().enabled = false;
        animator = player.GetComponent<Animator>();
        Player_Move = player.GetComponent<Player_Move>();
        animator.SetBool("Menu", true);
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
        SceneManager.LoadScene("MainMenu"); // or where the character levels up to show levels
        Debug.Log("I ended the run");
        GameManager.manager.coins += Collectable_Control.coin_count;
        GameManager.manager.gems += Collectable_Control.gem_count;
        if (Collectable_Control.distance_count> GameManager.manager.distance)
        {
            GameManager.manager.distance = Collectable_Control.distance_count;
            Debug.Log("New highscore (distance)");
        }
        if (Collectable_Control.score_count > GameManager.manager.score)
        {
            GameManager.manager.score += Collectable_Control.score_count;
            Debug.Log("New highscore (score)");
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
    public void useScorePotion(GameObject startPanel)
    {
        GameManager.manager.yellowPotion -= 1;
        control.potion_score_multiplier = 2;
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void useHealthPotion(GameObject endPanel)
    { 
        GameManager.manager.redPotion -= 1 * healthPotionUsage;
        endPanel.SetActive(false);
        Time.timeScale = 1f;
        player = control.player;
        player.GetComponent<Player_Move>().enabled = true;
        animator = player.GetComponent<Animator>();
        animator.SetBool("Stumble", false);
        healthPotionUsage += 1;
        healthPotionButton.text = "Use " + (int)healthPotionUsage;
    }
}
