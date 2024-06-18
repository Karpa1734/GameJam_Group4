using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
class Ball_ : MonoBehaviour
{
    // ボールの移動の速さを指定する変数
    public float speed = 3;
    Rigidbody2D myRigidbody;
    public float angle;
    public GameObject player;
    Vector3 m_velocity;
    int x, y;
    void Start()
    {
        angle = Random.Range(60,120);
        Application.targetFrameRate = 60; // 30fpsに設定
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = GetComponent<Rigidbody2D>();
        var direction = GetDirection(angle);
        m_velocity = direction * speed * 0.01f;
    }
    //弾の角度
    public static Vector3 GetDirection(float angle)
    {
        return new Vector3
        (
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),0
        );
    }
    //プレイヤーと弾の間の角度
    public float GetAngleToPlayer()
    {
        Vector3 dt = player.transform.position - this.transform.position;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
    private void Update()
    {
        //左Ctrlを押している間加速
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 24;
        }
        else 
        {
            speed = 12;
        }     

        //現在角度を取得
        var direction = GetDirection(angle);
        // 発射角度と速さから速度を求める
        m_velocity = direction * speed * 0.01f;
        transform.localPosition += m_velocity;
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collisions based on tag
        switch (collision.tag)
        {
            case "LeftWall"://左端反射
            case "RightWall"://右端反射
                angle = 180 - angle;
                break;
            case "TopWall"://上端反射
            case "UnderWall"://下端反射
                angle = -angle;
                break;
            case "Player"://自機に当たって反射
                angle = GetAngleToPlayer()+180;
                break;
        }
    }





}