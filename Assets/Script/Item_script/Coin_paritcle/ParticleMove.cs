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

    //---코인 폭팔
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
        float moveSpeed = 15f; // 파티클 이동 속도를 조절하는 변수

        while (elapsedTime < moveTime)
        {
            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 directionToPlayer = (player.position - particlesArray[i].position).normalized;
                float distanceToPlayer = Vector3.Distance(player.position, particlesArray[i].position);

                if (distanceToPlayer > 0.1f)
                {
                    particlesArray[i].position += directionToPlayer * moveSpeed * Time.deltaTime; // 이동 속도 조절
                }
                else
                {
                    if (particlesArray[i].remainingLifetime > 0f) // 이미 0으로 설정되지 않은 파티클인지 확인
                    {
                        particlesArray[i].remainingLifetime = 0f; // 파티클을 사라지게 함

                        //추가 파티클 생성
                        GameObject particleInstance = Instantiate(particlePrefab, player.position, Quaternion.identity);
                        ParticleSystem.EmissionModule emissionModule = particleInstance.GetComponent<ParticleSystem>().emission;
                        // 5초 후 파티클 인스턴스 소멸
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