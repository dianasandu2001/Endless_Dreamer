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
        //chest_FX.Play();
        Debug.Log("Speed Buff");
        speedPower = player.GetComponent<SpeedPower>();
        StartCoroutine(speedPower.SpeedTime(speedPower.speedTime));
        mesh.SetActive(false);
        colliderC.enabled = false;
    }
}
