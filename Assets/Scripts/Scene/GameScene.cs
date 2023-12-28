using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    //임시로
    Vector3 spawnPosition = new Vector3(7.7f, 4.7f, 15f);
    Vector3 spawnPosition2 = new Vector3(-5.7f, 4.7f, 30f);
    Vector3 spawnPosition3 = new Vector3(-3.7f, 4.7f, 30f);
    Vector3 spawnPosition4 = new Vector3(-1.7f, 4.7f, 50f);
    Vector3 spawnPosition5 = new Vector3(-2.6f, 4.7f, 58f);
    Vector3 spawnPosition6 = new Vector3(4.5f, 4.7f, 54f);


    private void Start()
    {
        Main.Clear();
        Main.Resource.Initialize();

        GameObject.Instantiate(Main.Resource.GetObject("Map1"));
        Main.Object.SpawnPlayer();
        Main.Object.SetupVirtualCamera();
        Main.Resource.InstantiatePrefab("UI_Player");

        //몬스터 소환
        Main.Object.SpawnEnemy(spawnPosition);
        Main.Object.SpawnEnemy(spawnPosition2);
        Main.Object.SpawnEnemy(spawnPosition3);
        Main.Object.SpawnEnemy(spawnPosition4);
        Main.Object.SpawnEnemy(spawnPosition5);
        Main.Object.SpawnEnemy(spawnPosition6);


    }
}
