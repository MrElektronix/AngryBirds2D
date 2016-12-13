using UnityEngine;

public class BlockHealth : MonoBehaviour {
    [SerializeField]
    private float health;

    [SerializeField]
    private Sprite lightyDamagedSprite, mediumDamagedSprite;

    private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
        _renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddDamage(float damage)
    {
        health -= damage;
        if (health <= 20)
        {
            _renderer.sprite = lightyDamagedSprite;
        }
       
    }
}
