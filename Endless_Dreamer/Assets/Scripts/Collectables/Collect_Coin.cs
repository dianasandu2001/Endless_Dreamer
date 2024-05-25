using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Coin : MonoBehaviour
{
    public AudioSource coin_FX;

    void OnTriggerEnter(Collider other)
    {
        coin_FX.Play();
        this.gameObject.SetActive(false);
    }
}
