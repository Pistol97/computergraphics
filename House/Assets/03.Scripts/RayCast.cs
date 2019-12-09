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
            if (hit.collider.CompareTag("Redbook"))
            {
                CrosshairActive();
                rayCastedObject = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    rayCastedObject.SetActive(false);
                    RedBook.StartHorror = true;
                    Debug.Log(RedBook.StartHorror.ToString());
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
