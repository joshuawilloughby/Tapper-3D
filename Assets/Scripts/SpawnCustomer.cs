using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public Customer customerScript;
    public GameObject newCustomer;
    public Rigidbody newCustomerRig;

    public GameObject customer;

    public bool spawned = false;

    public bool stopSpawning = false;

    public float spawnTime;
    public float spawnDelay;

    public float lowerDelayBound;
    public float upperDelayBound;

    public void Start()
    {
        spawnDelay = Random.Range(lowerDelayBound, upperDelayBound);
        InvokeRepeating("Spawn", spawnTime, spawnDelay);

        GameObject customer = gameObject.transform.parent.parent.gameObject;
    }

    public void Update()
    {
       customerScript.chanceToTip = Random.Range(1, 5);
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
