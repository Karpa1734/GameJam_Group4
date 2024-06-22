using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Player_Kotatumuri : MonoBehaviour
{
    // プレイヤーの移動の速さ
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
        // Rigidbodyにアクセスして変数に保持
        myRigidbody = GetComponent<Rigidbody2D>();
        //最初はカウントダウンは空白
        Count.text = "";
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
                  Mathf.Clamp(nextPoint.x, -3.7f, 3.7f),
                  Mathf.Clamp(nextPoint.y, -4f, -4f),
                  0
                  );

        transform.position = nextPoint;

    }
}