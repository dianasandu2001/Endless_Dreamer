using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parent_name;
    public float sec_s;
    public float obj_s;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parent_name = transform.name;
        StartCoroutine(Destroy_Section_Clone());
    }

    IEnumerator Destroy_Section_Clone()
    {
        yield return new WaitForSeconds(sec_s);
        if (parent_name == "Forest_Section(Clone)")
        {
            Destroy(gameObject);
        }
    }

    //IEnumerator Destroy_Object_Clone()
    //{
    //  yield return new WaitForSeconds(obj_s);
    //  if (parentName == "Forest_Section(Clone)")
    //  {
    //      Destroy(gameObject);
    //  }
    //}
}
