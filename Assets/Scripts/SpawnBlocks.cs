using UnityEngine;
using System.Collections;


public class SpawnBlocks : MonoBehaviour {
	public float spawnTime = 0.1f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	public GameObject[] blocks;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	void Spawn ()
	{
		// Instantiate a random enemy.
		int blockIndex = Random.Range(0, blocks.Length);
		Instantiate(blocks[blockIndex], new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f),-3f), transform.rotation);
	}
	// Update is called once per frame
	
}
