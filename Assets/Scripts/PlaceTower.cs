using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class PlaceTower : MonoBehaviour
{
    public Transform root;
    public Transform towerRoot; 

    public GameObject towerPrefab;

    public Tilemap tilemap;
    public Tile towerPlace;
    public Tile spawnPlace;
    public Tile keepPlace;

    [ContextMenu("PlaceTowerOnGrid")]
    public void PlaceTowerOnGrid()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        var towerRootObject = new GameObject("TowerRoot");
        towerRootObject.transform.parent = root;
        towerRoot = towerRootObject.transform;

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if(tile == towerPlace)
                {
                    GameObject cell = Instantiate(towerPrefab, new Vector3(x - 0.5f, y - 0.5f), new Quaternion(), towerRoot);
                }

                if (tile != null)
                {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                }
                else
                {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }

    [ContextMenu("DeleteTowerOnGrid")]
    public void DeleteTowerOnGrid()
    {
        DestroyImmediate(towerRoot.gameObject);
    }
}
