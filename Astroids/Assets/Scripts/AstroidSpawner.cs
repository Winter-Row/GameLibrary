using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    private Camera camera;
    private GameObject astroid;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        astroid = Resources.Load<GameObject>("Astroid");
        spawnPoint = camera.ViewportToWorldPoint(new Vector3(1f, 1f, 0));
        Instantiate(astroid, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
