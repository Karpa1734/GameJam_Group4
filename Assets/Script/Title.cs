using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Title : MonoBehaviour
{
    [SerializeField] Button Secret;
    [SerializeField] Text Secrettxt;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Karpa_Clear", 0) == 1 && PlayerPrefs.GetInt("Fuji_Clear", 0) == 1 && PlayerPrefs.GetInt("Zero_Clear", 0) == 1 && PlayerPrefs.GetInt("Kotatumuri_Clear", 0) == 1 && Secret.interactable == false) 
        { 
            Secret.interactable = true;
            Secrettxt.text = "StageEX";
        }
        else 
        {
            Secret.interactable = false;
            Secrettxt.text = "?????";
        }
    }

    public void OnButton(int i)
    {
        if (i == 1)
        {
            SceneManager.LoadScene("Karpa");
        }
        else if(i == 2)
        {
            SceneManager.LoadScene("Kotatumuri");
        }
        else if (i == 3)
        {
            SceneManager.LoadScene("Fuji");
        }
        else if (i == 4)
        {
            SceneManager.LoadScene("Zero");
        }
        else if (i == 5)
        {
            SceneManager.LoadScene("Extra");
        }
    }

}
