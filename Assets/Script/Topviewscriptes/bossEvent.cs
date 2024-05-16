using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEvent : MonoBehaviour
{
    public float maxHealth, minHealth, health, dropItem, atk, attackCool;
    private Player player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = (int)Random.Range(minHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            DeadEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.GetComponent<Player>();
            if (player.health > 0)
            {
                StartCoroutine(AttackPlayer(col));
            }
        }
    }

    private IEnumerator AttackPlayer(Collider2D col)
    {
        while (player.health > 0) // ���� ü���� 0���� Ŭ ������ �ݺ�
        {
            yield return new WaitForSeconds(attackCool);

            animator.SetBool("atk2", true);
            //Attack(col);

            break;
        }
    }
    
    public void Attack()  //�ִϸ��̼ǿ� ���� ������ ������Ű�� ���� �Լ�
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        player.health -= atk; 
    }

    public void AnimationOffAtk()       //�ִϸ��̼� ������ ȣ��
    {       
        //animator.SetBool("atk", false);
        animator.SetBool("atk2", false);
    }

    public void DeadEvent()
    {
        animator.SetBool("ded", true);
        //animator.SetBool("atk", false);
        animator.SetBool("atk2", false);
    }

    public void DestroyEnemy()      //ded�ִϸ��̼� ������ ȣ��
    {
        animator.SetBool("ded", false);
        Destroy(this.gameObject);
    }
}
