using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

    Animator anim;

    public int hitPoints = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed;

    private int currentHitPoints;
    //private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitPoints = hitPoints;
        anim = GetComponent<Animator>();
        //damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
        {
            return;
        }
            
            
        //spriteRenderer.sprite = damagedSprite;
        currentHitPoints -= 2;
        //Debug.Log("currentHitPoints: " + currentHitPoints);

        if (currentHitPoints <= 0)
        {
            Kill();
        }
         
    }

    void Kill()
    {
        anim.SetTrigger("Dead");
        Destroy(gameObject, 0.  4f); 
    }
}
