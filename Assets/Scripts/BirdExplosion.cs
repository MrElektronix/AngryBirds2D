using UnityEngine;
using System.Collections;

public class BirdExplosion : MonoBehaviour {

    public Vector2 force = new Vector2 (10, 10);
    private Rigidbody2D rb;
    private Vector2 explosionPos;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ExplosionWait());
    }
	
	
	void Update ()
    {
        Vector2 explosionPos = transform.position;
    }

    private IEnumerator ExplosionWait()
    {
        yield return new WaitForSeconds(6);
        Debug.Log("Explode");
        //rb.AddForce(explosionPos, ForceMode2D.Impulse);
        rb.AddForceAtPosition(force, explosionPos, ForceMode2D.Force);
        
    }

}
