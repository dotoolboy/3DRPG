using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    private Transform cameraLookPoint;
    private GameObject enemyInstance;
    public void SpawnPlayer()
    {
        Vector3 playerPosition = new(-2.8f, 4.7f, 3.2f);
        GameObject player = Main.Resource.InstantiatePrefab("Player", null, true);

        if (player != null)
        {
            player.transform.position = playerPosition; // �÷��̾� ��ġ ����

            // CameraLookPoint ã��
            cameraLookPoint = player.transform.Find("CameraLookPoint");

            if (cameraLookPoint == null)
            {
                Debug.LogWarning("CameraLookPoint�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("�÷��̾ ��ȯ�� �� �����ϴ�.");
        }

    }

    public void SetupVirtualCamera()
    {
        Cinemachine.CinemachineVirtualCamera virtualCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();

        // LookAt �� Follow �Ӽ� ����
        if (virtualCamera != null && cameraLookPoint != null)
        {
            virtualCamera.LookAt = cameraLookPoint;
            virtualCamera.Follow = cameraLookPoint;
        }
        else
        {
            Debug.LogWarning("Virtual Camera �Ǵ� CameraLookPoint�� ã�� �� �����ϴ�.");
        }
    }

    public void SpawnEnemy(Vector3 ememyPosition)
    {
        //Vector3 ememyPosition = new Vector3(7.7f, 4.7f, 15f);
        GameObject enemy = Main.Resource.InstantiatePrefab("Enemy", null, true);

        if (enemy != null)
        {
            enemy.transform.position = ememyPosition; // �÷��̾� ��ġ ����

            GameObject uiEnemy = Main.Resource.InstantiatePrefab("UI_Enemy", null, true);
            if (uiEnemy != null)
            {
                // UI_Enemy�� Enemy�� �Ӹ� ��ġ�� ��ġ
                uiEnemy.transform.SetParent(enemy.transform, false);

                // UI_Enemy�� ���� �������� �����Ͽ� �Ӹ� ���� ��ġ�ϵ��� ��
                Vector3 offset = new Vector3(0f, 2f, 0f); // ���÷� ������ ������ ��
                uiEnemy.transform.localPosition = offset;
            }
        }
    }
}
