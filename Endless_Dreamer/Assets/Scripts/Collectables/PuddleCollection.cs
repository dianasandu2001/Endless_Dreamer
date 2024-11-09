using UnityEngine;

public class PuddleCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    void OnTriggerEnter(Collider puddle)
    {
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
        Debug.Log("Puddle");
        this.gameObject.SetActive(false);
    }
}
