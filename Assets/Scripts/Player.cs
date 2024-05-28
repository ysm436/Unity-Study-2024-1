

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int max_HP;
    [HideInInspector]
    public int cur_HP;
    public int speed;
    Vector3 directionVector;
    public GameSceneUIManager gameSceneUIManager;
    public UnityEvent GameOverEvent;

    private void Start()
    {
        cur_HP = max_HP;
        gameSceneUIManager.playerHPText = cur_HP + "/" + max_HP;

    }

    private void Update()
    {
        directionVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += directionVector * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                cur_HP--;
                if (cur_HP <= 0)
                    GameOverEvent.Invoke();
                break;

            case "Item":
                if (cur_HP < max_HP)
                    cur_HP++;
                break;
        }

        Destroy(other.gameObject);

        gameSceneUIManager.playerHPText = cur_HP + "/" + max_HP;

    }

    public void OnGameOver()
    {
        gameObject.SetActive(false);
    }

}
