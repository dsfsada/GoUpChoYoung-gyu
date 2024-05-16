using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//에너미 오브젝트의 스크립트 부여되어있음
public class Pa : MonoBehaviour
{
    // 파티클 프리팹에 대한 참조. Inspector에서 할당할 수 있습니다.
    public GameObject particlePrefab;

    void Die()
    {
        float coinCount = GameObject.Find("Statuse").GetComponent<Statuse>().floor;
        if(coinCount > 5 ) { coinCount = 5; }
        //나오는 코인의 개수

        // 파티클 프리팹 인스턴스화
        GameObject particleInstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // 파티클 시스템의 Emission 모듈 가져오기
        ParticleSystem.EmissionModule emissionModule = particleInstance.GetComponent<ParticleSystem>().emission;

        // 모든 기존 Burst를 제거
        emissionModule.burstCount = 0;

        // 새 Burst 추가, coinCount개의 파티클 발생
        ParticleSystem.Burst burst = new ParticleSystem.Burst(0.0f, coinCount);
        emissionModule.SetBursts(new ParticleSystem.Burst[] { burst });

        // 5초 후 파티클 인스턴스 소멸
        Destroy(particleInstance, 4f);
    }
}
