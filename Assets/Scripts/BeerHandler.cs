using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public ButtonHandler buttonHandler;

    public bool isFilled;

    public Transform target;
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
        if (buttonHandler.serveBeer)
        {
            isFilled = true;
        }

        if (isFilled)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        var targetPos = new Vector3(target.position.x, 5, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("BeerDetector"))
        {
            Destroy(col.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
