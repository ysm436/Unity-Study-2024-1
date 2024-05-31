
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject player;
    [Space]
    public GameObject enemy;
    public TextMeshProUGUI life;
    public GameObject gameover;
    public float SpawnCycle;
    public Vector2 minSpawnPos;
    public Vector2 maxSpawnPos;
    bool GameOver = false;

    Vector3 randomPos;
    Vector3 vectorToPlayer;
    float timer = 0;

    private void Update()
    {
        if(this.GameOver==false)
        {//������ ������ ���� ��쿡�� �����Ѵ�.
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
    }
    public void LifeUI(int x)
    {//���� ���� �� �����ϱ�
        life.text = "Life: " + x + "/3";
    }
    public void CheckGameOver()
    {//������ ����Ǿ��� ��
        this.GameOver = true;
        this.gameover.SetActive(true);
    }
}
