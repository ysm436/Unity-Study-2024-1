
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject player;
    [Space]
    public GameObject enemy;
    public float SpawnCycle;
    public Vector2 minSpawnPos;
    public Vector2 maxSpawnPos;

    Vector3 randomPos;
    Vector3 vectorToPlayer;
    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > SpawnCycle)
        {

            do
            {
                randomPos = new Vector3(Random.Range(minSpawnPos.x, maxSpawnPos.x), Random.Range(minSpawnPos.y, maxSpawnPos.y), 0);
                vectorToPlayer = player.transform.position - randomPos;
            }
            while (vectorToPlayer.magnitude < 1);

            Instantiate<GameObject>(enemy, randomPos, Quaternion.Euler(0, 0, Mathf.Atan2(-vectorToPlayer.x, vectorToPlayer.y) * Mathf.Rad2Deg));
            timer = 0;
        }

    }
    public void OnGameOver()
    {
        gameObject.SetActive(false);
    }
}
