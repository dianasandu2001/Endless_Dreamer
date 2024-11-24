using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Obsticle_Collision : MonoBehaviour
{
    //public AudioSource coin_FX;
    public Animator animator;
    public GameObject panel;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("ShieldPower"))
        {
            Debug.Log("Destroyer void");
            Destroy(player.gameObject);
        }
        else if(!player.GetComponent<Player_Move>().isProtectedByBubble)
        {
            //coin_FX.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<Player_Move>().enabled = false;
            animator = player.GetComponent<Animator>();
            animator.SetBool("Stumble", true);
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
