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

        while (player.health > 0 && health > 0) // 적의 체력이 0보다 클 때까지 반복
        {
            randAtk = Random.Range(0, 10);

            animator.SetBool("atk2", true);

            if(randAtk > 5) // 밀치기 이후 추가공격 방지
            {
                break;
            }

            yield return new WaitForSeconds(attackCool);
        }
        
    }

    public void Attack()  //애니메이션에 도중 공격을 성공시키기 위한 함수
    {
        if (rb != null && randAtk > 5)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        player.health -= atk;

        if (player.health <= 0)                          // 플레이어가 죽을때까지 반복
        {
            player.bFadeCorutine = false;               // 죽었으니 while문 탈출
        }
    }

    public void AnimationOffAtk()       //애니메이션 끝날때 호출
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

    public void DestroyEnemy()      //ded애니메이션 끝날때 호출
    {
        animator.SetBool("ded", false);
        Destroy(this.gameObject);
    }
}
