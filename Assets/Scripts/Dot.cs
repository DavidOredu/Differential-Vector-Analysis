using UnityEngine;

public class Dot : MonoBehaviour
{
    public Vector3 point;
    public Vector3 pointDerivative;

    public Vector3[,] coefficients;

    public bool showDebugLines = true;
    public bool useLongLine;
    public void SetPoint(Vector3 point)
    {
        this.point = point;
        useLongLine = false;
    }

    public void SetCoefficients(Vector3[,] coefficients)
    {
        this.coefficients = coefficients;
    }

    public void SetPointDerivative()
    {
        pointDerivative = new Vector3(
            coefficients[0, 0].x * (point.x * point.x * point.x) + coefficients[0, 0].y * (point.x * point.x) + coefficients[0, 0].z * point.x +
            coefficients[0, 1].x * (point.y * point.y * point.y) + coefficients[0, 1].y * (point.y * point.y) + coefficients[0, 1].z * point.y +
            coefficients[0, 2].x * (point.z * point.z * point.z) + coefficients[0, 2].y * (point.z * point.z) + coefficients[0, 2].z * point.z +
            coefficients[0, 3].x * (point.x * point.y) + coefficients[0, 3].y * (point.x * point.z) + coefficients[0, 3].z * (point.y * point.z) /*+ (point.x * point.y * point.z)*/,
            coefficients[1, 0].x * (point.x * point.x * point.x) + coefficients[1, 0].y * (point.x * point.x) + coefficients[1, 0].z * point.x +
            coefficients[1, 1].x * (point.y * point.y * point.y) + coefficients[1, 1].y * (point.y * point.y) + coefficients[1, 1].z * point.y +
            coefficients[1, 2].x * (point.z * point.z * point.z) + coefficients[1, 2].y * (point.z * point.z) + coefficients[1, 2].z * point.z +
            coefficients[1, 3].x * (point.x * point.y) + coefficients[1, 3].y * (point.x * point.z) + coefficients[1, 3].z * (point.y * point.z) /*+ (point.x * point.y * point.z)*/,
            coefficients[2, 0].x * (point.x * point.x * point.x) + coefficients[2, 0].y * (point.x * point.x) + coefficients[2, 0].z * point.x +
            coefficients[2, 1].x * (point.y * point.y * point.y) + coefficients[2, 1].y * (point.y * point.y) + coefficients[2, 1].z * point.y +
            coefficients[2, 2].x * (point.z * point.z * point.z) + coefficients[2, 2].y * (point.z * point.z) + coefficients[2, 2].z * point.z +
            coefficients[2, 3].x * (point.x * point.y) + coefficients[2, 3].y * (point.x * point.z) + coefficients[2, 3].z * (point.y * point.z) /*+ (point.x * point.y * point.z)*/
            );
    }

    private void Update()
    {
        if (showDebugLines)
        {
            if (useLongLine)
                Debug.DrawLine(point, pointDerivative, Color.yellow);
            else
                Debug.DrawLine(point, new Vector3(point.x + 0.2f, point.y + 0.2f), Color.yellow);
        }
    }
}
