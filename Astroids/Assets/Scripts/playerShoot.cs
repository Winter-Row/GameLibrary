using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    /*TO DO
     * Create a shooting cool down so cant fire infintly 
     */
    [SerializeField] private Transform gunLoaction;
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, gunLoaction.position, Quaternion.identity);
        }
    }
}
