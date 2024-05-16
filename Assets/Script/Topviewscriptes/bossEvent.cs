using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEvent : MonoBehaviour
{
    int randAtk;
    public float maxHealth, minHealth, health, dropItem, atk, attackCool;
    private Player player;
    private Rigidbody2D rb;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = (int)Random.Range(minHealth, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && player == null)
        {
            player = col.GetComponent<Player>();
            rb = player.GetComponent<Rigidbody2D>();
            StartCoroutine(AttackPlayer(col));
        }
        else
        {
            StartCoroutine(AttackPlayer(col));
        }
    }

    private IEnumerator AttackPlayer(Collider2D col)
    {
        yield return new WaitForSeconds(attackCool);

        while (player.health > 0 && health > 0) // ���� ü���� 0���� Ŭ ������ �ݺ�
        {
            randAtk = Random.Range(0, 10);

            animator.SetBool("atk2", true);

            if(randAtk > 5) // ��ġ�� ���� �߰����� ����
            {
                break;
            }

            yield return new WaitForSeconds(attackCool);
        }
        
    }

    public void Attack()  //�ִϸ��̼ǿ� ���� ������ ������Ű�� ���� �Լ�
    {
        if (rb != null && randAtk > 5)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        player.health -= atk;

        if (player.health <= 0)                          // �÷��̾ ���������� �ݺ�
        {
            player.bFadeCorutine = false;               // �׾����� while�� Ż��
        }
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
