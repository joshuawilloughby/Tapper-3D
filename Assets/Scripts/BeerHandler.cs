using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public ButtonHandler buttonHandler;

    public bool isFilled;

    public bool isDestroyed;

    public Transform target;
    public float speed;

    void Start()
    {
        isFilled = false;
    }

    void Update()
    {
        if (buttonHandler.serveBeer)
        {
            isFilled = true;
        }

        if (!buttonHandler.serveBeer)
        {
            isFilled = false;
        }

        if (isFilled)
        {
            Move();
        }

        Debug.Log("Is filled: " + isFilled);
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
            isDestroyed = true;
            //get points
        }

        if (col.gameObject.CompareTag("DestroyDrink"))
        {
            Destroy(this.gameObject);
            isDestroyed = true;
            //loose a life
        }
    }
}
