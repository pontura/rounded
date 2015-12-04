using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public actions action;
    public float jumpHeight;
    public Rigidbody2D rb2d;
    public Planet planet;

    float gravityConstant = 1000f;
    float MAX_SPEED = 0.15f;
    float direction;

    public enum actions
    {
        RUNNING,
        JUMPING_UP,
        JUMPING_DOWN
    }

    void Update()
    {
        

        float gravityConstant = -50f;
        Vector3 dif = transform.position - planet.transform.position;
        Vector3 topCenter = new Vector2(dif.x, dif.y);
        topCenter.Normalize();

       // Vector2 toRight = new Vector2(dif.x, dif.y);
        //toRight.Normalize();

        rb2d.AddForce(topCenter * gravityConstant, ForceMode2D.Impulse);        
        transform.up = dif;

        Vector3 newPos = transform.localPosition - transform.right * direction *-1;
        transform.localPosition = newPos;

    }
    public void Jump()
    {
        rb2d.velocity = Vector2.zero;
        print("JUMP");        

        rb2d.AddForce(transform.up * gravityConstant, ForceMode2D.Impulse);        
    }
    public void Rebota(int force)
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(transform.up * gravityConstant, ForceMode2D.Impulse);
    }
    public void Move(float direction)
    {
        if (direction > MAX_SPEED) direction = MAX_SPEED;
        if (direction < -MAX_SPEED) direction = -MAX_SPEED;

        this.direction = direction;
    }
    public void OnGround(bool onGround)
    {
        if (onGround)
            action = actions.RUNNING;
        else action = actions.JUMPING_UP;
    }
    public void ChangePlanet(Planet planet)
    {
        this.planet = planet;
    }
}
