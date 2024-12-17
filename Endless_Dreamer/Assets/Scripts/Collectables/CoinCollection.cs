using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public AudioSource coin_FX;
    void OnTriggerEnter(Collider coin)
    {
        coin_FX.Play();
        Collectable_Control.coin_count += 1;
        Collectable_Control.power += 1 * GameManager.manager.coinMultiplier[GameManager.manager.currentCharacter];
        this.gameObject.SetActive(false);
    }
}
