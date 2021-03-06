﻿using UnityEngine;
using System.Collections;

public class MouseHandler : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private bool hasTarget;
    [SerializeField]
    private Transform target;
    private GameObject slingShot;
    private GameObject LR_1;
    private GameObject LR_2;
    [SerializeField]
    private float range;
    [SerializeField]
    private float power;
    private GameObject rubBand;
    private LineRenderer lineRenderer;
    private LineRenderer lineRenderer2;
    private GameObject leftSide;
    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;
    private float coolDown = 2, coolDownTime;
    public bool ActivateTrail = false;


    void Start()
    {
        lineRenderer = GameObject.Find("RubberBand").GetComponent<LineRenderer>();
        lineRenderer2 = GameObject.Find("RubberBand2").GetComponent<LineRenderer>();
        slingShot = GameObject.Find("SlingShot");
        LR_1 = GameObject.Find("LR_1");
        LR_2 = GameObject.Find("LR_2");
        leftSide = GameObject.Find("leftSide");
        lineRenderer.sortingOrder = 8000;
        lineRenderer2.sortingOrder = 1;
    }

    void Update() {
        if (Input.GetMouseButtonUp(0))
        {
            if (hasTarget)
            {
                hasTarget = false;
                Vector3 dir;
                dir = target.position - slingShot.transform.position;

                Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
                rb.isKinematic = false;
                rb.AddForce(-dir * power);
                ActivateTrail = true;
                target = null;
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

            Vector3 offset = pos - slingShot.transform.position;
            pos = slingShot.transform.position + Vector3.ClampMagnitude(offset, range);
            target.position = pos;
            lineRenderer.SetPosition(1, leftSide.transform.position);
            lineRenderer.SetPosition(0, LR_1.transform.position);
            lineRenderer2.SetPosition(1, leftSide.transform.position);
            lineRenderer2.SetPosition(0, LR_2.transform.position);
        }
        else
        {
            if (target)
            {
                lineRenderer.SetPosition(1, leftSide.transform.position);
                lineRenderer.SetPosition(0, LR_1.transform.position);
                lineRenderer2.SetPosition(1, LR_2.transform.position);
                lineRenderer2.SetPosition(0, LR_1.transform.position);
            }
            else
            {
                lineRenderer.SetPosition(1, LR_2.transform.position);
                lineRenderer.SetPosition(0, LR_1.transform.position);
                lineRenderer2.SetPosition(1, LR_2.transform.position);
                lineRenderer2.SetPosition(0, LR_1.transform.position);
            }
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
