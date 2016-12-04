using UnityEngine;
using System.Collections;

public class BirdExplosion : MonoBehaviour {

    public GameObject Explosion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

    }

}
