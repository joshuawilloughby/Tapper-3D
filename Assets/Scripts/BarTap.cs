using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTap : MonoBehaviour
{
    public Bartender bartender;
    public GameObject emptyMug;
    public Transform emptyMugSpawn;

    public GameObject newBeerMug;
    public Rigidbody newBeerMugRig;

    public bool canPourBeer;

    public bool spawned;

    public ButtonHandler buttonHandler;

    void Start()
    {
        spawned = false;
        canPourBeer = false;
    }

    void Update()
    {
        if (canPourBeer && buttonHandler.pourBeer && !spawned && bartender.currentKeg.GetComponent<BarTap>())
        {
            newBeerMug = Instantiate(emptyMug, emptyMugSpawn.position, emptyMugSpawn.rotation);
            newBeerMugRig = newBeerMug.GetComponent<Rigidbody>();

            newBeerMugRig.constraints = RigidbodyConstraints.FreezeAll;

            spawned = true;
        }
    }
}
