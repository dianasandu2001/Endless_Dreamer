using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Tripping : MonoBehaviour
{
    public GameObject mesh;
    public Collider colliderC;
    //public AudioSource chest_FX;

    public float trippedTime;
    public Image image;
    private Coroutine obstacleTrippingCoroutine;

    public GameObject player;
    public Animator animator;
    public Player_Move player_move;
    public Collectable_Control control;

    void start()
    {
        player = control.player;
        animator = player.GetComponent<Animator>();
        player_move = player.GetComponent<Player_Move>();
    }
    void OnTriggerEnter(Collider player)
    {
        //chest_FX.Play();
        Debug.Log("Tripped");
        obstacleTrippingCoroutine = StartCoroutine(ObstacleTrippedTime(trippedTime)); // GameManager.manager.trippedTime[GameManager.manager.currentCharacter]));
        colliderC.isTrigger = false;
    }

    public IEnumerator ObstacleTrippedTime(float sec)
    {
        Debug.Log("tripped");
        image.gameObject.SetActive(true);

        yield return new WaitForSeconds(sec);

        image.gameObject.SetActive(false);
        Debug.Log("tripped ending");
    }

    public void TrippedPotion()
    {
        StopCoroutine(obstacleTrippingCoroutine);
        image.gameObject.SetActive(false);
    }
}
