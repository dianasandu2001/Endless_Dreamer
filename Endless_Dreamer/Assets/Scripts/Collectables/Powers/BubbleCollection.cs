using System.Collections;
using UnityEngine;

public class BubbleCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    public MeshRenderer mesh;
    public Collider colliderC;

    public Level_Control level_control;
    public BubblePower bubblePower;
    void OnTriggerEnter(Collider player)
    {
        //chest_FX.Play;
        bubblePower = player.GetComponent<BubblePower>();
        StartCoroutine(bubblePower.BubbleTime(GameManager.manager.bubbleTime[GameManager.manager.currentCharacter]));
        mesh.enabled = false;
        colliderC.enabled = false;
    }
}
