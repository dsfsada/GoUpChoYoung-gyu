using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    public Transform target; // �÷��̾ ����Ű�� ����
    public Transform loopWall; // �÷��̾ �ε����� ���ư��� ��
    public Vector3 offset; // �÷��̾�� ī�޶� ������ �Ÿ��� �����ϴ� ����

    public float smoothSpeed = 0.125f; // ī�޶��� �ε巯�� �̵��� �����ϴ� ����
    public float arrivalThreshold = 0.1f; // �÷��̾ �������� ���ֵǴ� �Ӱ谪

    private bool shouldFollow = false; // ī�޶� ���󰡾� �ϴ��� ���θ� ��Ÿ���� ����

    void Update()
    {
        // �÷��̾ ��ǥ ������ �����ߴ��� Ȯ��
        if (!shouldFollow && target.position.x >= 2.55f && target.position.x <= loopWall.position.x - 3.5f) // target.position.x�� �÷��̾��� x ��ǥ�� ��Ÿ��
        {
            shouldFollow = true; // �÷��̾ ��ǥ ������ �������� �� ī�޶� ���󰡵��� ����
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
            Vector3 desiredPosition = target.position + offset; // �÷��̾�� offset�� ���� ī�޶��� ���ϴ� ��ġ�� ���
            transform.position = desiredPosition;
        }
    }

}
