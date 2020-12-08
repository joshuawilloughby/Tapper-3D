using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject PepsiPrefab;
    public int TapIndex;

    public float moveSpeed = 2.0f;

    public float slideSpeed = 8.0f;

    public float minSlideDistance = 2f;
    public float maxSlideDistance = 4f;

    public bool isSliding;
    public bool isDistracted;
    public bool isDrinking;

    public bool canDrink
    {
        get 
        {
            return !isSliding && !isDrinking && !isDistracted;
        }
    }

    private BoxCollider boxCollider;
    private Rigidbody rb;

    private float currentMoveTime;
    public float RandomMoveTime;

    public bool isStopped;

    public float MinMoveTime = 1.5f;
    public float MaxMoveTime = 3.0f;

    public float MinStopTime = 0.5f;
    public float MaxStopTime = 2.5f;

    private bool ReturnBeerOnNextUpdate = false;

    void Start()
    {
        isDistracted = false;
        isDrinking = false;
        isSliding = false;
        ReturnBeerOnNextUpdate = false;

        currentMoveTime = 0;
        RandomMoveTime = 0;

        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ReturnBeerOnNextUpdate)
        {
            //spawn empty beer mug (coroutine)
            ReturnBeerOnNextUpdate = false;
            return;
        }

        if (RandomMoveTime == 0)
        {
            RandomMoveTime = Random.Range(MinMoveTime, MaxMoveTime);
        }

        MoveForward();

        if (currentMoveTime >= RandomMoveTime)
        {
            //start delay movement coroutine
        }
    }

    public void MoveForward()
    {
        if (isDrinking || isSliding || isDistracted)
        {
            return;
        }

        if (isStopped)
        {
            return;
        }
    }

    public void StartSliding()
    {
        if (isDrinking || isSliding)
        {
            return;
        }

        //start slideback coroutine
    }
}
