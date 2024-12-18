using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PuddleCollection : MonoBehaviour
{
    public GameObject mesh;
    public Collider colliderC;
    //public AudioSource chest_FX;

    public Image image;
    public Coroutine trippingCoroutine;

    public Animator animator;
    public Player_Move player_move;
    public GameObject panel;
    void OnTriggerEnter(Collider player)
    {
        player_move = player.GetComponent<Player_Move>();
        animator = player.GetComponent<Animator>();
        //chest_FX.Play();

        if (player_move.isProtectedByBubble == true)
        {
            //nothing
        }
        else if(player_move.tripped == true)
        {
            player_move.enabled = false;
            animator.SetBool("Stumble", true);

            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            trippingCoroutine = StartCoroutine(TrippedTime(GameManager.manager.trippedTime[GameManager.manager.currentCharacter]));

            mesh.SetActive(false);
            colliderC.enabled = false;
        }
    }

    public IEnumerator TrippedTime(float sec)
    {
        player_move.tripped = true;
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);

        image.gameObject.SetActive(false);
        player_move.tripped = false;
    }

    public void TrippedPotion()
    {
        if (trippingCoroutine == null)
        {
            //nothing
        }
        else
        {
            StopCoroutine(trippingCoroutine);

            image.gameObject.SetActive(false);
            player_move.tripped = false;
        }
    }
}
