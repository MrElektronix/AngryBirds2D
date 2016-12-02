using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    Vector3 previous;
    float velocity;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;

    void FixedUpdate()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;
        if(velocity > 10)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }
}
