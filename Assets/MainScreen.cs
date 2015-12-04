using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Restart", 2);
	}
    void Restart()
    {
        Application.LoadLevel("game");
    }
}
