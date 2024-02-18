using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text ammunitionText;
    public Text magText;

    public static AmmoCount occurrence;

    private void Awake()
    {
        occurrence = this;
    }

    public void updateAmmoText(int presentAmmunition)
    {
        ammunitionText.text = "Mermi." + presentAmmunition;
    }

    public void UpdateMagText(int mag)
    {
        magText.text = " Cephane." + mag;
    }
}
