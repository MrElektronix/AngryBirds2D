using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

    public int hitPoints = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed;

    private int currentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitPoints = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
        {
            return;
        }
            
            
        //spriteRenderer.sprite = damagedSprite;
        currentHitPoints -= 2;
        Debug.Log(currentHitPoints);

        if (currentHitPoints <= 0)
        {
            Kill();
        }
         
    }

    void Kill()
    {
        this.gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
