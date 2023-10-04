using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnobject;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    IEnumerator SpawnWood()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(spawnobject, new Vector3(Random.Range(-20, 20), -1, Random.Range(-20, 20)), Quaternion.identity);
        StopAllCoroutines();
    }

    private void Update()
    {
        StartCoroutine(SpawnWood());
    }
}
