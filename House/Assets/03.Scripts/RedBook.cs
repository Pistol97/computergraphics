using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBook : MonoBehaviour
{
    static private bool startHorror;
    static public bool StartHorror
    {
        get { return startHorror; }
        set { startHorror = value; }
    }

    void Start()
    {
        startHorror = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
