using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    /*TO DO
     * Make asteriod spawning more dynamic with mulitple spawning in.
     */
    private CameraFunctions camFunc;
    private GameObject astroid;
    private Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        camFunc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFunctions>();
        astroid = Resources.Load<GameObject>("Prefabs/Astroid");
        StartCoroutine(spawnAstroid());
    }

    private void Update()
    {
        
    }

    IEnumerator spawnAstroid()
    {
        yield return new WaitForSeconds(2f);
        spawnPoint = generateSpawnPosition();
        Instantiate(astroid, spawnPoint, Quaternion.identity);
        //StartCoroutine(spawnAstroid());
    }

    private Vector2 generateSpawnPosition()
    {
        float xPos;
        float[] choices = { camFunc.getCameraBondWidth(), camFunc.getCameraBondWidth() * -1 };
        float yPos = Random.Range((camFunc.getCameraBondHight() * -1) - 2, camFunc.getCameraBondHight() + 2);

        if(yPos > camFunc.getCameraBondHight() || yPos < camFunc.getCameraBondHight() * -1)
        {
            xPos = Random.Range((camFunc.getCameraBondWidth() * -1) - 2, camFunc.getCameraBondWidth() + 2);
        }
        else
        {
            int randIndex = Random.Range(0, choices.Length);
            xPos = choices[randIndex];
        }


        return new Vector2(xPos, yPos);
    }
}
