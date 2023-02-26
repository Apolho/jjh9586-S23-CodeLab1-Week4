using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruit;

    public GameObject bomb;

    public float minDistance;

    public float maxDistance;

    private bool bombSpawn = false;
    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("FruitSpawn", 1f, 2f); //will spawn fruits 
        if (GameManager.game == true)
        {
            InvokeRepeating("BombSpawn", 1f, 5f); //will spawn bombs
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.score > 4 && bombSpawn == false)
        {
            bombSpawn = true;
            Invoke("BombSpawn", 3f);
        }
    }

    void FruitSpawn()
    {
        transform.position = new Vector3(Random.Range(minDistance, maxDistance),35, 0); //chnages position of spawner

        GameObject newPrefab = Instantiate(fruit, transform.position, transform.rotation); //instantiates object
    }

    void BombSpawn()
    {
        transform.position = new Vector3(Random.Range(minDistance, maxDistance),35, 0);
        
        GameObject newPrefab = Instantiate(bomb, transform.position, transform.rotation);

        bombSpawn = false;

    }
}
