using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject); // Destroys the obstacle GameObject
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(other.gameObject); // Destroys the obstacle GameObject
        }
        else
        {
            //nothing (collectibles would need to be checked individually, they all have a unique tag, it too muhc work for too little)
        }
    }
}

