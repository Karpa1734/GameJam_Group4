using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove_Zero : MonoBehaviour
{
    public float speed = 2.0f;  // �I�u�W�F�N�g�̈ړ����x 

    public float leftBoundary = -4.5f; // ���[

    public float rightBoundary = 4.5f; // �E�[



    private Vector3 direction = Vector3.right; 

 

    void Update()

    {

        // �I�u�W�F�N�g���ړ������� 

        transform.Translate(direction * speed * Time.deltaTime);



        // ������ύX���� 

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