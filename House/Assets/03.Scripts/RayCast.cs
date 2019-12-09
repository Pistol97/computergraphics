using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    private GameObject rayCastedObject;
    [SerializeField] private LightSwitch lightSwitch;
    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;

    [SerializeField] private Image uiCrosshair;

    private void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Object"))
            {
                CrosshairActive();
                rayCastedObject = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("물체와 상호작용함");
                    rayCastedObject.SetActive(false);
                }
            }
            else if (hit.collider.CompareTag("Switch"))
            {
                CrosshairActive();
                rayCastedObject = hit.collider.gameObject;
                if (Input.GetKeyDown("e"))
                {
                    if (lightSwitch.LightOn == true)
                        lightSwitch.turnOff();
                    else
                        lightSwitch.turnOn();
                }
            }
        }
        else
        {
            CrosshairNormal();
        }
    }

    void CrosshairActive()
    {
        uiCrosshair.color = Color.red;
    }

    void CrosshairNormal()
    {
        uiCrosshair.color = Color.white;
    }
}
