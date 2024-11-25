using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PuddleCollection : MonoBehaviour
{
    public GameObject mesh;
    public Collider colliderC;
    //public AudioSource chest_FX;

    public float trippedTime;
    public Image image;
    public Coroutine trippingCoroutine;

    public Animator animator;
    public Player_Move player_move;
    public GameObject panel;
    void OnTriggerEnter(Collider player)
    {
        //animator = player.GetComponent<Animator>();
        player_move = player.GetComponent<Player_Move>();
        animator = player.GetComponent<Animator>();
        //chest_FX.Play();
        if (player_move.tripped == true)
        {
            player_move.enabled = false;
            animator.SetBool("Stumble", true);
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("Tripped");
            trippingCoroutine = StartCoroutine(TrippedTime(trippedTime)); // GameManager.manager.trippedTime[GameManager.manager.currentCharacter]));
            mesh.SetActive(false);
            colliderC.enabled = false;
        }
    }

    public IEnumerator TrippedTime(float sec)
    {
        //player_move.isProtectedByBubble = true;
        Debug.Log("tripped");
        player_move.tripped = true;
        image.gameObject.SetActive(true);
        Debug.Log("before waiting");
        yield return new WaitForSeconds(sec);
        Debug.Log("waited");
        image.gameObject.SetActive(false);
        Debug.Log("tripped ending");
        player_move.tripped = false;
    }

    public void TrippedPotion()
    {
        if (trippingCoroutine == null)
        {
            //nothing
            Debug.Log("???");
        }
        else
        {
            StopCoroutine(trippingCoroutine);
            image.gameObject.SetActive(false);
        }
    }
}
