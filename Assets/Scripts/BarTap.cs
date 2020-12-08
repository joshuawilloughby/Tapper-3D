using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTap : MonoBehaviour
{
    public Bartender bartender;

    public GameObject emptyMug;
    public GameObject fullMug;

    public Transform mugSpawn;
    public Transform fullMugSpawn;

    public GameObject newEmptyBeerMug;
    public Rigidbody newEmptyBeerMugRig;

    public GameObject newFullBeerMug;
    public Rigidbody newFullBeerMugRig;

    public bool canPourBeer;

    public bool canRemoveMug;

    public bool spawned;
    public bool fullMugSpawned;

    public ButtonHandler buttonHandler;

    void Start()
    {
        spawned = false;
        fullMugSpawned = false;
        canPourBeer = false;
        canRemoveMug = false;
    }

    void Update()
    {
        if (canPourBeer && buttonHandler.pourBeer && !spawned && bartender.currentKeg.GetComponent<BarTap>())
        {
            newEmptyBeerMug = Instantiate(emptyMug, mugSpawn.position, mugSpawn.rotation);
            newEmptyBeerMugRig = newEmptyBeerMug.GetComponent<Rigidbody>();

            newEmptyBeerMugRig.constraints = RigidbodyConstraints.FreezeAll;

            spawned = true;
        }

        if (canRemoveMug && !fullMugSpawned)
        {
            Destroy(newEmptyBeerMug);

            newFullBeerMug = Instantiate(fullMug, fullMugSpawn.position, fullMugSpawn.rotation);
            newFullBeerMugRig = newFullBeerMug.GetComponent<Rigidbody>();

            newFullBeerMugRig.constraints = RigidbodyConstraints.FreezeAll;

            fullMugSpawned = true;
        }
    }
}
