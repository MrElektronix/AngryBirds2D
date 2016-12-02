using UnityEngine;
using System.Collections;

public class EyeBlinkAnimation : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitAndPrint());
       
    }
	
	void Update () {
	
	}
    private IEnumerator WaitAndPrint()
    {
        while (true)
        {
            spriteRenderer.sprite = sprite1;
            yield return new WaitForSeconds(2.0f);
            spriteRenderer.sprite = sprite2;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
