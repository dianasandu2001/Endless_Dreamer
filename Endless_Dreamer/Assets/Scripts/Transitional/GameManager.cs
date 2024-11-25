using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Rendering.PostProcessing;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public string currentLevel;

    //audio
    public float volume;
    public float soundEffects;

    //map
    public AudioClip ForentSong;
    public string currentMap; 

    //currency
    public float coins;  // coins collected
    public float gems;  // gems collected

    //scope
    public float distance;  // longerst distance ran in one session
    public float score; // highest score in one session
    // make score and distance for each char??

    //potions
    public float yellowPotion; // amount of score potions
    public float redPotion; // amount of health potions
    public float greenPotion; // amoutn of debuff removal potions

    //ingredients (general)
    public float stoneDust; //amount of stone ingredients
    public float flowerDust; // amount of general flower igredients
    public float livingDust; // amount of general living ingredients

    //ingredients (forest)
    public float glowStones; // amount of stone ingredients
    public float orchids; //amount of flower ingredients
    public float fireflies; // amount of living ingredients

    //characters bool
    public bool Amy;
    public bool Claire;
    public bool Aj;
    public bool Granny;
    public bool Michelle;

    //changing characters
    public GameObject[] characters;
    public int currentCharacter;
    /*
    public List<float> bubbleTime = new List<float> { 5f, 5f, 5f, 5f, 5f };
    public List<float> speedTime = new List<float> { 5f, 5f, 5f, 5f, 5f };
    public List<float> speedMultiplier = new List<float> { 2f, 2f, 2f, 2f, 2f };
    public List<float> coinMultiplier = new List<float> { 1f, 1f, 1f, 1f, 1f };
    public List<float> PlayerScoreMultipleir = new List<float> { 1f, 1f, 1f, 1f, 1f };
    public List<float> trippedTime = new List<float> { 10f, 10f, 10f, 10f, 10f };
    public List<float> level = new List<float> { 1f, 0f, 0f, 0f, 0f };
    public List<float> currentLevelXP = new List<float> { 0f, 0f, 0f, 0f, 0f };
    */
    //character upgrades
        //buffs
    public float[] bubbleTime = new float[5]; //default is 5s
    public float[] speedTime; //default is 5s
    public float[] speedMultiplier; //default is 2
    public float[] coinMultiplier; //default is 1
    public float[] PlayerScoreMultipleir; //default is 1
        //debuffs
    public float[] trippedTime; //default is 10s
    public float[] debuffTime; //default is 15s
    //levels
    public float[] level; //defualt is 0 (before purchase)
    public float[] currentLevelXP; //how much XP is earned at the current level for each character
    
    public float[] levelRequirements; //amount of XP needed to get to the next level
    
    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            Load();
            SceneManager.LoadScene("MainMenu");
        }


    }

    public void Save()
    {
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

        //copy info from GM to PlayerData

        //audio
        data.volume = volume;
        data.soundEffects = soundEffects;

        //currency
        data.coins = coins;
        data.gems = gems;

        //scope 
        data.distance = distance;
        data.score = score;

        //potions
        data.yellowPotion = yellowPotion;
        data.redPotion = redPotion;
        data.greenPotion = greenPotion;

        //ingredients (general)
        data.stoneDust = stoneDust;
        data.flowerDust = flowerDust;
        data.livingDust = livingDust;

        //ingredients (forest)
        data.glowStones = glowStones;
        data.orchids = orchids;
        data.fireflies = fireflies;

        //character bool
        data.Amy = Amy;
        data.Claire = Claire;
        data.Aj = Aj;
        data.Granny = Granny;
        data.Michelle = Michelle;

        //changing characters
        data.currentCharacter = currentCharacter;

        
        //character upgrades
        //buffs
        data.bubbleTime = bubbleTime;
        //data.bubbleTime[0] = bubbleTime[0];
        //data.bubbleTime[1] = bubbleTime[1];
        //data.bubbleTime[2] = bubbleTime[2];
        //data.bubbleTime[3] = bubbleTime[3];
        //data.bubbleTime[4] = bubbleTime[4];
        data.speedTime = speedTime;
        data.speedMultiplier = speedMultiplier;
        data.coinMultiplier = coinMultiplier;
        data.PlayerScoreMultipleir = PlayerScoreMultipleir;
            //debuffs
        data.trippedTime = trippedTime;
        data.debuffTime = debuffTime;
            //levels
        data.level = level;
        data.currentLevelXP = currentLevelXP;
        

        /*
        data.bubbleTime = new List<float>(bubbleTime);
        data.speedTime = new List<float>(speedTime);
        data.speedMultiplier = new List<float>(speedMultiplier);
        data.coinMultiplier = new List<float>(coinMultiplier);
        data.PlayerScoreMultipleir = new List<float>(PlayerScoreMultipleir);
        data.trippedTime = new List<float>(trippedTime);
        data.level = new List<float>(level);
        data.currentLevelXP = new List<float>(currentLevelXP);
        */

        string jason = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerInfo.json", jason);

        //bf.Serialize(file, data);
        //file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.json"))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            //PlayerData data = (PlayerData)bf.Deserialize(file);
            //file.Close();

            string json = File.ReadAllText(Application.persistentDataPath + "/playerInfo.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            // move the info to GM

            //audio
            volume = data.volume = volume;
            soundEffects = data.soundEffects;

            //currency
            coins = data.coins;
            gems = data.gems;

            //scope 
            distance = data.distance;
            score = data.score;

            //potions
            yellowPotion = data.yellowPotion;
            redPotion = data.redPotion;
            greenPotion = data.greenPotion;

            //ingredients (general)
            stoneDust = data.stoneDust;
            flowerDust = data.flowerDust;
            livingDust = data.livingDust;

            //ingredients (forest)
            glowStones = data.glowStones;
            orchids = data.orchids;
            fireflies = data.fireflies;

            //character bool
            Amy = data.Amy;
            Claire = data.Claire;
            Aj = data.Aj;
            Granny = data.Granny;
            Michelle = data.Michelle;

            //changing characters
            currentCharacter = data.currentCharacter;

            
            //character upgrades
            //buffs
            bubbleTime = data.bubbleTime;
            //bubbleTime[0] = data.bubbleTime[0];
            //bubbleTime[1] = data.bubbleTime[1];
            //bubbleTime[2] = data.bubbleTime[2];
            //bubbleTime[3] = data.bubbleTime[3];
            //bubbleTime[4] = data.bubbleTime[4];
            speedTime = data.speedTime;
            speedMultiplier = data.speedMultiplier;
            coinMultiplier = data.coinMultiplier;
            PlayerScoreMultipleir = data.PlayerScoreMultipleir;
                //debuffs
            trippedTime = data.trippedTime;
            debuffTime = data.debuffTime;
                //levels
            level = data.level;
            currentLevelXP = data.currentLevelXP;
            
            /*
            bubbleTime = new List<float>(data.bubbleTime);
            speedTime = new List<float>(data.speedTime);
            speedMultiplier = new List<float>(data.speedMultiplier);
            coinMultiplier = new List<float>(data.coinMultiplier);
            PlayerScoreMultipleir = new List<float>(data.PlayerScoreMultipleir);
            trippedTime = new List<float>(data.trippedTime);
            level = new List<float>(data.level);
            currentLevelXP = new List<float>(data.currentLevelXP);
            */
        }
    }
}

