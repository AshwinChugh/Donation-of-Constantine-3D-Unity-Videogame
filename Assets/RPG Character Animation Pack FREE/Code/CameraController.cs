using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform target;
    private Transform camTransform;

    

    public float Y_ANGLE_MIN = -20.0f;
    public float Y_ANGLE_MAX = 70.0f;



    public float distance;
    private float currentX;//This is the real Y lol
    private float currentY;//The real X lol --> Both are switched
    public float sensitivityX = 1.0f;
    public float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += (Input.GetAxis("Mouse X") * sensitivityX);//x axis
        currentY += (Input.GetAxis("Mouse Y")* sensitivityY);//y axis

        currentY = Mathf.Clamp(currentX, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Debug.Log(currentX + " : " + currentY);
        camTransform.position = target.position + rotation * dir;
        camTransform.LookAt(target.position);
    }
}