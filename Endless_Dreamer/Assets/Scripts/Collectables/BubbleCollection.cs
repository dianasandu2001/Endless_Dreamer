using UnityEngine;

public class BubbleCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    void OnTriggerEnter(Collider bubble)
    {
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
        Debug.Log("bubble");
        this.gameObject.SetActive(false);
    }
}
