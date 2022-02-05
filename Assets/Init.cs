using UnityEngine;

public class Init : MonoBehaviour
{
    public Camera cam;
    private Vector3 camPosition;
    private Quaternion camrotation;
    public Vector3 FloorSize = new Vector3(50f, 0.2f, 50f);
    public float floorColorSpeed = 5f;
    public int treadsCount = 48;
    public Vector3 treadsSize = new Vector3(1.3f, 0.1f, 5f);
    public float treadRadius = 20f;
    public float treadVerticalSeparation = 0.5f;
    public float treadVerticalSpeed = 2f;
    public float treadDelay = 0.2f;
    private GameObject floor;
    private float perimeter;
    private int index = 0;
    private Color A;
    private Color B;
    //es importante que esta madre este definido porque si no puede dar error
    private Transform[] Lista;
    private float timeCounter = 0;
    private int indxUp = 0;
    private Vector3 step;
    // Start is called before the first frame update
    void Awake()
    {
        Lista = new Transform[treadsCount];
        camPosition.Set(38.4f, 20.8f, 34.2f);
        cam.transform.position = camPosition;
        cam.transform.rotation = Quaternion.Euler(22.8f, -135.3f, 0f);
        step = Vector3.zero;
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.position = new Vector3(0f, -0.1f, 0f);
        floor.transform.localScale = FloorSize;
        floor.name = "floor";
        A = Random.ColorHSV();
        B = Random.ColorHSV();
        InvokeRepeating("CreateTreads", 0f, treadDelay);
    }

    // Update is called once per frame
    void Update()
    {
        floor.GetComponent<Renderer>().material.color = Color.Lerp(A, B, Mathf.PingPong(Time.time * floorColorSpeed, 1));

        if (indxUp < treadsCount && index >= treadsCount)
        {
            step.x = Lista[indxUp].position.x;
            step.z = Lista[indxUp].position.z;
            step.y += treadVerticalSeparation;
            if (Lista[indxUp].position.y < treadVerticalSeparation)
            {
                Lista[indxUp].position = Vector3.MoveTowards(Lista[indxUp].position, step, treadVerticalSpeed);
            }
            else
            {
                treadVerticalSpeed += treadVerticalSpeed * 0.05f;
                indxUp++;
            }
        }

    }
    void FixedUpdate()
    {
        timeCounter += Time.fixedDeltaTime;
    }
    void CreateTreads()
    {
        if (index < treadsCount)
        {
            GameObject tread = GameObject.CreatePrimitive(PrimitiveType.Cube);
            tread.transform.localScale = treadsSize;
            tread.name = "tread";
            tread.transform.position = new Vector3(Mathf.Cos(timeCounter * .651f) * treadRadius, 0.05f, Mathf.Sin(timeCounter * .651f) * treadRadius);
            tread.transform.LookAt(floor.transform, Vector3.up);
            Lista[index] = tread.transform;
            index++;
        }
    }
}