using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
class Ball_ : MonoBehaviour
{
    // �{�[���̈ړ��̑������w�肷��ϐ�
    public float speed = 3;
    Rigidbody2D myRigidbody;
    public float angle;
    public GameObject player;
    Vector3 m_velocity;
    int x, y;
    void Start()
    {
        angle = Random.Range(210,300);
        Application.targetFrameRate = 60; // 30fps�ɐݒ�
        // Rigidbody�ɃA�N�Z�X���ĕϐ��ɕێ����Ă���
        myRigidbody = GetComponent<Rigidbody2D>();
        var direction = GetDirection(angle);
        m_velocity = direction * speed * 0.01f;
    }
    //�e�̊p�x
    public static Vector3 GetDirection(float angle)
    {
        return new Vector3
        (
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),0
        );
    }
    //�v���C���[�ƒe�̊Ԃ̊p�x
    public float GetAngleToPlayer()
    {
        Vector3 dt = player.transform.position - this.transform.position;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 20;
        }
        else 
        {
            speed = 10;
        }     

        //���݊p�x���擾
        var direction = GetDirection(angle);
        // ���ˊp�x�Ƒ������瑬�x�����߂�
        m_velocity = direction * speed * 0.01f;
        transform.localPosition += m_velocity;
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collisions based on tag
        switch (collision.tag)
        {
            case "LeftWall":
            case "RightWall":
                angle = 180 - angle;
                break;
            case "TopWall":
            case "UnderWall":
                angle = -angle;
                break;
            case "Player":
                // Reflect angle based on player's position
                angle = GetAngleToPlayer()+180;
                break;
                // Add more cases as needed
        }
    }





}