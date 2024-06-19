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
    //的を壊した時の処理(弾の加速、分裂、消滅、etc…)

}
