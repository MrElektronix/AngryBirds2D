﻿using UnityEngine;
using System.Collections;

public class BlockDamage : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerToIgnore;

    [SerializeField]
    private float radius, maxDamage, minDamage, damageStep;

    

    void Start()
    {
        damageStep = maxDamage / radius;
        DamageBlocks();

    }

    void DamageBlocks()
    {
        Collider2D[] blocks = Physics2D.OverlapCircleAll(transform.position, radius, layerToIgnore);
        for (int i = 0; i < blocks.Length; i++)
        {
            Debug.Log(blocks[i].gameObject);
            float dmg = radius - Vector3.Distance(transform.position, blocks[i].transform.position);
            dmg = Mathf.Clamp(dmg, minDamage, Mathf.Infinity);
            blocks[i].gameObject.SendMessage("AddDamage", dmg * damageStep);
            Debug.Log(dmg * damageStep);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
