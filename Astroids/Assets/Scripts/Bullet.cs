using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 playerTransform;
    private CameraFunctions camFunc;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform.right;
        camFunc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFunctions>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += playerTransform * (Time.deltaTime * speed);
        checkBonds();
    }
    private void checkBonds()
    {
        if(transform.position.x > camFunc.getCameraBondWidth() + 2 || transform.position.x < (camFunc.getCameraBondWidth() * -1) - 1 
            || transform.position.y > camFunc.getCameraBondHight() + 2 || transform.position.y < (camFunc.getCameraBondHight() * - 1) - 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Asteriod")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
