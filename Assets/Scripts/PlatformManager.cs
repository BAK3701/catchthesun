using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platformPrefabs.Length - 1; i++)
        {
            if (i == 0)
            {
                SpawnPlatform(8, 0);
                offset = 26;
                SpawnPlatform(0, 0);
                SpawnPlatform(1, 0);
                SpawnPlatform(4, 0);
                SpawnPlatform(7, 0);
                SpawnPlatform(1, 0);
                SpawnPlatform(4, 0);
                SpawnPlatform(7, 0);
            }
            else
            {
                SpawnPlatform(Random.Range(0, platformPrefabs.Length - 1), Random.Range(0, 2));
            }
        }
    }
    private void Update()
    {
        if (Platforms.isDestroyed)
        {
            SpawnPlatform(Random.Range(0, platformPrefabs.Length - 1), Random.Range(0, 2));
            Platforms.isDestroyed = false;
        }
    }

    public void RecyclePlatforms(GameObject platform)
    {
        //Reposistion
        Destroy(platform);
        SpawnPlatform(Random.Range(0, platformPrefabs.Length - 1), Random.Range(0, 2));
    }

    public void SpawnPlatform(int tileIndex, int rotation)
    {
        if (rotation == 0)
        {
            Instantiate(platformPrefabs[tileIndex], new Vector3(0, 0, -offset), Quaternion.Euler(0, 0, 0));
            offset += 9;
        }
        else
        {
            Instantiate(platformPrefabs[tileIndex], new Vector3(0, 0, -offset), Quaternion.Euler(0, 180, 0));
            offset += 9;
        }
    }
}
