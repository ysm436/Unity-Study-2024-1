

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int speed;
    Vector3 directionVector;

    public Action OnGameover;

    private void Awake()
    {
        OnGameover += PlayerGameover;
    }

    private void Update()
    {
        directionVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += directionVector * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            OnGameover();
        }
    }

    void PlayerGameover()
    {
        gameObject.SetActive(false);
    }
}
