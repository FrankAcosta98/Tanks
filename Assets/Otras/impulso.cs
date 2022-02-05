using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulso : MonoBehaviour
{
    public ConstantForce force;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        vector.Set(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        
        force.force =vector*2f ;
    }
}
