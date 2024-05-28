using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int speed;
    int maxHp = 3;
    int hp;
    Vector3 directionVector;
    public GameObject bg_gameover;
    public TextMeshProUGUI text_playerHP;

    void Gameover()
    {
        Destroy(gameObject);
        bg_gameover.SetActive(true);
        GameObject.FindWithTag("EnemyGenerator").SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            Destroy(c.gameObject);
            hp--;
            text_playerHP.text = hp.ToString() + "/" + maxHp.ToString();
            if (hp == 0) Gameover();
        }
        if (c.gameObject.tag == "Item")
        {
            Destroy(c.gameObject);
            if (hp < maxHp) { hp++; text_playerHP.text = hp.ToString() + "/" + maxHp.ToString(); }
        }
    }

    private void Start()
    {
        hp = maxHp;
        bg_gameover.SetActive(false);
        text_playerHP.text = hp.ToString() + "/" + maxHp.ToString();
    }

    private void Update()
    {
        directionVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += directionVector * Time.deltaTime * speed;
    }

}
