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
            player.transform.position = playerPosition; // 플레이어 위치 설정

            // CameraLookPoint 찾기
            cameraLookPoint = player.transform.Find("CameraLookPoint");

            if (cameraLookPoint == null)
            {
                Debug.LogWarning("CameraLookPoint를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("플레이어를 소환할 수 없습니다.");
        }

    }

    public void SetupVirtualCamera()
    {
        Cinemachine.CinemachineVirtualCamera virtualCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();

        // LookAt 및 Follow 속성 설정
        if (virtualCamera != null && cameraLookPoint != null)
        {
            virtualCamera.LookAt = cameraLookPoint;
            virtualCamera.Follow = cameraLookPoint;
        }
        else
        {
            Debug.LogWarning("Virtual Camera 또는 CameraLookPoint를 찾을 수 없습니다.");
        }
    }

    public void SpawnEnemy()
    {
        Vector3 ememyPosition = new Vector3(7.7f, 4.7f, 15f);
        GameObject ememy = Main.Resource.InstantiatePrefab("Enemy", null, true);

        if (ememy != null)
        {
            ememy.transform.position = ememyPosition; // 플레이어 위치 설정
        }
        else
        {
            Debug.LogError("플레이어를 소환할 수 없습니다.");
        }
    }
}
