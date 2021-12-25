using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb2D;
    private float horizontalInput;
    private float verticalInput;

    private bool grabbing = false;

    private GameObject grabbedObject;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // move character left and right
        rb2D.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space)) { 
        
            if (grabbedObject != null)
            {
                HingeJoint2D hingeJoint2D = grabbedObject.GetComponent<HingeJoint2D>();
                hingeJoint2D.connectedBody = null;
                hingeJoint2D.enabled = false;
                grabbedObject = null;
                grabbing = false;
            }
            else
            {
                grabbing = !grabbing;
            }
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the relative position of the grabbable object
        if (collision.gameObject.tag == "grabbable" && grabbing)
        {
            // if not already grabbing anything
            
            HingeJoint2D hingeJoint2D = collision.gameObject.GetComponent<HingeJoint2D>();
            if (!hingeJoint2D.enabled)
            {
                grabbing = false;
                grabbedObject = collision.gameObject;
                hingeJoint2D.enabled = true;
                hingeJoint2D.connectedBody = rb2D;
                hingeJoint2D.connectedAnchor = new Vector2(rb2D.position.x, rb2D.position.y);
            }

        }
    }
}
