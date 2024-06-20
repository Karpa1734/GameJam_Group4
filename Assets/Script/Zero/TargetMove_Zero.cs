using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove_Zero : MonoBehaviour
{
    public float speed = 2.0f;  // オブジェクトの移動速度 

    public float leftBoundary = -4.5f; // 左端

    public float rightBoundary = 4.5f; // 右端



    private Vector3 direction = Vector3.right; 

 

    void Update()

    {

        // オブジェクトを移動させる 

        transform.Translate(direction * speed * Time.deltaTime);



        // 方向を変更する 

        if(transform.position.x >= rightBoundary)

        {

            direction = Vector3.left;

        }

        else if (transform.position.x <= leftBoundary)

        {

            direction = Vector3.right;

        }

    }
}