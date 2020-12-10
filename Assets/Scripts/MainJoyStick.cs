using UnityEngine;

public class MainJoyStick : MonoBehaviour
{
    private Rigidbody rb;
    public float moveForce = 10f;

    private FixedJoystick joystick;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    public void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveForce, rb.velocity.y, joystick.Vertical * moveForce);

        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}
