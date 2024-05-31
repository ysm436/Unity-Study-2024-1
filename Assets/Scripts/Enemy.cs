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
    {//���� ���𰡿� �浹���� ��
        if(x.gameObject.CompareTag("Player"))
        {//�÷��̾�� �浹���� ���, �÷��̾�� ���ظ� ������ ���� �������.
            x.gameObject.GetComponent<Player>().Damage();
            Destroy(gameObject);
        }
    }
}
