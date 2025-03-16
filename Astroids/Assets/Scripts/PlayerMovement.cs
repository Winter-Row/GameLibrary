using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerInputX;
    private float playerInputY;
    private float playerSpeed;
    private Rigidbody2D rb;
    private CameraFunctions cf;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFunctions>();
        playerSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //checkPlayerMovement();
        checkWithinBonds();
        
        //Debug.Log(gameObject.transform.position.x);
    }

    public void checkWithinBonds()
    {
        checkPlayerMovement();
        if (cf.getPlayerCameraPos().x > Screen.width)
        {
            //playerInputX = Input.GetAxis("Horizontal");
            //playerInputY = Input.GetAxis("Vertical");
            if(playerInputX < 0)
            {
                rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
            }
            else
            {
                rb.velocity = new Vector2(0, playerSpeed * playerInputY);
            }

        }else if(cf.getPlayerCameraPos().x < 0)
        {
            //playerInputX = Input.GetAxis("Horizontal");
            //playerInputY = Input.GetAxis("Vertical");
            if (playerInputX > 0)
            {
                rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
            }
            else
            {
                rb.velocity = new Vector2(0, playerSpeed * playerInputY);
            }

        }else if(cf.getPlayerCameraPos().y > Screen.height)
        {
            //playerInputX = Input.GetAxis("Horizontal");
            //playerInputY = Input.GetAxis("Vertical");
            if (playerInputY < 0)
            {
                rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
            }
            else
            {
                rb.velocity = new Vector2(playerSpeed * playerInputX, 0);
            }

        }else if(cf.getPlayerCameraPos().y < 0)
        {
            //playerInputX = Input.GetAxis("Horizontal");
            //playerInputY = Input.GetAxis("Vertical");
            if (playerInputY > 0)
            {
                rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
            }
            else
            {
                rb.velocity = new Vector2(playerSpeed * playerInputX, 0);
            }
        }
        else
        {
            //checkPlayerMovement();
            rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
        }

    }

    public void checkPlayerMovement()
    {
        playerInputX = Input.GetAxis("Horizontal");
        playerInputY = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
    }
}
