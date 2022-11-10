using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class testBttn : MonoBehaviour
{
    public GameObject token;

    public VirtualButtonBehaviour vb;
    // Start is called before the first frame update
    void Start()
    {
        vb.RegisterOnButtonPressed(OnBttnPressed);
        token.SetActive(false);
    }

    public void OnBttnPressed(VirtualButtonBehaviour vb)
    {
        token.SetActive(true);
        Debug.Log("Token" + token.name + "Bttn" + vb.name);
    }
}
