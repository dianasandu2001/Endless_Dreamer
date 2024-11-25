using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class VisionDebuffCollection : MonoBehaviour
{
    public GameObject mesh;
    public Collider colliderC;
    //public AudioSource chest_FX;

    public Image image;
    public Coroutine runningCoroutine;

    void OnTriggerEnter(Collider player)
    {
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
        Debug.Log("Vision Debuff");
        runningCoroutine = StartCoroutine(DebuffTime(GameManager.manager.debuffTime[GameManager.manager.currentCharacter]));
        mesh.SetActive(false);
        colliderC.enabled = false;
    }

    public IEnumerator DebuffTime(float sec)
    {
        Debug.Log("Coroutine starting");
        image.gameObject.SetActive(true);

        yield return new WaitForSeconds(sec);

        image.gameObject.SetActive(false);
        Debug.Log("Coroutine ending");
    }

    public void DebuffPotion()
    {
        if (runningCoroutine == null)
        {
            //nothing
        }
        else
        {
            StopCoroutine(runningCoroutine);
            image.gameObject.SetActive(false);
        }
    }
}
