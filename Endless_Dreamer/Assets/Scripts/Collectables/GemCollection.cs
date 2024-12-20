using UnityEngine;

public class GemCollection : MonoBehaviour
{
    public AudioSource gem_FX;
    void OnTriggerEnter(Collider gem)
    {
        if (!gem.gameObject.CompareTag("Destroyer"))
        {
            gem_FX.Play();
            Collectable_Control.gem_count += 1;
            Collectable_Control.power += 20;
            this.gameObject.SetActive(false);
        }
    }
}
