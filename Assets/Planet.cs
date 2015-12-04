using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public states state;
    private Moveable moveable;

    public enum states
    {
        RUNNING
    }
    void Start()
    {
        moveable = GetComponent<Moveable>();
    }
    public void Move(float direction)
    {
        moveable.Move(direction);
    }
}
