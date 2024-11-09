using UnityEngine;

public class VisionDebuffCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    void OnTriggerEnter(Collider visionDebuff)
    {
        //chest_FX.Play();
        //Collectable_Control.chest_count += 1;
        Debug.Log("Vision Debuff");
        this.gameObject.SetActive(false);
    }
}
