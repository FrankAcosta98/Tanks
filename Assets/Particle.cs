using System;
using System.Data;
using UnityEngine;
using System.Collections;
public class Particle : MonoBehaviour
{
    public static Particle instace;
    [HideInInspector]
    public int positive;
    [HideInInspector]
    public float Charge;
    [HideInInspector]
    public Color color = Color.black;
    [HideInInspector]
    public float ints;
    public Material material;
    public GameObject[] particles;
    [SerializeField]

    public Rigidbody rb;
    private double k = 8.9875517873681764;
    private Vector3 force = Vector3.zero;
    private Vector3 prom;
    [HideInInspector]
    public bool start = false;
    private int indx = 0;
    // Start is called before the first frame update
    /* void Awake()
    {
        positive = Random.Range(0, 2);
        Charge = Random.Range(50, 101);
        ints = Charge;
        if (positive == 1)
        {
            color.b = Mathf.Clamp(ints, 25, 75) / 100;

        }
        else
        {
            color.r = Mathf.Clamp(ints, 25, 75) / 100;
            Charge *= -1;
        }
        material.color = color;
    }*/
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {

        if (start && indx < 37)
        {

            force.x += (float)System.Math.Round((k * (particles[indx].GetComponent<Particle>().Charge * Charge) / Mathf.Pow(Mathf.Abs(transform.position.x) - Mathf.Abs(particles[indx].GetComponent<Particle>().transform.position.x), 2)), 5);
            force.z += (float)System.Math.Round((k * (particles[indx].GetComponent<Particle>().Charge * Charge) / Mathf.Pow(Mathf.Abs(transform.position.z) - Mathf.Abs(particles[indx].GetComponent<Particle>().transform.position.z), 2)), 5);
            if (force.x == Mathf.Infinity)
            {
                force.x = 0f;
            }
            if (force.z == Mathf.Infinity)
            {
                force.z = 0f;
            }
            indx++;
        }
        if (indx == 37)
        {
            rb.AddForce(force);
            indx++;
        }
    }
}

