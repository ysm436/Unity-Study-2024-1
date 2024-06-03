using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int speed;
    int life = 3;
    Vector3 directionVector;
    Animator anim;
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    private void Update()
    {
        directionVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += directionVector * Time.deltaTime * speed;
    }
    public void Damage()
    {//플레이어가 적에게 닿았을 때
        this.anim.SetTrigger("Ouch");//피격 트리거
        this.life -= 1;//생명 1개 감소
        GameObject x = GameObject.Find("EnemyGenerator");
        x.GetComponent<EnemyGenerator>().LifeUI(this.life);//줄어든 생명을 UI에 반영한다.
        if (this.life<=0)
        {//생명을 모두 다 썼을 경우 죽는다.
            Die();
        }
    }
    void Die()
    {//플레이어가 죽을 때
        GameObject x = GameObject.Find("EnemyGenerator");
        x.GetComponent<EnemyGenerator>().CheckGameOver();//게임을 종료한다.
        Destroy(gameObject);//플레이어 역시 파괴한다.
    }
}
