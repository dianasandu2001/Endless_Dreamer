using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Obsticle_Collision : MonoBehaviour
{
    //public AudioSource coin_FX;
    public GameObject the_player;
    public GameObject stumble_animation;
    public GameObject panel;

    void OnTriggerEnter(Collider other)
    {
        //coin_FX.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        the_player.GetComponent<Player_Move>().enabled = false;
        stumble_animation.GetComponent<Animator>().Play("Stumble Backwards");
        panel.SetActive(true);
    }
}
