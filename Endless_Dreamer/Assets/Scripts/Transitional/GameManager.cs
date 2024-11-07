using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
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

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

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

}