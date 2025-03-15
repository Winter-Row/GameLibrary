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

        checkWithinBonds();
        
        //Debug.Log(gameObject.transform.position.x);
    }

    public void checkWithinBonds()
    {
        if (cf.getPlayerCameraPos().x <= Screen.width)
        {
            checkPlayerMovement();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void checkPlayerMovement()
    {
        playerInputX = Input.GetAxis("Horizontal");
        playerInputY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(playerSpeed * playerInputX, playerSpeed * playerInputY);
    }
}
