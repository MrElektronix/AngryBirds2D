using UnityEngine;

public class BlockHealth : MonoBehaviour {
    [SerializeField]
    private float health;

    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
        _renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        _renderer.sprite = sprites[Mathf.CeilToInt(health - 1)];
                
    }


    void AddDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
