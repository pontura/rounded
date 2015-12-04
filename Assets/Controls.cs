using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public Hero hero;
    private bool mobileController;

    private int screen_width;

	void Start () {
        screen_width = Screen.width;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            mobileController = true;
    }
	void Update () {

        if (mobileController)
            moveByAccelerometer();
        else
        {
            if (Input.GetKeyDown("space"))
                hero.Jump();
            float newPosX = Input.mousePosition.x - screen_width / 2;
            newPosX /= 500;
            movePlanet(newPosX);
        }
	}

    private void moveByAccelerometer()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                hero.Jump();
        }
        float direction = Input.acceleration.x * 5;
        movePlanet(direction);
    }


    private void movePlanet(float direction)
    {
        hero.Move(direction);
    }
}
