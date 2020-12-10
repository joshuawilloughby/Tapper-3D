using UnityEngine;

public class Bartender : MonoBehaviour
{
    public ButtonHandler serveButtonHandler;
    public ButtonHandler pourButtonHandler;

    public BeerHandler beerHandler;

    public BarTap barTap;

    public bool canPour;
    public bool canServe;

    public GameObject currentKeg;

    public void Start()
    {
        canPour = false;
        canServe = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PlayerDetector") && !barTap.isCarryingMug)
        {
            barTap = col.gameObject.transform.parent.gameObject.GetComponent<BarTap>();
            canPour = true;
            pourButtonHandler.pourButton.gameObject.SetActive(true);
            pourButtonHandler.pourButton.interactable = true;
            currentKeg = col.gameObject.transform.parent.gameObject;
        }

        if (col.gameObject.CompareTag("Counter"))
        {
            if (barTap.isCarryingMug)
            {
                canServe = true;
                serveButtonHandler.serveButton.gameObject.SetActive(true);
                serveButtonHandler.serveButton.interactable = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("PlayerDetector"))
        {
            canPour = false;
            pourButtonHandler.pourButton.interactable = false;
        }

        if (col.gameObject.CompareTag("Counter"))
        {
            canServe = false;
            serveButtonHandler.serveButton.interactable = false;
        }
    }

}
