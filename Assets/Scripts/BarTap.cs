using UnityEngine;

public class BarTap : MonoBehaviour
{
    public GameObject player;

    public Transform cloneHolder;

    public Bartender bartender;

    public GameObject emptyMug;
    public GameObject fullMug;

    public Transform mugSpawn;
    public Transform fullMugSpawn;

    public GameObject newEmptyBeerMug;
    public Rigidbody newEmptyBeerMugRig;

    public GameObject newFullBeerMug;
    public Rigidbody newFullBeerMugRig;

    public Transform beerClone;

    public bool canPourBeer;

    public bool canRemoveMug;

    public bool spawned;
    public bool fullMugSpawned;

    public bool isCarryingMug;

    public ButtonHandler buttonHandler;
    public BeerHandler beerHandler;

    void Start()
    {
        spawned = false;
        fullMugSpawned = false;
        canPourBeer = false;
        canRemoveMug = false;
        isCarryingMug = false;
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
            newFullBeerMug.transform.parent = cloneHolder;
            newFullBeerMugRig = newFullBeerMug.GetComponent<Rigidbody>();

            newFullBeerMugRig.constraints = RigidbodyConstraints.FreezeAll;

            fullMugSpawned = true;

            beerClone = cloneHolder.Find("Beer full(Clone)");
            Transform beerHolder = player.gameObject.transform.Find("MugHolder");
            beerClone.parent = beerHolder;
            beerClone.position = beerHolder.position;
            isCarryingMug = true;

            beerHandler = newFullBeerMug.GetComponent<BeerHandler>();
            buttonHandler.isFilled = false;

            beerHandler.chanceToComeBack = Random.Range(1, 25);

            if (beerHandler.isDestroyed)
            {
                beerHandler = null;
            }
        }
    }
}
