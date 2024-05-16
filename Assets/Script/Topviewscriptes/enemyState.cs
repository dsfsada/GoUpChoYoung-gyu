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

    //public MonoBehaviour ShadowScrpit;  //������ �׸��� ���ֱ� ���� �ڵ�

    // Start is called before the first frame update
    void Start()
    {
        statuseObj = GameObject.Find("Statuse");
        health = (int)Random.Range(minHealth + statuseObj.GetComponent<Statuse>().floor, maxHealth + statuseObj.GetComponent<Statuse>().floor);     // ���� ü���� minHealth + floor ~ maxHealth + floor �� ����
        atk = (int)Random.Range(atk + statuseObj.GetComponent<Statuse>().floor, atk + 1 + statuseObj.GetComponent<Statuse>().floor);                // ���� ���ݷ��� atk + floor ~ +1 �� ����
    }

    public void deadEvent()
    {
        animator.SetBool("die", true);
        animator.SetBool("attack", false);
        statuseObj.GetComponent<Statuse>().coin += statuseObj.GetComponent<Statuse>().floor;    // �� ��ŭ ���� ���
    }

    private void OnTriggerEnter2D(Collider2D col)   // ĳ���Ͷ� �ε����� �۵�
    {
        if(col.CompareTag("Player"))
        {
            player = col.GetComponent<Player>();    // �÷��̾������� ����
            StartCoroutine(AttackPlayer(col));      // AttackPlayer�Լ� �۵�
        }
    }

    private IEnumerator AttackPlayer(Collider2D col)        // ���� player�� ������ ��ƾ
    {
        yield return new WaitForSeconds(attackCool/2);      // ������ ���ÿ� ���� �������� ���ÿ� ���� ���� ����
        while (player.health > 0 && health > 0)             // ���� ü���� 0���� Ŭ ������ �ݺ�
        {
            animator.SetBool("attack", true);

            yield return new WaitForSeconds(0.5f);

            player.health -= atk;                           // �� ���ݷ¸�ŭ �÷��̾� ������
            FloatingText.Instance.ShowFloatingText(player.transform, -0.2f, 0.8f, atk.ToString(), new Color(1f, 0f, 0f));      //�÷����ؽ�Ʈ

            if(player.health <= 0)                          // �÷��̾ ���������� �ݺ�
            {
                statuseObj.GetComponent<Statuse>().floor--; // �÷��̾ ������ �� �϶�
                player.bFadeCorutine = false;               // �׾����� while�� Ż��
            }

            yield return new WaitForSeconds(attackCool);    // ���� ��
        }
    }

    public void OffDieAnimation()
    {
        animator.SetBool("die", false);
        Destroy(this.gameObject);
    }

    public void OffAttackAnimation()
    {
        animator.SetBool("attack", false);          //�ִϸ����� �ʿ� �����Ǿ�����
    }
}