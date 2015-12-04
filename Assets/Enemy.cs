using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed;
    private Moveable moveable;

	void Start () {
        moveable = GetComponent<Moveable>();
	}
	void Update () {
        moveable.Move(speed);
	}
}
