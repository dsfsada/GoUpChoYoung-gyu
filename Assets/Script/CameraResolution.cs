using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    public Transform target; // 플레이어를 가리키는 변수
    public Transform loopWall; // 플레이어가 부딪히면 돌아가는 벽
    public Vector3 offset; // 플레이어와 카메라 사이의 거리를 제어하는 변수

    public float smoothSpeed = 0.125f; // 카메라의 부드러운 이동을 제어하는 변수
    public float arrivalThreshold = 0.1f; // 플레이어가 도착으로 간주되는 임계값

    private bool shouldFollow = false; // 카메라가 따라가야 하는지 여부를 나타내는 변수

    void Update()
    {
        // 플레이어가 목표 지점에 도달했는지 확인
        if (!shouldFollow && target.position.x >= 2.55f && target.position.x <= loopWall.position.x - 3.5f) // target.position.x는 플레이어의 x 좌표를 나타냄
        {
            shouldFollow = true; // 플레이어가 목표 지점에 도달했을 때 카메라가 따라가도록 설정
        }
        else
        {
            shouldFollow = false;
        }
        
        if(target.position.x <= -0.5)
        {
            transform.position = new Vector3(3, -2, -10);
        }

        if (shouldFollow)
        {
            Vector3 desiredPosition = target.position + offset; // 플레이어와 offset을 더해 카메라의 원하는 위치를 계산
            transform.position = desiredPosition;
        }
    }

}
