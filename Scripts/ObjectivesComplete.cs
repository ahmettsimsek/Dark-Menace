using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesComplete : MonoBehaviour
{
    [Header("Objectives to Complete")]
    public Text objective1;
    public Text objective2;
    public Text objective3;
    public Text objective4;

    public static ObjectivesComplete occurrence;

    private void Awake()
    {
        occurrence = this;
    }

    public void GetObjectivesDone(bool obj1, bool obj2, bool obj3, bool obj4)
    {
        if(obj1 == true)
        {
            objective1.text = "1.Anahtar alindi ve kapi acildi";
            objective1.color = Color.green;
        }
        else
        {
            objective1.text = "1. Kapiyi acmak icin anahtari bul";
            objective1.color = Color.white;
        }


        if (obj2 == true)
        {
            objective2.text = "2. Bilgisayar kapatildi";
            objective2.color = Color.green;
        }
        else
        {
            objective2.text = "2. bilgisayar sistemini kapat";
            objective2.color = Color.white;
        }


        if (obj3 == true)
        {
            objective3.text = "3. jeneratorler kapatildi";
            objective3.color = Color.green;
        }
        else
        {
            objective3.text = "3. jeneratorlerin guc kaynaklarini kapat";
            objective3.color = Color.white;
        }


        if (obj4 == true)
        {
            objective4.text = "4. Gorev Tamamlandi";
            objective4.color = Color.green;
        }
        else
        {
            objective4.text = "4. Zirhli araci bul ve tesisten kac";
            objective4.color = Color.white;
        }
    }
}
