using UnityEngine;
using System.Collections;

public class SpawnBlocks : MonoBehaviour {
/*
 *  Representation of a block set's orientation
 *		
 *		[00][01][02][03]
 * 		[04][05][06][07]
 * 		[08][09][10][11]
 * 		[12][13][14][15]
 * 
 * 	Example L Block Up Orient is [4,8,12,13]
 * 		
 * 		[ ]
 * 		[ ]
 * 		[ ][ ]
 */
	public struct BlockSet
	{
		public string sBlock_Type;
		public int[][] iaBlock_Orient;	
	}

	public float spawnTime = 0.1f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	public GameObject[] blocks;
	public int iLevel_Size_X = 40;
	public int iLevel_Size_Y = 40;
	public int iBlockCount = 0;
	public BlockSet[] bsBlockSets = new BlockSet[7];

	// Use this for initialization
	void Start () {
		bsBlockSets [0] = new BlockSet();
		bsBlockSets [0].sBlock_Type 			= "LBLOCK";
		bsBlockSets [0].iaBlock_Orient = new int[4][];
		bsBlockSets [0].iaBlock_Orient[0] 		= new int[]{4,8,12,13};
		bsBlockSets [0].iaBlock_Orient[1]	 	= new int[]{4,5,9,13};
		bsBlockSets [0].iaBlock_Orient[2] 		= new int[]{10,12,13,14};
		bsBlockSets [0].iaBlock_Orient[3] 		= new int[]{8,9,10,12};

		bsBlockSets [1] = new BlockSet();
		bsBlockSets [1].sBlock_Type 			= "JBLOCK";
		bsBlockSets [1].iaBlock_Orient = new int[4][];
		bsBlockSets [1].iaBlock_Orient[0] 		= new int[]{5,9,12,13};
		bsBlockSets [1].iaBlock_Orient[1] 		= new int[]{4,5,8,12};
		bsBlockSets [1].iaBlock_Orient[2] 		= new int[]{8,9,10,14};
		bsBlockSets [1].iaBlock_Orient[3] 		= new int[]{8,12,13,14};

		bsBlockSets [2] = new BlockSet();
		bsBlockSets [2].sBlock_Type 			= "LONGBLOCK";
		bsBlockSets [2].iaBlock_Orient = new int[4][];
		bsBlockSets [2].iaBlock_Orient[0] 		= new int[]{0,4,8,12};
		bsBlockSets [2].iaBlock_Orient[1] 		= new int[]{0,4,8,12};
		bsBlockSets [2].iaBlock_Orient[2] 		= new int[]{12,13,14,15};
		bsBlockSets [2].iaBlock_Orient[3] 		= new int[]{12,13,14,15};
		
		bsBlockSets [3] = new BlockSet();
		bsBlockSets [3].sBlock_Type 			= "BOXBLOCK";
		bsBlockSets [3].iaBlock_Orient = new int[4][];
		bsBlockSets [3].iaBlock_Orient[0] 		= new int[]{8,9,12,13};
		bsBlockSets [3].iaBlock_Orient[1] 		= new int[]{8,9,12,13};
		bsBlockSets [3].iaBlock_Orient[2] 		= new int[]{8,9,12,13};
		bsBlockSets [3].iaBlock_Orient[3] 		= new int[]{8,9,12,13};
		
		bsBlockSets [4] = new BlockSet();
		bsBlockSets [4].sBlock_Type 			= "TBLOCK";
		bsBlockSets [4].iaBlock_Orient = new int[4][];
		bsBlockSets [4].iaBlock_Orient[0] 		= new int[]{8,9,10,13};
		bsBlockSets [4].iaBlock_Orient[1] 		= new int[]{9,12,13,14};
		bsBlockSets [4].iaBlock_Orient[2] 		= new int[]{4,8,9,12};
		bsBlockSets [4].iaBlock_Orient[3] 		= new int[]{5,8,9,13};
		
		bsBlockSets [5] = new BlockSet();
		bsBlockSets [5].sBlock_Type 			= "ZBLOCK";
		bsBlockSets [5].iaBlock_Orient = new int[4][];
		bsBlockSets [5].iaBlock_Orient[0] 		= new int[]{5,8,9,12};
		bsBlockSets [5].iaBlock_Orient[1] 		= new int[]{5,8,9,12};
		bsBlockSets [5].iaBlock_Orient[2] 		= new int[]{8,9,13,14};
		bsBlockSets [5].iaBlock_Orient[3] 		= new int[]{8,9,13,14};
		
		bsBlockSets [6] = new BlockSet();
		bsBlockSets [6].sBlock_Type 			= "SBLOCK";
		bsBlockSets [6].iaBlock_Orient = new int[4][];
		bsBlockSets [6].iaBlock_Orient[0] 		= new int[]{4,8,9,13};
		bsBlockSets [6].iaBlock_Orient[1] 		= new int[]{4,8,9,13};
		bsBlockSets [6].iaBlock_Orient[2] 		= new int[]{9,10,12,13};
		bsBlockSets [6].iaBlock_Orient[3] 		= new int[]{9,10,12,13};

		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
//	void Spawn ()
//	{
//		// Instantiate a random enemy.
//		int blockIndex = Random.Range(0, blocks.Length);
//		Instantiate(blocks[blockIndex], new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f),-3f), transform.rotation);
//	}


	private void Spawn()
	{
		if(iBlockCount<800)
		{
			int orientIndex = Random.Range (0, 4);
			int blockSetIndex = Random.Range (0, bsBlockSets.Length);
			float start_X_Index = ((float) Random.Range(0,iLevel_Size_X-4))*0.5f;
			float start_Y_Index = (iLevel_Size_Y*0.5f) - ((float)Random.Range(0,iLevel_Size_Y-4))*0.5f;
			Instantiate(blocks[blockSetIndex],new Vector3(start_X_Index+ ((float)(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][0]%4))*0.5f,
			                              start_Y_Index- ((float)Mathf.FloorToInt(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][0]/4f))*0.5f,
			                              -3f), transform.rotation);
			Instantiate(blocks[blockSetIndex],new Vector3(start_X_Index+ ((float)(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][1]%4))*0.5f,
			                              start_Y_Index- ((float)Mathf.FloorToInt(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][1]/4f))*0.5f,
			                              -3f), transform.rotation);
			Instantiate(blocks[blockSetIndex],new Vector3(start_X_Index+ ((float)(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][2]%4))*0.5f,
			                              start_Y_Index- ((float)Mathf.FloorToInt(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][2]/4f))*0.5f,
			                              -3f), transform.rotation);
			Instantiate(blocks[blockSetIndex],new Vector3(start_X_Index+ ((float)(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][3]%4))*0.5f,
			                              start_Y_Index- ((float)Mathf.FloorToInt(bsBlockSets[blockSetIndex].iaBlock_Orient[orientIndex][3]/4f))*0.5f,
			                              -3f), transform.rotation);
			iBlockCount+=4;
		}
	}



	// Update is called once per frame
	
}




