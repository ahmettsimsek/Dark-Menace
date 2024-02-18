using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHealthBarUI : MonoBehaviour
{
    public Transform MainCamera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + MainCamera.forward);
    }

}
