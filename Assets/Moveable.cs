using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

    public void Move(float direction)
    {
        Vector3 rot = transform.localEulerAngles;
        float degrees = rot.z + direction;
        if (degrees > 360) degrees -= 360;
        else if (degrees < 0) degrees += 360;

        rot.z = degrees;
        transform.localEulerAngles = rot;
    }
}
