using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public bool appearing;

    public Vector2 minAlivePos;
    public Vector2 maxAlivePos;

    private void Start()
    {
        appearing = true;
    }
    private void Update()
    {
        if (!appearing)
        {
            transform.position += transform.rotation * Vector2.up * Time.deltaTime * speed;

            if (transform.position.x < minAlivePos.x || transform.position.y < minAlivePos.y ||
                transform.position.x > maxAlivePos.x || transform.position.y > maxAlivePos.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
