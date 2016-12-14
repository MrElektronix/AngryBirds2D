using UnityEngine;
using System.Collections;

public class BirdTrail : MonoBehaviour
{
    private MouseHandler mHand;
    private int counter;
    private bool collide;
    [SerializeField]
    private GameObject smoke;
    [SerializeField]
    private GameObject biggerSmoke;
    [SerializeField]
    private GameObject biggestSmoke;


	void Start ()
    {
        
        counter = 0;
        mHand = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseHandler>();
        StartCoroutine(Trail());
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Damager")
        {
            collide = true;
        }
    }

    private IEnumerator Trail() 
    {
        yield return new WaitForSeconds(0.035f);

        if (mHand.ActivateTrail && collide == false)
        {
            
            Instantiate(smoke, transform.position, Quaternion.identity);
            if(counter == 0)
            {
                Instantiate(smoke, transform.position, Quaternion.identity);
                counter += 1;
            }
            else if (counter == 1)
            {
                Instantiate(biggerSmoke, transform.position, Quaternion.identity);
                counter += 1;
            }
            else if (counter == 2)
            {
                counter = 0;
                Instantiate(biggestSmoke, transform.position, Quaternion.identity);
            }
        }

        StartCoroutine(Trail());
    }
}
