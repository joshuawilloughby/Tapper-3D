using UnityEngine;

public class Customer : MonoBehaviour
{
    public LivesSystem lives;
    public SpawnCustomer spawnCustomer;

    public Transform target;
    public float speed;

    public float lowerBoundSpeed;
    public float upperBoundSpeed;

    public int chanceToTip;

    public GameObject moneyLocation;
    public GameObject money;

    public GameObject newTip;

    public bool alreadyTipped;

    void Start()
    {
        speed = Random.Range(lowerBoundSpeed, upperBoundSpeed);
        alreadyTipped = false;
    }

    void Update()
    {
        var targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        if (spawnCustomer.spawned)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }

        if (chanceToTip >= 5 && !alreadyTipped)
        {
            newTip = Instantiate(money, moneyLocation.transform.position, moneyLocation.transform.rotation);
            alreadyTipped = true;
        }

        if (alreadyTipped)
        {
            return;
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
