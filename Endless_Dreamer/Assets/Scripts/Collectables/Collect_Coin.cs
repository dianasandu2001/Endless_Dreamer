using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Coin : MonoBehaviour
{
    public AudioSource coin_FX;

    void OnTriggerEnter(Collider other)
    {
        coin_FX.Play();
        Collectable_Control.coin_count += 1; 
        this.gameObject.SetActive(false);
    }
}
