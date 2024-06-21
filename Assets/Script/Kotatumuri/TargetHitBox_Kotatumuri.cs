using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitBox_Kotatumuri : MonoBehaviour
{
    [SerializeField] GameObject ParentObj;
    //的を壊した時の処理(弾の加速、分裂、消滅、etc…)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(ParentObj);
            Ball_Kotatumuri.speedBase = Ball_Kotatumuri.speedBase + 3;
        }
    }
}
