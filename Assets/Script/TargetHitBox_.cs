using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitBox_ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ParentObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(ParentObj);
        }
    }
}
