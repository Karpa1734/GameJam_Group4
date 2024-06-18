using UnityEngine;

class Player_ : MonoBehaviour
{
    // プレイヤーの移動の速さ
    public float speedBase = 15;
    private float speed;
    Rigidbody2D myRigidbody;
    int x, y;
    void Start()
    {
        // Rigidbodyにアクセスして変数に保持
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 左右のキー入力により速度を変更する
        myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, 0f);
        Move();
        if(transform.position.y < -3) 
        {
        
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