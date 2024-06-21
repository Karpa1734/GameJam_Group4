using KanKikuchi.AudioManager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
class Ball_Kotatumuri : MonoBehaviour
{
    // ボールの移動の速さを指定する変数
    public static float speedBase = 15;
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
        Over.SetActive(false);//ゲームオーバー非表示
        Clear.SetActive(false);//ゲームクリア非表示
        angle = Random.Range(60,120);
        Application.targetFrameRate = 60; // 30fpsに設定
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = GetComponent<Rigidbody2D>();
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
    void CheckOver()//ゲームオーバーを取得
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Ball");
        if (tagObjects.Length == 1)
        {
            SEManager.Instance.Play(SEPath.OVER);
            Over.SetActive(true);//ゲームオーバー
            speed = 0;
        }
    }
    void CheckClear()//クリアを取得
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Target");
        if (tagObjects.Length == 0)
        {
            PlayerPrefs.SetInt("Kotatumuri_Clear", 1);
            Clear.SetActive(true);//ゲームクリア
            speed = 0;
        }
    }
    private void Update()
    {
        CheckClear();
        //カウントダウンが終わったら動き出す
        if (Player_Kotatumuri.frame > 210)
        {
            //左Ctrlを押している間加速
            if (!Clear.activeSelf && !Over.activeSelf)
            {
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

            //現在角度を取得
            var direction = GetDirection(angle);
            // 発射角度と速さから速度を求める
            m_velocity = direction * speed * 0.01f;
            transform.localPosition += m_velocity;
        }
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collisions based on tag
        SEManager.Instance.Play(SEPath.HIT);
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