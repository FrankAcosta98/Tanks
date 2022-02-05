using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject bola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Spawn();
    }
    void Spawn(){
        GameObject Sphere = Instantiate(bola, transform.position, Quaternion.identity) as GameObject;
    }
}
