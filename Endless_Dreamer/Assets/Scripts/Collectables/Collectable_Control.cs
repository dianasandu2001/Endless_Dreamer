using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Collectable_Control : MonoBehaviour
{
    public static float coin_count;
    public Text coin_count_display;
    public float coins_collected;

    public static float gem_count;
    public Text gem_count_display;

    public GameObject player;
    public Player_Move player_move;

    public static float distance_count;
    public Text distance_count_display;

    public static float score_count;
    public Text score_count_display;

    public float potion_score_multiplier;

    public Image powerBar;
    public static float power;
    public GameObject[] charPower;
    public GameObject powerButton;

    public SpeedPower speedPower;
    public BubblePower bubblePower;

    // Start is called before the first frame update
    void Start()
    {
        coin_count = 0;
        gem_count = 0;
        distance_count = 0;
        score_count = 0;
        potion_score_multiplier = 1;

        charPower[GameManager.manager.currentCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        coins_collected = coin_count * GameManager.manager.coinMultiplier[GameManager.manager.currentCharacter];
        coin_count_display.text = "" + (int)coins_collected;
        gem_count_display.text = "" + gem_count;
        
        distance_count = (player.transform.position.z + 25)/2;
        distance_count_display.text = "" + (int)distance_count + " m";

        score_count = distance_count * potion_score_multiplier * GameManager.manager.PlayerScoreMultipleir[GameManager.manager.currentCharacter];
        score_count_display.text = "" + (int)score_count;

        if (player_move.tripped == true)
        {
            power = 0;
        }    

        if (power >= GameManager.manager.powerCollectionAmount[GameManager.manager.currentCharacter])
        {
            charPower[GameManager.manager.currentCharacter].SetActive(false);
            powerButton.SetActive(true);
        }
        powerBar.fillAmount = power / GameManager.manager.powerCollectionAmount[GameManager.manager.currentCharacter];
    }

    public void Power()
    {
        if(GameManager.manager.currentCharacter == 0) // amy
        {
            coin_count += GameManager.manager.coinPower; //amy gets x amount of coins when the power is used                     //maybe i should change to double coins for x amount of time ?
        }
        else if(GameManager.manager.currentCharacter == 1) //claire
        {
            StartCoroutine(ClairePower(GameManager.manager.scorePowerTime, GameManager.manager.scorePower));
        }
        else if (GameManager.manager.currentCharacter == 2) //aj
        {
            StartCoroutine(bubblePower.BubbleTime(GameManager.manager.bubbleTime[2]));
        }
        else if (GameManager.manager.currentCharacter == 3) //granny
        {
            StartCoroutine(speedPower.SpeedTime(GameManager.manager.speedTime[3])); //speed buff
        }
        else if (GameManager.manager.currentCharacter == 4) //michelle
        {
            gem_count += GameManager.manager.gemPower; //gets x amount of gems
        }
        power = 0;
        powerButton.SetActive(false);
        charPower[GameManager.manager.currentCharacter].SetActive(true);
    }
    public IEnumerator ClairePower(float sec, float magnitude)
    {
        GameManager.manager.PlayerScoreMultipleir[1] += magnitude;
        yield return new WaitForSeconds(sec);
        GameManager.manager.PlayerScoreMultipleir[1] -= magnitude;

    }
}
