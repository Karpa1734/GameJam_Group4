using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitBox_Kotatumuri : MonoBehaviour
{
    [SerializeField] GameObject ParentObj;
    //�I���󂵂����̏���(�e�̉����A����A���ŁAetc�c)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(ParentObj);
            Ball_Kotatumuri.speedBase = Ball_Kotatumuri.speedBase + 2;
        }
    }
}
