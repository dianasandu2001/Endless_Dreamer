using UnityEngine;

public class ChestCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    void OnTriggerEnter(Collider chest)
    {
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
        Debug.Log("chest");
        this.gameObject.SetActive(false);
    }
}
