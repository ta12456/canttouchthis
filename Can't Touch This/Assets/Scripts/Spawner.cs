using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    //public GameObject[] objects;                // The prefab to be spawned.
    private float spawnTimeSLOW = 5f;            // How long between each spawn.
    private float spawnTimeFAST = 5f;
    private float spawnTimeSIDE = 5f;

    private float fasdfasd = 1f;

    public Camera cam;
    public Rigidbody2D proj;
    public Transform player;
    //public Transform target;

    Rigidbody2D Spawn()
    {
        float pos = UnityEngine.Random.value;
        Vector2 target = cam.ViewportToWorldPoint(new Vector2(Random.Range(0, 2), pos));
        Rigidbody2D newProj = Instantiate(proj, target, Quaternion.identity);
        return newProj;
    }

    void SpawnSlow()
    {
        Rigidbody2D newProj = Spawn();
        float speed = Random.Range(3, 6);
        newProj.velocity = (player.position - newProj.transform.position).normalized * speed;
        
        Invoke("SpawnSlow", UnityEngine.Random.value * spawnTimeSLOW + 1);
    }

    void SpawnFast()
    {
        Rigidbody2D newProj = Spawn();
        float speed = Random.Range(3, 6);
        newProj.velocity = (player.position - newProj.transform.position).normalized * speed;

        Invoke("SpawnSlow", UnityEngine.Random.value * spawnTimeFAST + 1);
    }

    void SpawnSide()
    {
        Rigidbody2D newProj = Spawn();
        float speed = Random.Range(3, 6);
        Vector2 pos = cam.WorldToViewportPoint(newProj.transform.position);
        int rightSide = Mathf.RoundToInt(pos.x);
        if (rightSide == 1)
        {
            newProj.velocity = new Vector2(-1, 0);
        }
        else
        {
            newProj.velocity = new Vector2(1, 0);
        }

        Invoke("SpawnSide", UnityEngine.Random.value * spawnTimeSIDE + 1);
    }

    void Faster()
    {
        float decrement = UnityEngine.Random.value * .5f;
        if (spawnTimeFAST - decrement >= 0f)
        {
            spawnTimeFAST -= decrement;
        }
        decrement = UnityEngine.Random.value * .5f;
        if (spawnTimeSLOW - decrement >= 0f)
        {
            spawnTimeSLOW -= decrement;
        }
        decrement = UnityEngine.Random.value * .5f;
        if (spawnTimeSIDE - decrement >= 0f)
        {
            spawnTimeSIDE -= decrement;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnSlow", UnityEngine.Random.value*3f);
        Invoke("SpawnFast", UnityEngine.Random.value*3f);
        Invoke("SpawnSide", UnityEngine.Random.value*3f);
        InvokeRepeating("Faster", 1f, 2f);
        cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
    {
        //float decrement = UnityEngine.Random.value * .1f;



    }
}
