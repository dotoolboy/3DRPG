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

    public void SpawnEnemy(Vector3 ememyPosition)
    {
        //Vector3 ememyPosition = new Vector3(7.7f, 4.7f, 15f);
        GameObject enemy = Main.Resource.InstantiatePrefab("Enemy", null, true);

        if (enemy != null)
        {
            enemy.transform.position = ememyPosition; // 플레이어 위치 설정

            GameObject uiEnemy = Main.Resource.InstantiatePrefab("UI_Enemy", null, true);
            if (uiEnemy != null)
            {
                // UI_Enemy를 Enemy의 머리 위치에 배치
                uiEnemy.transform.SetParent(enemy.transform, false);

                // UI_Enemy의 로컬 포지션을 조정하여 머리 위에 위치하도록 함
                Vector3 offset = new Vector3(0f, 2f, 0f); // 예시로 설정한 오프셋 값
                uiEnemy.transform.localPosition = offset;
            }
        }
    }
}
