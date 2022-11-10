using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sword : MonoBehaviour
{
    public float swordVelocity;
    private Vector3 _lastDirectionRef; 
    public Vector3 direction;
    public XRController xRController;

    // Start is called before the first frame update
    private void Start()
    {
        xRController = transform.GetComponentInParent<XRController>();
    }
    

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        direction = position - _lastDirectionRef;
        _lastDirectionRef = position;
        swordVelocity = direction.magnitude / Time.deltaTime;
        direction = direction.normalized; 
    }

}

