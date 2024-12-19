using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelRewards : MonoBehaviour
{
    public TMP_Text[] levelButtonsText;
    public GameObject[] levelButtons;
    public GameObject[] overlays;

    void Start()
    {
        // Get the rewards array for the current character
        bool[] currentRewards = GetCurrentCharacterRewards();

        // Iterate through levels up to the current character's unlocked level
        for (int i = 0; i < GameManager.manager.level[GameManager.manager.currentCharacter]; i++)
        {
            levelButtons[i].SetActive(true);

            // Check if the reward for the level has already been claimed
            if (currentRewards != null && currentRewards[i])
            {
                levelButtonsText[i].text = "Claimed!";
                overlays[i].SetActive(true);
            }
        }
    }
    public void Level1()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[0])
        {
            // Update the reward
            currentRewards[0] = true;

            //reward
            GameManager.manager.flowerDust += 1;
            GameManager.manager.stoneDust += 1;
            GameManager.manager.livingDust += 1;

            // Update UI
            levelButtonsText[0].text = "Claimed!";
            overlays[0].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level2()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[1])
        {
            // Update the reward
            currentRewards[1] = true;

            //reward
            GameManager.manager.flowerDust += 3;
            GameManager.manager.stoneDust += 3;
            GameManager.manager.livingDust += 3;

            // Update UI
            levelButtonsText[1].text = "Claimed!";
            overlays[1].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level3()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[2])
        {
            // Update the reward
            currentRewards[2] = true;

            //reward
            GameManager.manager.greenPotion += 1;

            // Update UI
            levelButtonsText[2].text = "Claimed!";
            overlays[2].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level4()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[3])
        {
            // Update the reward
            currentRewards[3] = true;

            //reward
            GameManager.manager.gems += 5;
            GameManager.manager.coins += 100;

            // Update UI
            levelButtonsText[3].text = "Claimed!";
            overlays[3].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level5()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[4])
        {
            // Update the reward
            currentRewards[4] = true;

            //rewards
            GameManager.manager.PlayerScoreMultipleir[GameManager.manager.currentCharacter] += 0.25f;

            // Update UI
            levelButtonsText[4].text = "Claimed!";
            overlays[4].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level6()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[5])
        {
            // Update the reward
            currentRewards[5] = true;

            //reward
            GameManager.manager.powerCollectionAmount[GameManager.manager.currentCharacter] -= 25;

            // Update UI
            levelButtonsText[5].text = "Claimed!";
            overlays[5].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level7()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[6])
        {
            // Update the reward
            currentRewards[6] = true;

            //reward
            GameManager.manager.flowerDust += 5;
            GameManager.manager.stoneDust += 5;
            GameManager.manager.livingDust += 5;

            // Update UI
            levelButtonsText[6].text = "Claimed!";
            overlays[6].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level8()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[7])
        {
            // Update the reward
            currentRewards[7] = true;

            //reward
            GameManager.manager.greenPotion += 1;
            GameManager.manager.yellowPotion += 1;
            GameManager.manager.redPotion += 1;

            // Update UI
            levelButtonsText[7].text = "Claimed!";
            overlays[7].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level9()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[8])
        {
            // Update the reward
            currentRewards[8] = true;

            //reward
            GameManager.manager.gems += 10;
            GameManager.manager.coins += 200;

            // Update UI
            levelButtonsText[8].text = "Claimed!";
            overlays[8].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level10()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[9])
        {
            // Update the reward
            currentRewards[9] = true;

            //reward
            GameManager.manager.PlayerScoreMultipleir[GameManager.manager.currentCharacter] += 0.25f;

            // Update UI
            levelButtonsText[9].text = "Claimed!";
            overlays[9].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level11()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[10])
        {
            // Update the reward
            currentRewards[10] = true;

            //reward
            GameManager.manager.trippedTime[GameManager.manager.currentCharacter] -= 1f;
            GameManager.manager.debuffTime[GameManager.manager.currentCharacter] -= 1f;

            // Update UI
            levelButtonsText[10].text = "Claimed!";
            overlays[10].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level12()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[11])
        {
            // Update the reward
            currentRewards[11] = true;

            //reward
            if (GameManager.manager.currentCharacter == 0)
            {
                GameManager.manager.coinPower += 25f;
            }
            else if (GameManager.manager.currentCharacter == 1)
            {
                GameManager.manager.scorePower += 0.5f;
            }
            else if (GameManager.manager.currentCharacter == 2)
            {
                GameManager.manager.bubbleTime[2] += 1.25f;
            }
            else if (GameManager.manager.currentCharacter == 3)
            {
                GameManager.manager.speedTime[3] += 1.25f;
            }
            else if (GameManager.manager.currentCharacter == 4)
            {
                GameManager.manager.gemPower += 2f;
            }

            // Update UI
            levelButtonsText[11].text = "Claimed!";
            overlays[11].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level13()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[12])
        {
            // Update the reward
            currentRewards[12] = true;

            //reward
            GameManager.manager.coinMultiplier[GameManager.manager.currentCharacter] += 0.5f;

            // Update UI
            levelButtonsText[12].text = "Claimed!";
            overlays[12].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level14()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[13])
        {
            // Update the reward
            currentRewards[13] = true;

            //reward
            GameManager.manager.gems += 20;
            GameManager.manager.coins += 500;

            // Update UI
            levelButtonsText[13].text = "Claimed!";
            overlays[13].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level15()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[14])
        {
            // Update the reward
            currentRewards[14] = true;

            //reward
            GameManager.manager.PlayerScoreMultipleir[GameManager.manager.currentCharacter] += 0.5f;

            // Update UI
            levelButtonsText[14].text = "Claimed!";
            overlays[14].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level16()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[15])
        {
            // Update the reward
            currentRewards[15] = true;


            //reward
            GameManager.manager.trippedTime[GameManager.manager.currentCharacter] -= 1f;
            GameManager.manager.debuffTime[GameManager.manager.currentCharacter] -= 1f;

            // Update UI
            levelButtonsText[15].text = "Claimed!";
            overlays[15].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level17()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[16])
        {
            // Update the reward
            currentRewards[16] = true;
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 17);

            //reward
            if (GameManager.manager.currentCharacter == 0)
            {
                GameManager.manager.coinPower += 25f;
            }
            else if (GameManager.manager.currentCharacter == 1)
            {
                GameManager.manager.scorePowerTime += 2.5f;
            }
            else if (GameManager.manager.currentCharacter == 2)
            {
                GameManager.manager.bubbleTime[2] += 1.25f;
            }
            else if (GameManager.manager.currentCharacter == 3)
            {
                GameManager.manager.speedTime[3] += 1.25f;
            }
            else if (GameManager.manager.currentCharacter == 4)
            {
                GameManager.manager.gemPower += 2f;
            }

            // Update UI
            levelButtonsText[16].text = "Claimed!";
            overlays[16].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level18()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[17])
        {
            // Update the reward
            currentRewards[17] = true;

            //reward
            GameManager.manager.greenPotion += 3;
            GameManager.manager.yellowPotion += 3;
            GameManager.manager.redPotion += 3;

            // Update UI
            levelButtonsText[17].text = "Claimed!";
            overlays[17].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level19()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[18])
        {
            // Update the reward
            currentRewards[18] = true;

            //reward
            GameManager.manager.trippedTime[GameManager.manager.currentCharacter] -= 2f;
            GameManager.manager.debuffTime[GameManager.manager.currentCharacter] -= 2f;


            // Update UI
            levelButtonsText[18].text = "Claimed!";
            overlays[18].SetActive(true);

            // Save
            GameManager.manager.Save();
        }
    }
    public void Level20()
    {
        // Get the current character's rewards array directly
        bool[] currentRewards = GetCurrentCharacterRewards();

        if (currentRewards != null && !currentRewards[19])
        {
            // Update the reward
            currentRewards[19] = true;

            //reward
            GameManager.manager.gems += 50;
            GameManager.manager.powerCollectionAmount[GameManager.manager.currentCharacter] -= 50f;

            // Update UI
            levelButtonsText[19].text = "Claimed!";
            overlays[19].SetActive(true);
            // Save
            GameManager.manager.Save();
        }
    }
    private bool[] GetCurrentCharacterRewards()
    {
        switch (GameManager.manager.currentCharacter)
        {
            case 0: return GameManager.manager.AmyRewards;
            case 1: return GameManager.manager.ClaireRewards;
            case 2: return GameManager.manager.AjRewards;
            case 3: return GameManager.manager.GrannyRewards;
            case 4: return GameManager.manager.MichelleRewards;
            default: return null; // Handle invalid character cases
        }
    }
}
