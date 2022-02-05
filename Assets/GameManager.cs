using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    private Color A;
    private Color B;
    private GameObject sphere;
    private Transform[,] tiles = new Transform[7, 15];
    private Vector3 tempPos = new Vector3(-14.1f, 0f, -4.6f);
    private int indx = 0;
    private float timer = 0;
    private bool once = true;

    // Start is called before the first frame update
    void Awake()
    {
        cam.transform.position = new Vector3(0, 30, 0);
        cam.transform.rotation = Quaternion.Euler(90, 0, 0);
        A = Random.ColorHSV();
        B = Random.ColorHSV();
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0, 3, 0);
        sphere.AddComponent(typeof(Rigidbody));
        sphere.GetComponent<Rigidbody>().isKinematic = true;
        sphere.GetComponent<Rigidbody>().mass = 0.5f;
        InvokeRepeating("CreateTile", 0f, 0.25f);
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= 2f)
        {
            if (once)
            {
                gameObject.AddComponent(typeof(Rigidbody));
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                sphere.GetComponent<Rigidbody>().isKinematic = false;
                cam.transform.position = new Vector3(0, 3, -15);
                cam.transform.rotation = Quaternion.identity;
                once = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.forward * 25f);
            if (Input.GetKey(KeyCode.RightArrow))
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -25f);
            if (Input.GetKey(KeyCode.UpArrow))
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * 25f);
            if (Input.GetKey(KeyCode.DownArrow))
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * -25f);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
    }
    void CreateTile()
    {
        if (indx < 7)
        {
            for (int i = 0; i < 15; i++)
            {
                GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Cube);
                tile.transform.parent = transform;
                tile.name = "tile";
                tile.transform.localScale = new Vector3(2f, 0.1f, 1.5f);
                tile.transform.position = tempPos;
                tempPos.x += 2f;
                tile.GetComponent<Renderer>().material.color = Color.Lerp(A, B, Random.value);
                tiles[indx, i] = tile.transform;
            }
            tempPos.x = -14.1f;
            tempPos.z += 1.5f;
            indx++;
        }
    }
}
