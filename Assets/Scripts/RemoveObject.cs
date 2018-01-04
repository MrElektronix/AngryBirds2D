using UnityEngine;
using System.Collections;

public class RemoveObject : MonoBehaviour {

	void Start () {
        Destroy(gameObject, 0.4f);
    }

}
