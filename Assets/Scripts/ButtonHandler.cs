using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Bartender bartender;
    public BeerHandler beer;

    public BarTap barTap;

    public Button pourButton;
    public Button serveButton;

    public bool pourBeer;
    public bool serveBeer;

    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    public float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

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
            barTap.canRemoveMug = true;

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        barTap = bartender.currentKeg.GetComponent<BarTap>();
        barTap.canPourBeer = true;
        pourBeer = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > requiredHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Reset();
            }
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }
}
