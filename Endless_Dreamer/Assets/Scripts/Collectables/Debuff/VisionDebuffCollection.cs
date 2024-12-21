using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class VisionDebuffCollection : MonoBehaviour
{
    public GameObject mesh;
    public Collider colliderC;
    //public AudioSource chest_FX;
    public Level_Control level_Control;

    public Image image;
    public Coroutine runningCoroutine;

    public GameObject button;
    void OnTriggerEnter(Collider player)
    {
        if (!player.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Vision Debuff");
            runningCoroutine = StartCoroutine(level_Control.DebuffTime(GameManager.manager.debuffTime[GameManager.manager.currentCharacter]));
            //button.SetActive(true);
            mesh.SetActive(false);
            colliderC.enabled = false;
        }
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
    }
   /*
    public IEnumerator DebuffTime(float sec)
    {
        Debug.Log("Coroutine starting");
        image.gameObject.SetActive(true);

        yield return new WaitForSeconds(sec);

        image.gameObject.SetActive(false);
        Debug.Log("Coroutine ending");
        button.SetActive(false);
    }

    public void DebuffPotion()
    {
        if (runningCoroutine == null)
        {
            //nothing
        }
        else
        {
            if (GameManager.manager.greenPotion > 1)
            {
                StopCoroutine(runningCoroutine);
                image.gameObject.SetActive(false);

                GameManager.manager.greenPotion -= 1;
                button.SetActive(false);
            }
        }
    }
  */
}
