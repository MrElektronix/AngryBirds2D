using UnityEngine;
using System.Collections;

public class BirdTrail : MonoBehaviour
{
    private MouseHandler mHand;
    [SerializeField]
    private GameObject Smoke;

	void Start ()
    {
        mHand = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseHandler>();
        StartCoroutine(Trail());
	}

    private IEnumerator Trail()
    {
        yield return new WaitForSeconds(0.15f);

        if (mHand.ActivateTrail)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);
        }

        StartCoroutine(Trail());
    }
}
