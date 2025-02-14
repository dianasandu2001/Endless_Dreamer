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

    public Image trippingImage;
    public Coroutine trippingCoroutine;
    public PuddleCollection trippingScript;

    public Image image;
    public Coroutine visionCoroutine;
    public VisionDebuffCollection visionDebuffScript;

    public GameObject button;

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

    public void useDebuffPotion()
    {
        if (trippingCoroutine == null)
        {
            Debug.Log("tripping is null");
            //nothing
        }
        else
        {
            if (GameManager.manager.greenPotion > 1)
            {
                StopCoroutine("TrippedTime");
                trippingCoroutine = null;

                trippingImage.gameObject.SetActive(false);
                player_move.tripped = false;

                GameManager.manager.greenPotion -= 1;
                //button.SetActive(false);
            }
        }
        if (visionCoroutine == null)
        {
            Debug.Log("debuff is null");
            //nothing
        }
        else
        {
            if (GameManager.manager.greenPotion > 1)
            {
                StopCoroutine("DebuffTime");
                visionCoroutine = null;

                image.gameObject.SetActive(false);

                GameManager.manager.greenPotion -= 1;
                //button.SetActive(false);
            }
        }
    }

    public IEnumerator DebuffTime(float sec)
    {
        Debug.Log("Coroutine starting");
        image.gameObject.SetActive(true);

        yield return new WaitForSeconds(sec);

        image.gameObject.SetActive(false);
        Debug.Log("Coroutine ending");
        //button.SetActive(false);
        visionCoroutine = null;
    }

    public IEnumerator TrippedTime(float sec)
    {
        player_move.tripped = true;
        trippingImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);

        trippingImage.gameObject.SetActive(false);
        player_move.tripped = false;
        //button.SetActive(false);
        trippingCoroutine = null;
    }
}
