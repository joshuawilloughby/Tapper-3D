using UnityEngine;

public class Bartender : MonoBehaviour
{
    #region Joystick Variables

    private Rigidbody rb;
    public float moveForce = 10f;

    public FixedJoystick moveJoystick;

    #endregion

    #region General Variables

    public ButtonHandler serveButtonHandler;
    public ButtonHandler pourButtonHandler;

    public BarTap barTap;

    public bool canPour;
    public bool canServe;

    public GameObject currentKeg;

    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveJoystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    public void Start()
    {
        canPour = false;
        canServe = false;
    }

    void Update()
    {
        rb.velocity = new Vector3(moveJoystick.Horizontal * moveForce, rb.velocity.y, moveJoystick.Vertical * moveForce);

        if (moveJoystick.Horizontal != 0f || moveJoystick.Vertical != 0f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Keg") && !barTap.isCarryingMug)
        {
            barTap = col.gameObject.GetComponent<BarTap>();
            canPour = true;
            pourButtonHandler.pourButton.gameObject.SetActive(true);
            pourButtonHandler.pourButton.interactable = true;
            currentKeg = col.gameObject;
        }

        if (col.gameObject.CompareTag("Counter"))
        {
            canServe = true;
            serveButtonHandler.serveButton.gameObject.SetActive(true);
            serveButtonHandler.serveButton.interactable = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Keg"))
        {
            canPour = false;
            pourButtonHandler.pourButton.gameObject.SetActive(false);
            pourButtonHandler.pourButton.interactable = false;
        }

        if (col.gameObject.CompareTag("Counter"))
        {
            canServe = false;
            serveButtonHandler.serveButton.gameObject.SetActive(false);
            serveButtonHandler.serveButton.interactable = false;
        }
    }
    
}
