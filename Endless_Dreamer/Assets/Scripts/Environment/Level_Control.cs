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

    public float bubbleTime;
    public GameObject bubblePower;
    private GameObject bubblePowerInstanciated;

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
        GameManager.manager.redPotion -= 1 * healthPotionUsage;
        endPanel.SetActive(false);
        Time.timeScale = 1f;
        animator.SetBool("Stumble", false);
        player_move.enabled = true;
        healthPotionUsage += 1;
        healthPotionButton.text = "Use " + (int)healthPotionUsage;
    }
    public IEnumerator BubbleTime(float sec)
    {
        Debug.Log("Coroutine started");
        bubblePowerInstanciated = Instantiate(bubblePower, player.transform);
        yield return new WaitForSeconds(sec);
        Debug.Log("Coroutine ending");
        player_move.isProtectedByBubble = false;
        Destroy(bubblePowerInstanciated);
    }
}
