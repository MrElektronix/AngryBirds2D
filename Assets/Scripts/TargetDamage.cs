using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

    private Animator anim;

    private int health = 2;
    public Sprite damagedSprite;
    private float damageImpactSpeed;

    private int currentHitPoints;
    //private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "DamagerWood" || other.collider.tag == "DamagerStone")
        {
            return;
        }
            
        health -= 2;

        if (health <= 0)
        {
            Kill();
        }
         
    }

    void Kill()
    {
        anim.SetTrigger("Dead");
        Destroy(gameObject, 0.4f);
    }
}
