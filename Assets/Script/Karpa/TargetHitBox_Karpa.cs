using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitBox_Karpa : MonoBehaviour
{
    GameObject ParentObj;
    TargetLife_Karpa scParent;
    private void Start()
    {
        ParentObj = transform.parent.gameObject;
        scParent = GetComponent<TargetLife_Karpa>();
    }
    //�I���󂵂����̏���(�e�̉����A����A���ŁAetc�c)

}
