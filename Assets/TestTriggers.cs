using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggers : MonoBehaviour
{
    public float castRadius = 1f;
    private RaycastHit hit;
    private LayerMask _layerMask;
    private QueryTriggerInteraction _castQ;

    private void Start()
    {
        _castQ = QueryTriggerInteraction.Collide;
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, castRadius, _layerMask, _castQ);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Something In Collider");
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
