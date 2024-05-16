using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Tilemaps;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public float maxHealth, minHealth, health, dropItem, atk, attackCool;
    public Animator animator;
    private GameObject statuseObj;
    private Player player;

    //public MonoBehaviour ShadowScrpit;  //죽을때 그림자 없애기 위한 코드

    // Start is called before the first frame update
    void Start()
    {
        statuseObj = GameObject.Find("Statuse");
        health = (int)Random.Range(minHealth + statuseObj.GetComponent<Statuse>().floor, maxHealth + statuseObj.GetComponent<Statuse>().floor);     // 몬스터 체력을 minHealth + floor ~ maxHealth + floor 로 지정
        atk = (int)Random.Range(atk + statuseObj.GetComponent<Statuse>().floor, atk + 1 + statuseObj.GetComponent<Statuse>().floor);                // 몬스터 공격력을 atk + floor ~ +1 로 지정
    }

    public void deadEvent()
    {
        animator.SetBool("die", true);
        animator.SetBool("attack", false);
        statuseObj.GetComponent<Statuse>().coin += statuseObj.GetComponent<Statuse>().floor;    // 층 만큼 코인 상승
    }

    private void OnTriggerEnter2D(Collider2D col)   // 캐릭터랑 부딪히면 작동
    {
        if(col.CompareTag("Player"))
        {
            player = col.GetComponent<Player>();    // 플레이어정보를 저장
            StartCoroutine(AttackPlayer(col));      // AttackPlayer함수 작동
        }
    }

    private IEnumerator AttackPlayer(Collider2D col)        // 적이 player를 떄리는 루틴
    {
        yield return new WaitForSeconds(attackCool/2);      // 돌진과 동시에 공격 데미지가 동시에 들어가는 현상 방지
        while (player.health > 0 && health > 0)             // 적의 체력이 0보다 클 때까지 반복
        {
            animator.SetBool("attack", true);

            yield return new WaitForSeconds(0.5f);

            player.health -= atk;                           // 적 공격력만큼 플레이어 데미지
            FloatingText.Instance.ShowFloatingText(player.transform, -0.2f, 0.8f, atk.ToString(), new Color(1f, 0f, 0f));      //플로팅텍스트

            if(player.health <= 0)                          // 플레이어가 죽을때까지 반복
            {
                statuseObj.GetComponent<Statuse>().floor--; // 플레이어가 죽으면 층 하락
                player.bFadeCorutine = false;               // 죽었으니 while문 탈출
            }

            yield return new WaitForSeconds(attackCool);    // 공격 빈도
        }
    }

    public void OffDieAnimation()
    {
        animator.SetBool("die", false);
        Destroy(this.gameObject);
    }

    public void OffAttackAnimation()
    {
        animator.SetBool("attack", false);          //애니메이터 쪽에 지정되어있음
    }
}