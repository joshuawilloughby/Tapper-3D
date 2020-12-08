using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Bartender bartender;
    public BeerHandler beer;

    public BarTap barTap;

    public Button pourButton;
    public Button serveButton;

    public bool pourBeer;
    public bool serveBeer;

    void Start()
    {
        serveButton.interactable = false;
        serveButton.gameObject.SetActive(false);

        pourButton.interactable = false;
        pourButton.gameObject.SetActive(false);
    }

    public void Serve()
    {
        if (bartender.canServe)
        {
            serveBeer = true;
            Debug.Log("serving");
        }
    }

    public void Pour()
    {
        if (bartender.canPour)
        {
            barTap = bartender.currentKeg.GetComponent<BarTap>();
            barTap.canPourBeer = true;
            pourBeer = true;
            Debug.Log("pouring");
        }
    }
}
