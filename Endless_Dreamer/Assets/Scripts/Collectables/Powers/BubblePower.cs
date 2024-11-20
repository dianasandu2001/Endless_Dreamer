using UnityEngine;
using System.Collections;

public class BubblePower : MonoBehaviour
{
    public float bubbleTime;
    public GameObject bubblePower;
    private GameObject bubblePowerInstanciated;

    public Player_Move player_move;
    public GameObject player;
    public IEnumerator BubbleTime(float sec)
    {
        Debug.Log("Coroutine started");
        player_move.isProtectedByBubble = true;
        bubblePowerInstanciated = Instantiate(bubblePower, player.transform);
        yield return new WaitForSeconds(sec);
        Debug.Log("Coroutine ending");
        player_move.isProtectedByBubble = false;
        Destroy(bubblePowerInstanciated);
    }
}
