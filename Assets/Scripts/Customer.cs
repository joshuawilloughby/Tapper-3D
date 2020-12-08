using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("CustomerDetector"))
        {
            Destroy(this.gameObject);
            Debug.Log("loose a life");
        }
    }
}
