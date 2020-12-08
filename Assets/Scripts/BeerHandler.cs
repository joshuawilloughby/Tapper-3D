using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public bool isFilled;

    public Transform pointB;
    public float speed;

    void Start()
    {
        if (!isFilled)
        {
            //empty glass
        }

        isFilled = false;
    }

    void Update()
    {
        if (isFilled)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("BeerDetector"))
        {
            Destroy(col.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
            Debug.Log("destroyed customer and beer");
        }
    }
}
