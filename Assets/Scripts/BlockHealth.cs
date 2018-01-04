using UnityEngine;

public class BlockHealth : MonoBehaviour {
    [SerializeField]
    private float health;

    [SerializeField]
    private Sprite[] sprites;

    private Score score;
    private SpriteRenderer _renderer;

    public GameObject points;
    

    // Use this for initialization
    void Start () {
        points = GameObject.Find("Points");
        
        _renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        _renderer.sprite = sprites[Mathf.CeilToInt(health - 1)];
    }


    void AddDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            gameObject.SetActive(false);
            points.GetComponent<Score>().NewPoints(500);
            if (gameObject.tag == "DamagerWood")
            {
                ParticleSystem p = Instantiate(Resources.Load<ParticleSystem>("Explosion1"));
                p.transform.position = transform.position;
                p.Play();
            }
            if (gameObject.tag == "DamagerStone")
            {
                ParticleSystem p = Instantiate(Resources.Load<ParticleSystem>("Explosion2"));
                p.transform.position = transform.position;
                p.Play();
            }
        }
    }
}
