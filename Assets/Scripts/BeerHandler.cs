using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public ButtonHandler buttonHandler;

    public ScoreSystem scoreSystem;

    public bool serveBeer;

    public bool alreadyserved;

    public bool isDestroyed;

    public Transform target;
    public float speed;

    public void Start()
    {
        buttonHandler.isFilled = false;
        alreadyserved = false;
    }

    public void Update()
    {
        if (serveBeer)
        {
            buttonHandler.isFilled = true;
        }

        if (!serveBeer)
        {
            buttonHandler.isFilled = false;
        }

        if (buttonHandler.isFilled)
        {
            Move();
        }

        Debug.Log("Is filled: " + buttonHandler.isFilled);
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
            scoreSystem.score += 50;
            scoreSystem.currentScore.text = "Score: " + scoreSystem.score;

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
