using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmyPower : MonoBehaviour
{
    public GameObject player;
    public float power;
    public Image powerBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        power = (player.transform.position.z + 25) / 2;
        powerBar.fillAmount = power / GameManager.manager.powerCollectionAmount[0];
    }
}
