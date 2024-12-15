using TMPro;
using UnityEngine;

public class LevelRewards : MonoBehaviour
{
    public TMP_Text[] levelButtonsText;
    public GameObject[] levelButtons;

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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 1);

            // Update UI
            levelButtonsText[0].text = "Claimed!";

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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 2);

            // Update UI
            levelButtonsText[1].text = "Claimed!";

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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 3);

            // Update UI
            levelButtonsText[2].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 4);

            // Update UI
            levelButtonsText[3].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 5);

            // Update UI
            levelButtonsText[4].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 6);

            // Update UI
            levelButtonsText[5].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 7);

            // Update UI
            levelButtonsText[6].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 8);

            // Update UI
            levelButtonsText[7].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 9);

            // Update UI
            levelButtonsText[8].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 10);

            // Update UI
            levelButtonsText[9].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 11);

            // Update UI
            levelButtonsText[10].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 12);

            // Update UI
            levelButtonsText[11].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 13);

            // Update UI
            levelButtonsText[12].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 14);

            // Update UI
            levelButtonsText[13].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 15);

            // Update UI
            levelButtonsText[14].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 16);

            // Update UI
            levelButtonsText[15].text = "Claimed!";
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

            // Update UI
            levelButtonsText[16].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 18);

            // Update UI
            levelButtonsText[17].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 19);

            // Update UI
            levelButtonsText[18].text = "Claimed!";
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
            Debug.Log("Rewards of " + GameManager.manager.currentCharacter + " earned for level " + 20);

            // Update UI
            levelButtonsText[19].text = "Claimed!";
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
