using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{

    public GameObject[] collectiblePrefab;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3f, 10f);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Spawn()
    {
        int collectibleIndex = Random.Range(0, collectiblePrefab.Length);
        int spawnPointIndex = Random.Range(0, collectiblePrefab.Length);
        GameObject selectedPrefab = collectiblePrefab[spawnPointIndex];
        float playerX = player.transform.position.x;
        float playerZ = player.transform.position.z;
        float prefabY = selectedPrefab.transform.position.y;
        Vector3 spawnPoint = new Vector3(playerX + 5, prefabY, playerZ + 5);
        Instantiate(selectedPrefab, spawnPoint, selectedPrefab.transform.rotation);

    }
}
