using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introscript : MonoBehaviour
{

    public GameObject introvid;
    public GameObject player;
    public GameObject introcamera;

    // Start is called before the first frame update
    void Start()
    {
        introvid.SetActive(true);
        player.SetActive(false);
        introcamera.SetActive(true );
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Baslangic());
    }

    IEnumerator Baslangic()
    {
        yield return new WaitForSeconds(21f);
        introvid.SetActive (false);
        player.SetActive(true);
        introcamera.SetActive (false);
    }
}
