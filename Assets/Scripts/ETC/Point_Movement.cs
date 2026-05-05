using Unity.Mathematics;
using UnityEngine;

public class Point_Movement : MonoBehaviour
{
    private Vector3 startPoint;
    private void Start()
    {
        startPoint = transform.position;    
    }

    private void Update()
    {
        float newY = math.sin(Time.time) * 0.5f;
        transform.position = new Vector3(startPoint.x, startPoint.y + newY, startPoint.z);

        transform.Rotate(Vector3.up, 10f * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, 5f * Time.deltaTime, Space.World);
    }
}
