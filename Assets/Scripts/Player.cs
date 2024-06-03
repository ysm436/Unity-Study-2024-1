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
    {//�÷��̾ ������ ����� ��
        this.anim.SetTrigger("Ouch");//�ǰ� Ʈ����
        this.life -= 1;//���� 1�� ����
        GameObject x = GameObject.Find("EnemyGenerator");
        x.GetComponent<EnemyGenerator>().LifeUI(this.life);//�پ�� ������ UI�� �ݿ��Ѵ�.
        if (this.life<=0)
        {//������ ��� �� ���� ��� �״´�.
            Die();
        }
    }
    void Die()
    {//�÷��̾ ���� ��
        GameObject x = GameObject.Find("EnemyGenerator");
        x.GetComponent<EnemyGenerator>().CheckGameOver();//������ �����Ѵ�.
        Destroy(gameObject);//�÷��̾� ���� �ı��Ѵ�.
    }
}