// Another class that we can serialize. This contains only the information we are going to store.
[Serializable]
class PlayerData
{
    public string currentLevel;

    //audio
    public float volume;
    public float soundEffects;

    //currency
    public float coins;  // coins collected
    public float gems;  // gems collected

    //scope
    public float distance;  // longerst distance ran in one session
    public float score; // highest score in one session
    // make score and distance for each char??

    //potions
    public float yellowPotion; // amount of score potions
    public float redPotion; // amount of health potions
    public float greenPotion; // amoutn of debuff removal potions

    //ingredients (general)
    public float stoneDust; //amount of stone ingredients
    public float flowerDust; // amount of general flower igredients
    public float livingDust; // amount of general living ingredients

    //ingredients (forest)
    public float glowStones; // amount of stone ingredients
    public float orchids; //amount of flower ingredients
    public float fireflies; // amount of living ingredients

    //characters bool
    public bool Amy;
    public bool Claire;
    public bool Aj;
    public bool Granny;
    public bool Michelle;

    //changing characters
    public int currentCharacter;

    /*
    public List<float> bubbleTime;
    public List<float> speedTime;
    public List<float> speedMultiplier;
    public List<float> coinMultiplier;
    public List<float> PlayerScoreMultipleir;
    public List<float> trippedTime;
    public List<float> level;
    public List<float> currentLevelXP;
    */
    
    //character upgrades
        //buffs
    public float[] bubbleTime = new float[5]; //default is 5s
    public float[] speedTime; //default is 5s
    public float[] speedMultiplier; //default is 2
    public float[] coinMultiplier; //default is 1
    public float[] PlayerScoreMultipleir; //default is 1
        //debuffs
    public float[] trippedTime; //default is 10s
    public float[] debuffTime; //default is 15s
        //levels
    public float[] level; //defualt is 0 (before purchase)
    public float[] currentLevelXP; //how much XP is earned at the current level for each character
    
}