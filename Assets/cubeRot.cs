
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRot : MonoBehaviour
{
    public Vector3 spd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spd, Space.Self);
        if (Input.GetKeyDown(KeyCode.F5))
            spd.x--;

        if (Input.GetKeyDown(KeyCode.F6))
            spd.x++;
        if (Input.GetKeyDown(KeyCode.F7))
            spd.y--;

        if (Input.GetKeyDown(KeyCode.F8))
            spd.y++;
        if (Input.GetKeyDown(KeyCode.F9))
            spd.z--;

        if (Input.GetKeyDown(KeyCode.F10))
            spd.z++;
    }
}
