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
        while (player.health > 0) // 적의 체력이 0보다 클 때까지 반복
        {
            yield return new WaitForSeconds(attackCool);

            animator.SetBool("atk2", true);
            //Attack(col);

            break;
        }
    }
    
    public void Attack()  //애니메이션에 도중 공격을 성공시키기 위한 함수
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        player.health -= atk; 
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
