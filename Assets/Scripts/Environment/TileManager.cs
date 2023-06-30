using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float tileLength = 30;
    public float zSpawn = 0;
    public int numTilesOn = 5;
    [SerializeField] private List<GameObject> activeTiles = new List<GameObject>();
    public float offset;
    [SerializeField] private int TilesYouGo = 0;
    public Transform playerTransform;
    public PlayerMove playerMove;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numTilesOn; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - offset > zSpawn -(numTilesOn * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
            TilesYouGo += 1;
            ChekGoTiles();
        }

    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void ChekGoTiles()
    {
        if(TilesYouGo % 5 == 0)
        {
            if(TilesYouGo < 100)
            {
                playerMove.forwardSpeed += 0.05f;
            }
            
            else if(TilesYouGo > 100 && TilesYouGo < 500)
            {
                playerMove.forwardSpeed += 0.01f;
            }

            else
            {
                playerMove.forwardSpeed += 0.0001f;
            }

        }
    }
}
