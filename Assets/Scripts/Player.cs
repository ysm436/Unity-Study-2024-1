

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int speed;
    public int max_hp = 3;
    public int hp = 3;

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
            hp -= 1;
            if (hp <= 0)
                OnGameover();            
            

        if (other.gameObject.tag == "Item")
            if (hp < max_hp)
                hp += 1;

        Destroy(other.gameObject);
    }

    void PlayerGameover()
    {
        gameObject.SetActive(false);
    }
}
