using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunctions : MonoBehaviour
{
    private Camera camera;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        player = GameObject.Find("Ship");
    }

    public Vector3 getPlayerCameraPos()
    {
        return camera.WorldToScreenPoint(player.transform.position);
    }

    public float getCameraBondHight()
    {
        
        return camera.orthographicSize + gameObject.transform.position.y;
    }

    public float getCameraBondWidth()
    {
        return camera.orthographicSize + gameObject.transform.position.x;
    }
}
