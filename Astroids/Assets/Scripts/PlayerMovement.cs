using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float PlayerRotationZAxis;
    private float boostingVelocity, floatingVelocity;
    private Rigidbody2D rb;
    private CameraFunctions cf;
    private Animator animator;
    [SerializeField] private Transform thrustLocation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFunctions>();
        PlayerRotationZAxis = 0;
        floatingVelocity = rb.velocity.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForceAtPosition(transform.right, thrustLocation.position);
            boostingVelocity = rb.velocity.x;
        }
        else
        {
            floatingVelocity = boostingVelocity;
        }

        if(floatingVelocity != boostingVelocity)
        {
            animator.SetBool("Boosting",true);
        }
        else
        {
            animator.SetBool("Boosting", false);
        }
        rotatePlayer();
        checkWithinBonds();
    }

    public void checkWithinBonds()
    {
        if(transform.position.x > cf.getCameraBondWidth() + 1)
        {
            transform.position = new Vector2((cf.getCameraBondWidth() * -1) - 1, transform.position.y);
        }

        if(transform.position.x < (cf.getCameraBondWidth() * -1) -1)
        {
            transform.position = new Vector2(cf.getCameraBondWidth() + 1, transform.position.y);
        }

        if(transform.position.y > cf.getCameraBondHight() + 1)
        {
            transform.position = new Vector2(transform.position.x, (cf.getCameraBondHight() * -1) - 1);
        }

        if (transform.position.y < (cf.getCameraBondHight() * -1) - 1)
        {
            transform.position = new Vector2(transform.position.x, cf.getCameraBondHight() + 1);
        }


    }

    public void rotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerRotationZAxis += 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerRotationZAxis -= 1;
        }
        transform.eulerAngles = new Vector3(0, 0, PlayerRotationZAxis);
    }

    public Vector2 getPosition()
    {
        return transform.position;
    }
}
