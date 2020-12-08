using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public GameObject customer;
    public GameObject newCustomer;
    public Rigidbody newCustomerRig;

    public bool spawned = false;

    public bool stopSpawning = false;

    public float spawnTime;
    public float spawnDelay;

    public float lowerDelayBound;
    public float upperDelayBound;

    void Start()
    {
        spawnDelay = Random.Range(lowerDelayBound, upperDelayBound);
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        spawned = true;
        newCustomer = Instantiate(customer, transform.position, customer.transform.rotation);
        newCustomerRig = newCustomer.GetComponent<Rigidbody>();

        if (stopSpawning)
        {
            CancelInvoke("Spawn");
        }
    }
}
