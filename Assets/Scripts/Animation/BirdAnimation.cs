using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour {

    private Vector3 previous;

    [SerializeField]
    private float velocity;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject Explosion;

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        previous = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "DamagerWood" || other.collider.tag == "DamagerStone")
        {
            anim.SetTrigger("Explode");
            StartCoroutine(Wait());
            ParticleSystem p = Instantiate(Resources.Load<ParticleSystem>("Feather"));
            p.transform.position = transform.position;
            p.Play();
        }
    }


    void FixedUpdate()
    {
        velocity = (transform.position - previous).magnitude / Time.deltaTime;
        previous = transform.position;
        if (velocity > 10)
        {
            anim.SetTrigger("inAir");
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
