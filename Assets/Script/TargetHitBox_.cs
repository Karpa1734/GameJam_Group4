using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitBox_ : MonoBehaviour
{
    [SerializeField] GameObject ParentObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(ParentObj);
        }
    }
}
