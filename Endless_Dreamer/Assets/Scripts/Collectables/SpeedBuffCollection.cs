using UnityEngine;

public class SpeedBuffCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    void OnTriggerEnter(Collider speedBuff)
    {
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
        Debug.Log("Speed Buff");
        this.gameObject.SetActive(false);
    }
}
