using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitBox_Fuji : MonoBehaviour
{
    [SerializeField] GameObject ParentObj;
    public bool isdestroy;
    //�I���󂵂����̏���(�e�̉����A����A���ŁAetc�c)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {   if(isdestroy==true){
            Destroy(collision.gameObject);
        }
    Destroy(ParentObj);}
    }
}