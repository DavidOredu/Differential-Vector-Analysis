using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGenerator : SerializedMonoBehaviour
{
    private List<Dot> dots = new List<Dot>();

    public Dot dotPrefab;
    public Vector3Int dotGrid;

    [TableMatrix(HorizontalTitle = "Coefficient Matrix")]
    public Vector3[,] coefficients = new Vector3[3, 4]
    {
        {new Vector3(), new Vector3(), new Vector3(), new Vector3()},
        {new Vector3(), new Vector3(), new Vector3(), new Vector3()},
        {new Vector3(), new Vector3(), new Vector3(), new Vector3()},
    };

    public int FPS = 60;
    public float speed;
    public bool stepSimulation = true;

    private void Awake()
    {
        Application.targetFrameRate = FPS;
    }
    // Start is called before the first frame update
    void Start()
    {
        Dot dot;
        Vector3 newPoint;

        for (int x = -dotGrid.x; x < dotGrid.x; x++)
        {
            for (int y = -dotGrid.y; y < dotGrid.y; y++)
            {
                for (int z = -dotGrid.z; z < dotGrid.z; z++)
                {
                    newPoint = new Vector3(x, y, z);
                    dot = Instantiate(dotPrefab, newPoint, Quaternion.identity);

                    dot.SetPoint(newPoint);
                    dot.SetCoefficients(coefficients);
                    dot.SetPointDerivative();

                    dots.Add(dot);
                }
            }
        }
    }

    private void Update()
    {
        if (stepSimulation)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                RunSimulation();
            }
        }
        else
        {
            RunSimulation();
        }
    }

    private void RunSimulation()
    {
        for (int i = 0; i < dots.Count; i++)
        {
            var direction = (dots[i].pointDerivative - dots[i].point).normalized;

            dots[i].transform.position = dots[i].point + (direction * speed);

            dots[i].SetPoint(dots[i].transform.position);
            dots[i].SetPointDerivative();
        }
    }
}
