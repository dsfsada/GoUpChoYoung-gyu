using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ʹ� ������Ʈ�� ��ũ��Ʈ �ο��Ǿ�����
public class Pa : MonoBehaviour
{
    // ��ƼŬ �����տ� ���� ����. Inspector���� �Ҵ��� �� �ֽ��ϴ�.
    public GameObject particlePrefab;

    void Die()
    {
        float coinCount = GameObject.Find("Statuse").GetComponent<Statuse>().floor;
        if(coinCount > 5 ) { coinCount = 5; }
        //������ ������ ����

        // ��ƼŬ ������ �ν��Ͻ�ȭ
        GameObject particleInstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // ��ƼŬ �ý����� Emission ��� ��������
        ParticleSystem.EmissionModule emissionModule = particleInstance.GetComponent<ParticleSystem>().emission;

        // ��� ���� Burst�� ����
        emissionModule.burstCount = 0;

        // �� Burst �߰�, coinCount���� ��ƼŬ �߻�
        ParticleSystem.Burst burst = new ParticleSystem.Burst(0.0f, coinCount);
        emissionModule.SetBursts(new ParticleSystem.Burst[] { burst });

        // 5�� �� ��ƼŬ �ν��Ͻ� �Ҹ�
        Destroy(particleInstance, 4f);
    }
}
