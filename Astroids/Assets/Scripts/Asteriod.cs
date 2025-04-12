using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteriod : MonoBehaviour
{
    //constants
    private const float MINSIZE = 0.5f, MAXSIZE = 2f;
    //variables
    private Vector2 playerPos;
    private Vector3 movementVector;
    private Camera cam;
    private float speed, size;
    // Start is called before the first frame update
    void Start()
    {
        size = getRandomSize();
        setAsteroidSize(size);
        setAsteroidSpeed(size);
        speed = 5f;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().getPosition();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
    private void setAsteroidSpeed(float size)
    {
        if(size > MINSIZE && size < MAXSIZE / 2)
        {
            speed = 5;
        }else if(size > MAXSIZE /2 && size < MAXSIZE - MINSIZE)
        {
            speed = 2.5f;
        }
        else if(size > MAXSIZE - MINSIZE && size < MAXSIZE)
        {
            speed = 1;
        }
    }
    private void setAsteroidSize(float size)
    {
        transform.localScale = new Vector3(size, size, 0);
    }
    private float getRandomSize()
    {
          
        return Random.Range(MINSIZE, MAXSIZE);
    }
}
