using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    private Transform cameraLookPoint;
    public void SpawnPlayer()
    {
        Vector3 playerPosition = new Vector3(-2.8f, 4.7f, 2.7f);
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

    public void SpawnEnemy()
    {
        Vector3 ememyPosition = new Vector3(7.7f, 4.7f, 15f);
        GameObject ememy = Main.Resource.InstantiatePrefab("Enemy", null, true);

        if (ememy != null)
        {
            ememy.transform.position = ememyPosition; // �÷��̾� ��ġ ����
        }
        else
        {
            Debug.LogError("�÷��̾ ��ȯ�� �� �����ϴ�.");
        }
    }
}
