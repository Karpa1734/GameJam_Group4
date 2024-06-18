using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
class Ball_Karpa : MonoBehaviour
{
    // �{�[���̈ړ��̑������w�肷��ϐ�
    public float speedBase = 15;
    private float speed;
    Rigidbody2D myRigidbody;
    float angle;
    public GameObject player;
    Vector3 m_velocity;
    int x, y;
    GameObject[] tagObjects;
    [SerializeField] GameObject Over;
    [SerializeField] GameObject Clear;
    void Start()
    {
        angle = Random.Range(60,120);
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
    void CheckOver()//�Q�[���I�[�o�[���擾
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Ball");
        if (tagObjects.Length == 1)
        {
            Over.SetActive(true);//�Q�[���I�[�o�[
            speed = 0;
        }
    }
    void CheckClear()//�N���A���擾
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Target");
        if (tagObjects.Length == 0)
        {
            Clear.SetActive(true);//�Q�[���N���A
            speed = 0;
        }
    }
    private void Update()
    {
        //��Ctrl�������Ă���ԉ���
        if (!Clear.activeSelf&& !Over.activeSelf) {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = speedBase * 2;
            }
            else
            {
                speed = speedBase;
            }
        }
        if (this.transform.position.y < -5) 
        {
            Destroy(gameObject);
            CheckOver();


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
        CheckClear();
        switch (collision.tag)
        {
            case "LeftWall"://���[����
            case "RightWall"://�E�[����
                angle = 180 - angle;
                break;
            case "TopWall"://��[����
            case "UnderWall"://���[����
                angle = -angle;
                break;
            case "Player"://���@�ɓ������Ĕ���
                angle = GetAngleToPlayer()+180;
                break;
        }
    }





}