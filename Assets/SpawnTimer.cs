using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public GameObject bola;
    // Start is called before the first frame update
    private IEnumerator coroutine;
    private GameObject[] particles = new GameObject[37];
    private Vector3 vec;
    private int indx = 0;
    private int postive;
    private float charge;
    private float wait = 0f;
    private bool stop = false;
    void Start()
    {
        coroutine = Enumerator(0.5f);
        StartCoroutine(coroutine);
    }
    void Update()
    {
        if (indx >= 37&&stop==false)
        {
            StopCoroutine(coroutine);
            for (int i = 0; i < 37; i++)
            {
                particles[i].GetComponent<Particle>().particles = particles;
                particles[i].GetComponent<Particle>().start = true;
            }
            stop = true;
        }
        postive = Random.Range(0, 2);
        charge = Random.Range(50, 101);
    }
    // Update is called once per frame


    private IEnumerator Enumerator(float tiempoespera)
    {

        while (true)
        {
            yield return new WaitForSeconds(tiempoespera);
            vec.Set(Random.Range(-500, 500), 1, Random.Range(-500, 500));
            GameObject Sphere = Instantiate(bola, vec, Quaternion.identity) as GameObject;
            particles[indx] = Sphere;
            Sphere.GetComponent<Renderer>().material.color = Color.black;
            Sphere.GetComponent<Particle>().positive = postive;
            Sphere.GetComponent<Particle>().Charge = charge;
            Sphere.GetComponent<Particle>().ints = Sphere.GetComponent<Particle>().Charge;
            if (Sphere.GetComponent<Particle>().positive == 1)
            {
                Sphere.GetComponent<Particle>().color.b = (Sphere.GetComponent<Particle>().ints - 25) / 100;

            }
            else
            {
                Sphere.GetComponent<Particle>().color.r = (Sphere.GetComponent<Particle>().ints - 25) / 100;
                Sphere.GetComponent<Particle>().Charge *= -1;
            }
            Sphere.GetComponent<Renderer>().material.color = Sphere.GetComponent<Particle>().color;
            indx++;
        }
    }
}
