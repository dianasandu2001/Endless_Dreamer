using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Level_Control : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Player_Move player_move;

    public Collectable_Control control;
    public float healthPotionUsage;
    public TMP_Text healthPotionButton;

    void Start()
    {
        player = control.player;
        animator = player.GetComponent<Animator>();
        player_move = player.GetComponent<Player_Move>();
    }
    
    void Update()
    {
        
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
        if (GameManager.manager.redPotion >= 1)
        {
            Time.timeScale = 1f;
            GameManager.manager.redPotion -= 1 * healthPotionUsage;
            endPanel.SetActive(false);
            Time.timeScale = 1f;
            animator.SetBool("Stumble", false);
            player_move.enabled = true;
            healthPotionUsage += 1;
            healthPotionButton.text = "Use " + (int)healthPotionUsage;
        }
    }
}
