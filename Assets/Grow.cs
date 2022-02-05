using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float spd = 0.2f;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1.5f, 1.5f, 1.5f), Mathf.PingPong(spd * Time.time, 1));
    }
}
