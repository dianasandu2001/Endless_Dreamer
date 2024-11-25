using UnityEngine;
using System.Collections;
using System;

public class SpeedPower : MonoBehaviour
{
    public GameObject player;

    public Material mat;
    public Color color;

    public Player_Move player_move;
    void Start()
    {
        color = mat.color;
    }
    public IEnumerator SpeedTime(float sec)
    {
        Debug.Log("Coroutine starting");

        mat.SetFloat("_Mode", 2);
        color.a = 0.4f; // it changes to fade and the apha in the inspector but not in the game??
        mat.color = color;

        gameObject.layer = LayerMask.NameToLayer("Ignore Collision");
        player_move.move_speed *= GameManager.manager.speedMultiplier[GameManager.manager.currentCharacter];

        yield return new WaitForSeconds(sec);

        player_move.move_speed /= 2;
        gameObject.layer = LayerMask.NameToLayer("Default");

        mat.SetFloat("_Mode", 0);
        color.a = 1f;
        mat.color = color;

        Debug.Log("Coroutine ending");
    }
}
