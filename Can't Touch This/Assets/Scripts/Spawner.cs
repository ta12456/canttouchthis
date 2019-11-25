using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
	//public GameObject[] objects;                // The prefab to be spawned.
	public float spawnTime = .5f;            // How long between each spawn.
    public Camera cam;
    public Rigidbody2D proj;
    public Transform player;
    //public Transform target;
     void Spawn()
    {
        int horiz_edge = Random.Range(0, 2);
        float pos = UnityEngine.Random.value;
        print(pos);
        Vector2 target;
        if (horiz_edge == 1)
        {
            target = cam.ViewportToWorldPoint(new Vector2(pos, Random.Range(0, 2)));
        }
        else
        {
            target = cam.ViewportToWorldPoint(new Vector2(Random.Range(0, 2), pos));
        }
        print(target);

        Rigidbody2D newProj = Instantiate(proj, target, Quaternion.identity);
        float speed = Random.Range(1, 3);
 
        newProj.velocity = (player.position - newProj.transform.position).normalized * speed;
        //newProj.GetComponent<BoxCollider2D>().transform
    }

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("Spawn", 1, spawnTime);
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
    {
        //print("Helajdfkajfklsdjfaklsjflasjfklasdlkfjas");
    }
}
