using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteriod : MonoBehaviour
{
    private Vector2 playerPos;
    private float speed;
    private Vector3 movementVector;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().getPosition();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        speed = 5f;
        movementVector = (playerPos - (Vector2)transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkToDestroy();
    }
    public void checkToDestroy()
    {
        if (cam.WorldToScreenPoint(transform.position).x > Screen.width + 20 || cam.WorldToScreenPoint(transform.position).x < - 20)
        {
            Destroy(gameObject);
        }
    }

    private void move()
    {
        transform.position += movementVector * Time.deltaTime;
    }
}
