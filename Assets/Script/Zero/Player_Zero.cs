using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Player_Zero : MonoBehaviour
{
    // プレイヤーの移動の速さ
    public float speedBase = 8;
    private float speed;
    Rigidbody2D myRigidbody;
    int x, y;
    public static int frame = 0;
    [SerializeField] Text Count;
    [SerializeField] Text Timer;
    [SerializeField] GameObject Gameover;
    [SerializeField] GameObject Gamecrer;
    int second1, second2;
    void Start()
    {
        frame = 0;
        // Rigidbodyにアクセスして変数に保持
        myRigidbody = GetComponent<Rigidbody2D>();
        //最初はカウントダウンは空白
        Count.text = "";
        second1 = 0;
        second2 = 0;
        Timer.text = "00:00";
    }

    void Update()
    {
        //エスケープキーでタイトルへ
        if (Input.GetKey(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("Title");
        }

        frame++;
        //カウントダウンする
        if (frame== 30) { Count.text = "3"; }
        if (frame == 90) { Count.text = "2"; }
        if (frame == 150) { Count.text = "1"; }
        if (frame == 210) { Count.text = "GO!!"; }
        if (frame == 240) { Count.text = " "; }
        //カウントダウンが終わったら動き出す
        if (frame>210) { 
        // 左右のキー入力により速度を変更する
        myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, 0f);
        Move();
            if (Gameover.activeSelf == false && Gamecrer.activeSelf == false)
            {
                Timer.text =second2.ToString("d2")+":"+second1.ToString("d2");
                second1++;
                if (second1 >= 60)
                {
                    second2++;
                    second1 = 0;
                }
            }
        }
    }

    void Move()
    {
        x = (int)Input.GetAxisRaw("Horizontal");
        y = (int)Input.GetAxisRaw("Vertical");
        //左シフトを押している間は速度低下
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedBase/3;
        }
        else
        {
            speed = speedBase;
        }

        Vector3 nextPoint = transform.position + new Vector3(x, y, 0) * Time.deltaTime * speed;
        //Xは-4.2～4.2間でのみ移動可能
        nextPoint = new Vector3(
                  Mathf.Clamp(nextPoint.x, -4.2f,  4.2f),
                  Mathf.Clamp(nextPoint.y, -4f, -4f),
                  0
                  );

        transform.position = nextPoint;

    }
}