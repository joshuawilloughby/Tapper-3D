using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public GameObject customer;
    public Transform target;
    public GameObject newCustomer;
    public Rigidbody newCustomerRig;

    public float speed;

    public bool stopSpawning = false;

    public float spawnTime;
    public float spawnDelay;

    public float lowerBoundSpeed;
    public float upperBoundSpeed;
    void Start()
    {
        speed = Random.Range(lowerBoundSpeed, upperBoundSpeed);
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    void Update()
    {
        newCustomer.transform.position = Vector3.MoveTowards(newCustomer.transform.position, target.position, speed);
    }

    public void Spawn()
    {
        newCustomer = Instantiate(customer, transform.position, customer.transform.rotation);
        newCustomerRig = newCustomer.GetComponent<Rigidbody>();

        Debug.Log("Current Speed: " + speed);

        if (stopSpawning)
        {
            CancelInvoke("Spawn");
        }
    }
}
