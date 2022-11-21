using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    public GameObject ball;
    private GameObject Foam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
       if(other.gameObject.CompareTag("Foam")){
        Debug.Log("Nice job!");
        Foam = other.GetComponentInParent(other.GetType()).gameObject;
        Destroy(ball);
        Destroy(Foam);
       }
    }
}
