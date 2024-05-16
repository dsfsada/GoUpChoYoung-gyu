using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    public ParticleSystem customParticleSystem;
    public Transform player;
    public float delay = 2f;
    public float moveTime = 3f;

    private ParticleSystem.Particle[] particlesArray;

    //---���� ����
    public GameObject particlePrefab;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>().playerRigidbody.transform;
        StartCoroutine(MoveParticlesTowardsPlayer());
    }

    IEnumerator MoveParticlesTowardsPlayer()
    {
        yield return new WaitForSeconds(delay);

        particlesArray = new ParticleSystem.Particle[customParticleSystem.main.maxParticles];
        int numParticlesAlive = customParticleSystem.GetParticles(particlesArray);

        float elapsedTime = 0;
        float moveSpeed = 15f; // ��ƼŬ �̵� �ӵ��� �����ϴ� ����

        while (elapsedTime < moveTime)
        {
            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 directionToPlayer = (player.position - particlesArray[i].position).normalized;
                float distanceToPlayer = Vector3.Distance(player.position, particlesArray[i].position);

                if (distanceToPlayer > 0.1f)
                {
                    particlesArray[i].position += directionToPlayer * moveSpeed * Time.deltaTime; // �̵� �ӵ� ����
                }
                else
                {
                    if (particlesArray[i].remainingLifetime > 0f) // �̹� 0���� �������� ���� ��ƼŬ���� Ȯ��
                    {
                        particlesArray[i].remainingLifetime = 0f; // ��ƼŬ�� ������� ��

                        //�߰� ��ƼŬ ����
                        GameObject particleInstance = Instantiate(particlePrefab, player.position, Quaternion.identity);
                        ParticleSystem.EmissionModule emissionModule = particleInstance.GetComponent<ParticleSystem>().emission;
                        // 5�� �� ��ƼŬ �ν��Ͻ� �Ҹ�
                        Destroy(particleInstance, 1f);
                    }
                }
            }

            customParticleSystem.SetParticles(particlesArray, numParticlesAlive);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}