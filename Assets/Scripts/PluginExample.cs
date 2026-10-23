using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyPlugin.ID = 10;
        Debug.Log(MyPlugin.ID);


    }


}
