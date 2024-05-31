using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public Vector2 minAlivePos;
    public Vector2 maxAlivePos;
    private void Update()
    {
        transform.position += transform.rotation * Vector2.up * Time.deltaTime * speed;

        if (transform.position.x < minAlivePos.x || transform.position.y < minAlivePos.y||
            transform.position.x > maxAlivePos.x || transform.position.y > maxAlivePos.y)
        {
            Destroy(gameObject);
        }

        
    }
    void OnTriggerEnter2D(Collider2D x)
    {//적이 무언가와 충돌했을 때
        if(x.gameObject.CompareTag("Player"))
        {//플레이어와 충돌했을 경우, 플레이어에게 피해를 입히고 적은 사라진다.
            x.gameObject.GetComponent<Player>().Damage();
            Destroy(gameObject);
        }
    }
}
