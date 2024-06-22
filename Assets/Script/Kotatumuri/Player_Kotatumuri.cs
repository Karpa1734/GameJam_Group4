using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Player_Kotatumuri : MonoBehaviour
{
    // �v���C���[�̈ړ��̑���
    public float speedBase = 8;
    private float speed;
    Rigidbody2D myRigidbody;
    int x, y;
    public static int frame = 0;
    [SerializeField] Text Timer;
    [SerializeField] GameObject Over;
    [SerializeField] GameObject Clear;
    int sec = 0;
    int sec2 = 0;
    [SerializeField] Text Count;
    void Start()
    {
        Timer.text = "00:00";
        frame = 0;
        // Rigidbody�ɃA�N�Z�X���ĕϐ��ɕێ�
        myRigidbody = GetComponent<Rigidbody2D>();
        //�ŏ��̓J�E���g�_�E���͋�
        Count.text = "";
    }

    void Update()
    {
        //�G�X�P�[�v�L�[�Ń^�C�g����
        if (Input.GetKey(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("Title");
        }

        frame++;
        //�J�E���g�_�E������
        if (frame== 30) { Count.text = "3"; }
        if (frame == 90) { Count.text = "2"; }
        if (frame == 150) { Count.text = "1"; }
        if (frame == 210) { Count.text = "GO!!"; }
        if (frame == 240) { Count.text = " "; }
        //�J�E���g�_�E�����I������瓮���o��
        if (frame>210) { 
        // ���E�̃L�[���͂ɂ�葬�x��ύX����
        myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, 0f);
        Move();
            if (Over.activeSelf == false && Clear.activeSelf == false)
            {
                Timer.text = sec2.ToString("d2") + ":" + sec.ToString("d2");
                sec++;
                if (sec >= 60) { sec = 0; sec2 += 1; }
            }
        }
    }

    void Move()
    {
        x = (int)Input.GetAxisRaw("Horizontal");
        y = (int)Input.GetAxisRaw("Vertical");
        //���V�t�g�������Ă���Ԃ͑��x�ቺ
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedBase/3;
        }
        else
        {
            speed = speedBase;
        }

        Vector3 nextPoint = transform.position + new Vector3(x, y, 0) * Time.deltaTime * speed;
        //X��-4.2�`4.2�Ԃł݈̂ړ��\
        nextPoint = new Vector3(
                  Mathf.Clamp(nextPoint.x, -3.7f, 3.7f),
                  Mathf.Clamp(nextPoint.y, -4f, -4f),
                  0
                  );

        transform.position = nextPoint;

    }
}