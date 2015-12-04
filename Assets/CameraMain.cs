using UnityEngine;
using System.Collections;

public class CameraMain : MonoBehaviour {

    public Transform target;
    public Camera camera;
    public float rotationSpeed ;

    void Start()
    {
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotationSpeed);
        transform.localPosition = Vector3.Lerp(transform.localPosition,target.localPosition, Time.deltaTime * rotationSpeed);
    }
}
