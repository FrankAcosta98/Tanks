using System.Drawing;
using System.Collections;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Vector3[] points = new Vector3[4];
    public Segment[] Segments = new Segment[4];

    public int frames;
    public ClosedTrajectory path;
    void Awake()
    {
        Segments[0] = new Segment(points[0], points[1], frames);
        Segments[1] = new Segment(points[1], points[2], frames);
        Segments[2] = new Segment(points[2], points[3], frames);
        Segments[3] = new Segment(points[3], points[0], frames);
        path = new ClosedTrajectory(4);
        path.AddSeg(Segments[0], 0);
        path.AddSeg(Segments[1], 1);
        path.AddSeg(Segments[2], 2);
        path.AddSeg(Segments[3], 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = path.Advance();

    }
    public class Segment
    {

        public Vector3 origin;
        public Vector3 position;
        public Vector3 destination;
        public int frames;
        private int Cframe;
        public int passed = 0;
        public Segment(Vector3 origin, Vector3 destination, int frames = 0)
        {
            this.origin = origin;
            this.destination = destination;
            this.frames = frames;
            this.position = origin;
        }
        public Vector3 Advance()
        {
            float interpolation = (float)passed / frames;
            position = Vector3.Lerp(origin, destination, interpolation);
            passed = (passed + 1) % (frames + 1);
            return position;
        }
    }
    public abstract class Trajectory
    {
        public Segment[] Positions;
        public Segment Cseg;
        public int indx;
        public void Append(Segment posA, Segment posB)
        {
            posB.origin = posA.destination;
        }
        abstract public Vector3 Advance();

        public void AddSeg(Segment segment, int pos)
        {
            Positions[pos] = segment;
        }
    }
    public class ClosedTrajectory : Trajectory
    {
        public ClosedTrajectory(int indx)
        {
            Positions = new Segment[indx];
        }
        public override Vector3 Advance()
        {
            Cseg = Positions[indx];
            if (Cseg.passed >= Cseg.frames)
            {
                indx++;
                if (indx > 3)
                    indx = 0;
            }
            return Cseg.Advance();
        }
    }
    public class OpenTrajetory : Trajectory
    {
        public override Vector3 Advance()
        {
            Cseg = Positions[indx];
            if (Cseg.passed >= Cseg.frames)
            {
                if (indx <= 3)
                    indx ++;
            }
            return Cseg.Advance();
        }
    }
}

