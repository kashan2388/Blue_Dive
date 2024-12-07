using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private bool isGrappling;
    [SerializeField] private bool isUnGrappling;
    [SerializeField] private LayerMask callBackGrappleLayer;
    [SerializeField] private LayerMask callBackUnGrappleLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & callBackGrappleLayer) != 0)
        {
            isGrappling = true;
        }
        else if (((1 << collision.gameObject.layer) & callBackUnGrappleLayer) != 0)
        {
            isUnGrappling = true;
        }
    }
    private void OnEnable()
    {
        isGrappling = false;
        isUnGrappling = false;
    }
}
