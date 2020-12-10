using UnityEngine;

public class Customer : MonoBehaviour
{
    public LivesSystem lives;
    public SpawnCustomer spawnCustomer;

    public Transform target;
    public float speed;

    public float lowerBoundSpeed;
    public float upperBoundSpeed;

    void Start()
    {
        speed = Random.Range(lowerBoundSpeed, upperBoundSpeed);
    }

    void Update()
    {
        var targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        if (spawnCustomer.spawned)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("CustomerDetector"))
        {
            Destroy(this.gameObject);
            lives.currentLives = lives.currentLives - 1;
        }
    }
}
