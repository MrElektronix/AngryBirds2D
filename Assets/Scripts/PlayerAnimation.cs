using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    Vector3 previous;
    [SerializeField]
    float velocity;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    bool Expl = false;
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
        if (other.collider.tag == "Damager")
        {
            anim.SetTrigger("Explode");
            StartCoroutine(Wait());

        }
    }


    void FixedUpdate()
    {
        velocity = (transform.position - previous).magnitude / Time.deltaTime;
        previous = transform.position;
        if(velocity > 10)
        {
            anim.SetTrigger("inAir");
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
