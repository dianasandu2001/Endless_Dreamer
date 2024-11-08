using UnityEngine;

public class Change : MonoBehaviour
{
    public GameObject[] characters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(characters[4], new Vector3(0, 2, -25), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
