using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {

	private void NormalDestroy(GameObject Object)
    {
        Destroy(Object);
    }

    private void TimedDestroy(GameObject Object, float Time)
    {
        Destroy(Object, Time);
    }
}
