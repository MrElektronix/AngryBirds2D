using UnityEngine;

public class BlockHealth : MonoBehaviour {
    [SerializeField]
    private float health;

    [SerializeField]
    private Sprite[] sprites;

    public GameObject pointScript;

    private SpriteRenderer _renderer;
    

    // Use this for initialization
    void Start () {
        //pointScript = GameObject.Find("Point");
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
            pointScript.GetComponent<ImagePoints>().SetPoint(500);
        }
    }
}
