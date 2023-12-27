using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private void Start()
    {

        Main.Resource.Initialize();

        GameObject.Instantiate(Main.Resource.GetObject("Map1"));
        Main.Object.SpawnPlayer();
        Main.Object.SetupVirtualCamera();
        Main.Object.SpawnEnemy();

        
    }
}
