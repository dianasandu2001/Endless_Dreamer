using UnityEngine;

public class SpeedBuffCollection : MonoBehaviour
{
    //public AudioSource chest_FX;
    public GameObject mesh;
    public Collider colliderC;

    public Level_Control level_control;
    public SpeedPower speedPower;
    void OnTriggerEnter(Collider player)
    {
        if (!player.gameObject.CompareTag("Destroyer"))
        {
            //chest_FX.Play();
            Debug.Log("Speed Buff");
            speedPower = player.GetComponent<SpeedPower>();
            StartCoroutine(speedPower.SpeedTime(GameManager.manager.speedTime[GameManager.manager.currentCharacter]));
            mesh.SetActive(false);
            colliderC.enabled = false;
        }
    }
}
