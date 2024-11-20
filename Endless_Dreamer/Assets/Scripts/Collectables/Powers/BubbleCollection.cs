using System.Collections;
using UnityEngine;

public class BubbleCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    public MeshRenderer mesh;
    public Collider collider;

    public Level_Control level_control;
    void OnTriggerEnter(Collider bubble)
    {
        //chest_FX.Play;
        level_control.player_move.isProtectedByBubble = true;
        StartCoroutine(level_control.BubbleTime(level_control.bubbleTime));
        mesh.enabled = false;
        collider.enabled = false;
    }
}
