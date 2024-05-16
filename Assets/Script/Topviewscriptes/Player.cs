//  기본위치 0 0 0
//  보스위치 14, 0, 0

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 myVector;

    public Rigidbody2D playerRigidbody;
    SpriteRenderer playerRenderer; // 플레이어의 SpriteRenderer 컴포넌트

    public float pSpeed, maxSpeed, atk, attackCool, health, maxHealth, criAtk, criRate;  //atk, maxHealth, criAtk, criRate 연동시켜
    public Vector2 vel;
    private enemyState enemy;
    private bossEvent boss;
    private bool bAtk, bBossEvent;
    public bool bFadeCorutine;
    private EnemySpawn enemySpawner;
    private GameObject respawnObject;

    public Animator animator;       //애니메이션 담당

    private FadeManger fadeManger;  //화면의 끝의 도달 or 플레이어 사망시 화면의 자연스로운 넘김을 위한 fade효과 적용 

    // Start is called before the first frame update
    void Start()
    {
        bFadeCorutine = true;
        bAtk = true;
        myVector = new Vector2(1.0f, 0.0f);
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.position = new Vector3(-1.0f, 0.0f, 0.0f); 
        playerRenderer = GetComponent<SpriteRenderer>(); // 플레이어의 SpriteRenderer 컴포넌트 가져오기
        fadeManger = FindObjectOfType<FadeManger>();
        respawnObject = GameObject.FindWithTag("Respawn");
        enemySpawner = respawnObject.GetComponent<EnemySpawn>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vel = playerRigidbody.velocity;     // 캐릭터의 속도값 저장 * 컴파일용임 *

        if(!bFadeCorutine)
        {
            _ = StartCoroutine(FadeCoroutine());
        }

        if (bAtk)
        {
            playerRigidbody.AddForce(myVector * pSpeed);
        }

        if (vel.x > maxSpeed)
        {
            playerRigidbody.velocity = new Vector2(maxSpeed, 0.0f);   // 캐릭터가 최대속도 이상으로 빨라지지 않게 조정
        }

        //---------------------------------------------
        animator.SetFloat("run", vel.x);
    }

    IEnumerator FadeCoroutine() //화면 전화 효과 부여하는 코루틴
    {
        fadeManger.FadeOut();                   //페이드메니저 스크립트의 FadeOut 함수 가져옴
        yield return new WaitForSeconds(0.2f);
        PlayerMoveStartPoint();
        yield return new WaitForSeconds(0.2f);
        fadeManger.FadeIn();
        bFadeCorutine = true;                   //페이드 종료
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !bBossEvent)    // 적과 부딪혔을 떄
        {
            enemy = col.GetComponent<enemyState>();
            enemy.health -= atk;
            FloatingText.Instance.ShowFloatingText(enemy.transform, 0f, 0.5f, atk.ToString(), new Color(1f, 1f, 1f));      //플로팅텍스트

            if (enemy.health > 0) // 적이 한번에 안잡혔을 때
            {
                animator.SetBool("crash", true);
                bAtk = false;
                playerRigidbody.velocity = new Vector2(0, 0);
                StartCoroutine(AttackMob(col)); // 적의 체력이 0이 될 때까지 반복적으로 공격 실행
            }
            else
            {
                animator.SetBool("ign", true);
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 250f));  // 충돌한 개체의 rigidbody에 접근하여 vector값을 추가함
                col.GetComponent<Rigidbody2D>().AddTorque(100);                     // 충돌한 개체의 rigidbody에 접근하여 rotation값을 추가함
                Destroy(col.transform.GetChild(0).gameObject);                      // 충돌한 개체의 첫번째 상속개체를 파괴함
                enemy.deadEvent();
            }
        }
        else if (col.CompareTag("Enemy") && bBossEvent)    // 적과 부딪혔을 떄
        {
            boss = col.GetComponent<bossEvent>();
            boss.health -= atk;
            FloatingText.Instance.ShowFloatingText(boss.transform, 0f, 1.5f, atk.ToString(), new Color(1f, 1f, 1f));      //플로팅텍스트

            if (boss.health > 0) // 적이 한번에 안잡혔을 때
            {
                bAtk = false;
                playerRigidbody.velocity = new Vector2(0, 0);
                StartCoroutine(AttackBoss(col)); // 적의 체력이 0이 될 때까지 반복적으로 공격 실행
            }
            else
            {
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 250f));  // 충돌한 개체의 rigidbody에 접근하여 vector값을 추가함
                col.GetComponent<Rigidbody2D>().AddTorque(100);                     // 충돌한 개체의 rigidbody에 접근하여 rotation값을 추가함
                boss.DeadEvent();
            }
        }

        if (col.CompareTag("Loop"))     // Loop기준이 되는 벽과 부딛혔을때
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().floor++;
            bFadeCorutine = false;              //코루틴 실행
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        bAtk = true;
    }

    private IEnumerator AttackMob(Collider2D col)
    {
        yield return new WaitForSeconds(attackCool);
        while (enemy.health > 0 && !bAtk) // 적의 체력이 0보다 클 때 반복
        {
            enemy.health -= atk;
            if (enemy.health <= 0)
            {
                 enemy.deadEvent();
            }
            if(enemy != null)
            {
                FloatingText.Instance.ShowFloatingText(enemy.transform, 0f, 0.5f, atk.ToString(), new Color(1f, 1f, 1f));      //플로팅텍스트
            }
            animator.SetBool("atk", true);
            yield return new WaitForSeconds(attackCool);
        }
    }

    private IEnumerator AttackBoss(Collider2D col)
    {
        yield return new WaitForSeconds(attackCool);
        while (boss.health > 0 && !bAtk) // 적의 체력이 0보다 클 때 반복
        {
            boss.health -= atk;
            if (boss.health <= 0)
            {
                boss.DeadEvent();
            }
            if (boss != null)
            {
                FloatingText.Instance.ShowFloatingText(boss.transform, 0f, 1.5f, atk.ToString(), new Color(1f, 1f, 1f));      //플로팅텍스트
            }
            animator.SetBool("atk", true);
            yield return new WaitForSeconds(attackCool);
        }
    }

    private void OnAtkFalseAnimation()  //공격 애니메이션 종료
    {
        animator.SetBool("atk", false);
        animator.SetBool("crash", false);
        animator.SetBool("ign", false);
    }

    public void PlayerMoveStartPoint(bool checkBoss = false, int bossNumber = 0)
    {
        // "Enemy" 태그를 가진 모든 GameObject를 제거
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in objectsWithTag)
        {                                                                                                     
            Destroy(obj);                                                                                     
        }                                                                                                                          
                                                                                                                                   
        // "Respawn" 태그를 가진 GameObject를 찾아서 변수에 할당                                                                   
                                                                 
        if (respawnObject != null)                                                                                                 
        {
            bBossEvent = false;     // bossEvent 만족 조건 끄기
            // 캐릭터 위치를 시작 위치로 이동                                                                                      
            playerRigidbody.position = new Vector3(-1.0f, -0.0f, 0.0f);                                                            
                                                                                                         
            // health를 최대 체력으로 초기화                                                                                       
            health = maxHealth;                                                                                                    
                                                                                                                                   
            // stageText 변경                                                                                                      
            GameObject.Find("Ui_text").GetComponent<EditText>().updateFloor();                                                  
                                                                                                                                          
            // "Respawn" 태그를 가진 GameObject에서 newenemySpawn 컴포넌트를 가져와서 적 스폰               
                     
            
            // 조건에 맞게 선택해서 실행
            if (enemySpawner != null && !checkBoss) // checkBoss가 꺼져있으면 일반 몹 생성                                                                                      
            {
                enemySpawner.setEnemySpawn();
            }
            else if(enemySpawner != null && checkBoss)  // checkBoss가 켜져있으면 보스 몹 생성
            {
                if(bossNumber == 0)
                {
                    enemySpawner.setBossGolemSpawn();
                    bBossEvent = true;      // bossEvent 만족 조건 끄기
                }else if(bossNumber == 1)
                {
                    enemySpawner.setBossDeerSpawn();
                    bBossEvent = true;      // bossEvent 만족 조건 끄기
                }
                
            }
            else if(enemySpawner == null)
            {
                Debug.LogError("enemySpawn 컴포넌트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Respawn 태그를 가진 GameObject를 찾을 수 없습니다.");
        }
    }
}
