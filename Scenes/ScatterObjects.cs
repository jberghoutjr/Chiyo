using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterObjects : MonoBehaviour
{
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public GameObject objectToCreate;
    public int numberToSpawn;
    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector2 randomPosition = new Vector2(
                    Random.Range(minPosition.x, maxPosition.x),
                    Random.Range(minPosition.y, maxPosition.y)
                     );
            Instantiate(objectToCreate, randomPosition, Quaternion.Euler(0, 45, 0));
        }
    }
}
