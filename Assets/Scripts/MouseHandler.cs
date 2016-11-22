using UnityEngine;
using System.Collections;

public class MouseHandler : MonoBehaviour {

    private bool hasTarget;
    private Transform target;
    private GameObject slingShot;
    [SerializeField]
    private float range;
    [SerializeField]
    private float power;

        void Start ()
    {
        slingShot = GameObject.Find("SlingShot");
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            if(hasTarget)
            {
                hasTarget = false;
                Vector3 dir;
                dir = target.position - slingShot.transform.position;
                //dir = -dir.normalized;
                Debug.Log(dir);

                Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
                rb.isKinematic = false;
                rb.AddForce(-dir * power);
            }
        }
        if (Input.GetMouseButton(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.tag == "Player")
                {
                    hasTarget = true;
                    target = hit.transform;
                }
            }

        }
        if (hasTarget)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            //if (Vector3.Distance(slingShot.transform.position, pos) > range) return;
            Vector3 offset = pos - slingShot.transform.position;
            pos = slingShot.transform.position + Vector3.ClampMagnitude(offset, range);
            target.position = pos;
        }
    }

    void OnDrawGizmos()
    {
        if (slingShot)
        {
            Gizmos.DrawWireSphere(slingShot.transform.position, range);
        }
    }
}
