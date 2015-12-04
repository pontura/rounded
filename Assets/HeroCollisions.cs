using UnityEngine;
using System.Collections;

public class HeroCollisions : MonoBehaviour {

    public Hero hero;

    void Start()
    {
        hero = GetComponent<Hero>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            Planet newPlanet = other.GetComponent<Planet>();
            hero.ChangePlanet(newPlanet);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.gameObject.name == "ground")
        {
            hero.OnGround(true);
		}
        else
        {
            GameObject go = collision.transform.parent.gameObject;
            float heroHeightDiff = (collision.transform.localPosition.y - transform.localPosition.y);
            if (heroHeightDiff > 5)
            {
                if (go.GetComponent<Rebotable>())
                {
                    Rebotable rebotable = go.GetComponent<Rebotable>();
                    hero.Rebota(20);
                }
            }
        }

		if (collision.transform.parent.name == "Enemy"){
			if(hero.action!=Hero.actions.RUNNING){
				GameObject go = collision.transform.parent.gameObject;

				if (go.GetComponent<Rebotable>())
				{
					Rebotable rebotable = go.GetComponent<Rebotable>();
					hero.Rebota(20);
				}
				Destroy(collision.transform.parent.gameObject);
			}else{
				Application.LoadLevel("mainScreen");
			}

		}
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "ground")
        {
            hero.OnGround(false);
        }
    }
}
