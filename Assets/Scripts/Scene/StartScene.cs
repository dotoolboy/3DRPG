using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Start()
    {
        Main.Resource.Initialize();

        GameObject.Instantiate(Main.Resource.GetObject("UI_Scene_Start"));
    }


}
