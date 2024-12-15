using UnityEngine;

public class LevelRewards : MonoBehaviour
{
    public void Level1()
    {
        Debug.Log("character selected: " + GameManager.manager.currentCharacter);
        if (!GameManager.manager.levelRewards[GameManager.manager.currentCharacter][1])
        {
            //reward
            Debug.Log("rewards of " + GameManager.manager.currentCharacter + " earned for level" + GameManager.manager.level[GameManager.manager.currentCharacter]);
            //change text to claimed
        }
    }
}
