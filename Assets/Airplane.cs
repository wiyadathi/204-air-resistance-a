using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 50f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.003f;
    [SerializeField] float angularDrag = 0.03f;

    [SerializeField] float yawPower = 50f;     // Turning speed
    [SerializeField] float pitchPower = 50f;   // Nose up/down speed
    [SerializeField] float rollPower = 30f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //1. Engine Thrust (Engine Power)
        //Pressing Spacebar applies force in the forward direction of the airplane(transform.forward).
        //Simulates engine thrust, making the airplane accelerate forward.
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }

        //2. Lift Force - Simulates how airplanes gain altitude
       Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        /*      // 3️. Drag (Air Resistance) - Prevents infinite acceleration
             rb.linearDamping = rb.linearVelocity.magnitude * drag;
             rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

             //4. Rotation Controls - Pitch, Yaw, and Roll
             float yaw = Input.GetAxis("Horizontal") * yawPower;   // Left/Right (A/D)
             float pitch = Input.GetAxis("Vertical") * pitchPower; // Nose Up/Down (W/S)
             float roll = Input.GetAxis("Roll") * rollPower;       // Roll (Q/E)

             rb.AddTorque(transform.up * yaw);       // Yaw (Turn left/right)
             rb.AddTorque(transform.right * pitch);  // Pitch (Nose up/down)
             rb.AddTorque(transform.forward * roll); // Roll (Tilting)
     */
    }
}


//rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1f);
//rb.AddTorque(Input.GetAxis("Vertical") * transform.right);
