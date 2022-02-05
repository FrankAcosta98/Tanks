using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleo : MonoBehaviour
{
    public float attraction = 25f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.localPosition * -attraction);
    }
}
