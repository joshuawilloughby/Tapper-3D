using System.Security.Cryptography;
using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public LivesSystem lives;
    public ButtonHandler buttonHandler;

    public ScoreSystem scoreSystem;

    public bool serveBeer;

    public bool alreadyserved;

    public bool isDestroyed;

    public Transform target;
    public Transform throwbackTarget;
    public float speed;

    public int chanceToComeBack;

    public bool isThrowBack;

    public void Start()
    {
        buttonHandler.isFilled = false;
        alreadyserved = false;
        isThrowBack = false;
    }

    public void Update()
    {
        if (isThrowBack)
        {
            serveBeer = false;
        }

        if (serveBeer)
        {
            buttonHandler.isFilled = true;
        }

        if (!serveBeer)
        {
            buttonHandler.isFilled = false;
        }

        if (!serveBeer && isThrowBack)
        {
            throwBack();
        }

        if (buttonHandler.isFilled)
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

    public void throwBack()
    {
        transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        var targetPos = new Vector3(throwbackTarget.position.x, 5, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("BeerDetector"))
        {
            scoreSystem.score += 50;
            scoreSystem.currentScore.text = "Score: " + scoreSystem.score;

            if (chanceToComeBack >= 20)
            {
                Destroy(col.gameObject.transform.parent.gameObject);

                isThrowBack = true;
            }

            if (chanceToComeBack < 20)
            {
                Destroy(col.gameObject.transform.parent.gameObject);
                Destroy(this.gameObject);
                isDestroyed = true;
            }
        }

        if (col.gameObject.CompareTag("DestroyDrink"))
        {
            Destroy(this.gameObject);
            isDestroyed = true;
            lives.currentLives = lives.currentLives - 1;
        }

        if (col.gameObject.CompareTag("BrokenDrink") && isThrowBack)
        {
            Destroy(this.gameObject);
            isDestroyed = true;
            Debug.Log("drink broke so loose a life");
            lives.currentLives = lives.currentLives - 1;
        }
    }
}
