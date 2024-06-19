using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetLife_Karpa: MonoBehaviour
{
    public int life = 1;
    SpriteRenderer BoxImage;
    void Start()
    {
       BoxImage = this.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (life == 5) { BoxImage.color = new Color32(0, 255, 0, 255); }
        if (life == 4) { BoxImage.color = new Color32(0, 255, 255, 255); }
        if (life == 3) { BoxImage.color = new Color32(255, 255, 0, 255); }
        if (life == 2) { BoxImage.color = new Color32(255, 128, 0, 255); }
        if (life == 1) { BoxImage.color = new Color32(255, 0, 0, 255); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            life -= 1;
            if (life <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
