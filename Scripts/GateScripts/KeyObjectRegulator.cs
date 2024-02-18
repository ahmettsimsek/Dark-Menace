using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyNetwork
{
    public class KeyObjectRegulator : MonoBehaviour
    {
        [SerializeField] private bool key = false;
        [SerializeField] private bool Gate = false;
        [SerializeField] private KeyList keyList = null;

        private KeyGateRegulator gateObject;

        private void Start()
        {
            if (Gate)
            {
                gateObject = GetComponent<KeyGateRegulator>();
            }
        }

        public void foundObject()
        {
            if (key)
            {
                keyList.hasKey = true;
                gameObject.SetActive(false);
         
            }
            else if (Gate)
            {
                gateObject.StartAnimation();
            }

        }
    }
}
