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

    //audio
    public float volume;
    public float soundEffects;

    //map
    public AudioClip ForentSong;

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

    //map bool
    public bool forest;
    public bool desert;
    public bool clouds;
    public bool dungeon;

    //changing maps
    public GameObject[] mapModels;
    public string[] mapScenes;
    public int currentMap;

    //character upgrades
        //universal upgrades
    public int[] upgradeCosts;
    public int speedPowerUpgrade;
    public int shieldPowerUpgrade;
    public int visionDebuffUpgrade;
    public int trippingUpgrade;
    public int coinMultiplierUpgrade;
        //buffs
    public float[] bubbleTime; //default is 5s
    public float[] speedTime; //default is 5s
    public float[] speedMultiplier; //default is 2
    public float[] coinMultiplier; //default is 1
    public float[] PlayerScoreMultipleir; //default is 1
        //debuffs
    public float[] trippedTime; //default is 10s
    public float[] debuffTime; //default is 15s
        //levels
    public int[] level; //defualt is 0 (before purchase)
    public float[] currentLevelXP; //how much XP is earned at the current level for each character
    public float[] levelRequirements; //amount of XP needed to get to the next level
        //level rewards
    public bool[] AmyRewards = new bool[20];
    public bool[] ClaireRewards = new bool[20];
    public bool[] AjRewards = new bool[20];
    public bool[] GrannyRewards = new bool[20];
    public bool[] MichelleRewards = new bool[20];
    //power
    public float[] powerCollectionAmount = new float[5];
    public float coinPower; //def is 50
    public float gemPower; //def is 2
    public float scorePower; //def is x2
    public float scorePowerTime; //def is 5s
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

        //map bool
        data.forest = forest;
        data.desert = desert;
        data.clouds = clouds;
        data.dungeon = dungeon;

        //changing maps
        data.currentMap = currentMap;

        //character upgrades
            //universal upgrades
        data.speedPowerUpgrade = speedPowerUpgrade;
        data.shieldPowerUpgrade = shieldPowerUpgrade;
        data.visionDebuffUpgrade = visionDebuffUpgrade;
        data.trippingUpgrade = trippingUpgrade;
        data.coinMultiplierUpgrade = coinMultiplierUpgrade;
            //buffs
        data.bubbleTime = bubbleTime;
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
            //level rewards
        data.AmyRewards = AmyRewards;
        data.ClaireRewards = ClaireRewards;
        data.AjRewards = AjRewards;
        data.GrannyRewards = GrannyRewards;
        data.MichelleRewards = MichelleRewards;
            //power
        data.powerCollectionAmount = powerCollectionAmount;
        data.coinPower = coinPower;
        data.gemPower = gemPower;
        data.scorePower = scorePower;
        data.scorePowerTime = scorePowerTime;

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
            volume = data.volume;
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

            //map bool
            forest = data.forest;
            desert = data.desert;
            clouds = data.clouds;
            dungeon = data.dungeon;

            //changing maps
            currentMap = data.currentMap;

            //character upgrades
                //universal upgrades
            speedPowerUpgrade = data.speedPowerUpgrade;
            shieldPowerUpgrade = data.shieldPowerUpgrade;
            visionDebuffUpgrade = data.visionDebuffUpgrade;
            trippingUpgrade = data.trippingUpgrade;
            coinMultiplierUpgrade = data.coinMultiplierUpgrade;
                //buffs
            bubbleTime = data.bubbleTime;
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
                //level rewards
            AmyRewards = data.AmyRewards;
            ClaireRewards = data.ClaireRewards;
            AjRewards = data.AjRewards;
            GrannyRewards = data.GrannyRewards;
            MichelleRewards = data.MichelleRewards;
                //power
            powerCollectionAmount = data.powerCollectionAmount;
            coinPower = data.coinPower;
            gemPower = data.gemPower;
            scorePower = data.scorePower;
            scorePowerTime = data.scorePowerTime;
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

    //map bool
    public bool forest;
    public bool desert;
    public bool clouds;
    public bool dungeon;

    //changing maps
    public int currentMap;

    //character upgrades
        //universal upgrades
    public int speedPowerUpgrade;
    public int shieldPowerUpgrade;
    public int visionDebuffUpgrade;
    public int trippingUpgrade;
    public int coinMultiplierUpgrade;
        //buffs
    public float[] bubbleTime; //default is 5s
    public float[] speedTime; //default is 5s
    public float[] speedMultiplier; //default is 2
    public float[] coinMultiplier; //default is 1
    public float[] PlayerScoreMultipleir; //default is 1
        //debuffs
    public float[] trippedTime; //default is 10s
    public float[] debuffTime; //default is 15s
        //levels
    public int[] level; //defualt is 0 (before purchase)
    public float[] currentLevelXP; //how much XP is earned at the current level for each character
        //level rewards
    public bool[] AmyRewards;
    public bool[] ClaireRewards;
    public bool[] AjRewards;
    public bool[] GrannyRewards;
    public bool[] MichelleRewards;
        //power
    public float[] powerCollectionAmount;
    public float coinPower;
    public float gemPower;
    public float scorePower;
    public float scorePowerTime;
}