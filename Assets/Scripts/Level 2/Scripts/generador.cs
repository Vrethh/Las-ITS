using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    public GameObject pipePrefab;
    public int generadortime = 100;
    private int timer;

    void FixedUpdate()
    {
      timer++;
      if (timer >= generadortime)
      {
            timer=0;
            GameObject newObstacle =
            Instantiate(pipePrefab, new Vector2
            (pipePrefab.transform.position.x, 
            pipePrefab.transform.position.y 
            + Random.Range(-0.5f, 0.5f)), pipePrefab.transform.rotation);
            Destroy(newObstacle, 4f);
      }
    }
}
