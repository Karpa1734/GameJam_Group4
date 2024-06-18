using UnityEngine;

class Player_ : MonoBehaviour
{
    // プレイヤーの移動の速さ
    public float speed = 10f;
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
    }

    void Move()
    {
        x = (int)Input.GetAxisRaw("Horizontal");
        y = (int)Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3;
        }
        else
        {
            speed = 9;
        }

        Vector3 nextPoint = transform.position + new Vector3(x, y, 0) * Time.deltaTime * speed;

        nextPoint = new Vector3(
                  Mathf.Clamp(nextPoint.x, -4.2f,  4.2f),
                  Mathf.Clamp(nextPoint.y, -4f, -4f),
                  0
                  );

        transform.position = nextPoint;

    }
}