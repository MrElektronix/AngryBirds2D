using UnityEngine;
using System.Collections;

public class BlockHealth : MonoBehaviour {
    [SerializeField]
    private float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddDamage(float damage)
    {
        health -= damage;
        Debug.Log(damage);
    }
}
