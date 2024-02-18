using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadding : MonoBehaviour
{

    float time, second;
    public Image FillImage;
    // Start is called before the first frame update
    void Start()
    {
        second = 18;
        Invoke("LoadGame", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 18)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time / second;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
}
