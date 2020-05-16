using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;
    public float creationTime;

    public Tile(GameObject T, float ct)
    {
        theTile = T;
        creationTime = ct;
    }
}

public class CreateTerrain : MonoBehaviour
{
    public GameObject player;
    public GameObject plane;

    int planeSize = 100;
    int worldSizeX = 3;
    int worldSizeZ = 3;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();

    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -worldSizeX; x < worldSizeX; x++)
        {
            for(int z = -worldSizeZ; z < worldSizeZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x),
                                            0,
                                           (z * planeSize + startPos.z));

                GameObject t = Instantiate(plane, pos, Quaternion.identity);

                string tileName = "Tile_" + ((int)pos.x).ToString() + "_" + ((int)pos.z).ToString();
                t.name = tileName;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tileName, tile);
            }
        }
    }

   
    void Update()
    {
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor(player.transform.position.x));
            int playerZ = (int)(Mathf.Floor(player.transform.position.z));

            for (int x = -worldSizeX; x < worldSizeX; x++)
            {
                for(int z = -worldSizeZ; z < worldSizeZ; z++)
                {
                    Vector3 pos = new Vector3((x * planeSize + startPos.x),
                                            0,
                                           (z * planeSize + startPos.z));

                    string tileName = "Tile_" + ((int)pos.x).ToString() + "_" + ((int)pos.z).ToString();

                    if (!tiles.ContainsKey(tileName))
                    {
                        GameObject t = Instantiate(plane, pos, Quaternion.identity);
                        t.name = tileName;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tileName, tile);
                    } else
                    {
                        (tiles[tileName] as Tile).creationTime = updateTime;
                    }
                }
            }

            Hashtable newMap = new Hashtable();
            foreach(Tile tls in tiles.Values)
            {
                if (tls.creationTime != updateTime)
                {
                    Destroy(tls.theTile);
                } else
                {
                    newMap.Add(tls.theTile.name, tls);
                }
            }

            tiles = newMap;

            startPos = player.transform.position;
        }
    }
}
