using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeyNetwork
{
    public class KeyRaycast : MonoBehaviour
    {
        [Header("Raycast Radius and Layer")]
        [SerializeField] private int rayRadius = 6;
        [SerializeField] private LayerMask LayerMaskCollective;
        [SerializeField] private string banLayerName = null;

        private KeyObjectRegulator raycastedObject;
        [SerializeField] private KeyCode openGateButton = KeyCode.F;
        [SerializeField] private Image crosshair = null;

        private bool checkCrosshair;
        private bool Onetime;

        private string collectiveTag = "collectiveObject";

        private void Update()
        {
            RaycastHit hitInfo;

            Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(banLayerName) | LayerMaskCollective.value;

            if(Physics.Raycast(transform.position, forwardDirection, out hitInfo, rayRadius, mask))
            {
                if(hitInfo.collider.CompareTag(collectiveTag))
                {
                    if(!Onetime)
                    {
                        raycastedObject = hitInfo.collider.gameObject.GetComponent<KeyObjectRegulator>();
                        ChangeCrosshair(true);
                    }

                    checkCrosshair = true;
                    Onetime = true; 

                    if(Input.GetKeyDown(openGateButton))
                    {
                        raycastedObject.foundObject();
                    }
                }
            }
            else
            {
                if(checkCrosshair)
                {
                    ChangeCrosshair(false);
                    Onetime = false;
                }
            }
        }

        void ChangeCrosshair(bool changeCH)
        {
            if(changeCH && !Onetime)
            {
                crosshair.color = Color.blue;
            }
            else
            {
                crosshair.color = Color.white;
                checkCrosshair = false;
            }
        }
    }

}