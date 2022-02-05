using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    public float End = 4;
    private float dir = 0.05f;
    private bool X, Z = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= End && transform.position.z <= 0)
        {
            transform.Translate(dir, 0, 0);
            X = true;
        }
        else if (transform.position.z <= End && transform.position.x >= End)
        {
            transform.Translate(0, 0, dir);
            Z = true;
        }
        else if (X && Z)
            transform.Translate(-dir, 0, -dir);
        if (transform.position.x <= 0 && transform.position.z <= 0)
        {
            X = false;
            Z = false;
        }

    }

}
