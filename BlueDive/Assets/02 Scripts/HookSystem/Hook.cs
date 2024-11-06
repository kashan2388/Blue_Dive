using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private LayerMask callBackGrapple;
    [SerializeField] private LayerMask callBackUnGrapple;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
