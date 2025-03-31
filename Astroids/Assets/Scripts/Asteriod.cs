using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    private Vector2 playerPos;
    private Vector2 startingPos;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().getPosition();
        startingPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if(startingPos.x > 0 && startingPos.y > 0)
        {
            transform.position = new Vector2(transform.position.x - step, transform.position.y - step);
        }else if (startingPos.x < 0 && startingPos.y < 0)
        {
            transform.position = new Vector2(transform.position.x + step, transform.position.y + step);
        }
        //transform.position = Vector2.MoveTowards(transform.position,playerPos,step);

    }
}
