using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileType
{
    FIELD,
    GROUND
}

public class Position
{
    public int x, y;


    public Position(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }

    public Position(int[] xy)
    {
        this.x = xy[0];
        this.y = xy[1];
    }

    public static Position operator +(Position a, Position b)
        => new Position(a.x + b.x, a.y + b.y);

    public bool checkBorders(Position dir)
    {
        return x + dir.x >= 0 &&
                x + dir.x < MapManager.Instance.mapWidth &&
                y + dir.y >= 0 &&
                y + dir.y < MapManager.Instance.mapHeight;
    }

    public TileType getTileType()
    {
        return MapManager.Instance.map[y, x];
    }

    public TileType getTileType(Position dir)
    {
        return MapManager.Instance.map[y + dir.y, x + dir.x];
    }
}

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject fieldPrefab;
    [SerializeField] private GameObject groundPrefab;
    public int mapWidth = 3;
    public int mapHeight = 3;

    public TileType[,] map= 
    {
    {TileType.GROUND,TileType.GROUND,TileType.FIELD},
    {TileType.GROUND,TileType.GROUND,TileType.FIELD},
    {TileType.FIELD,TileType.FIELD,TileType.FIELD}
    };


    public GameObject[,] mapObjects;

    public static MapManager Instance { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Debug.Log("instance set" + Instance);
        }
        // Creating the mapObjects
        mapObjects = new GameObject[mapWidth, mapHeight];
        for(int i = 0; i< mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                // Debug.Log("i: " + i + " j: " + j + " Type : " + map[i, j]);
                if (map[i,j] == TileType.FIELD)
                {
                    GameObject tileObj = Instantiate(fieldPrefab);
                    tileObj.transform.position = new Vector3(i, j, 0);
                    tileObj.gameObject.SetActive(true);
                    mapObjects[i,j] = tileObj;
                }
                else if(map[i,j] == TileType.GROUND)
                {
                    GameObject tileObj = Instantiate(groundPrefab);
                    tileObj.transform.position = new Vector3(i, j, 0);
                    mapObjects[i, j] = tileObj;
                }
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckTileMap()
    {
        for (int i=0;i<mapHeight;i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {

            }
        }
    }
}
