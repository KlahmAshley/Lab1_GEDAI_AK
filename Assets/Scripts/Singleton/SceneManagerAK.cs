using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerAK : MonoBehaviour
{

    private static SceneManagerAK _Instance;

    public static SceneManagerAK Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<SceneManagerAK>();

                if (_Instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SceneManagerAK).Name;
                    _Instance = obj.AddComponent<SceneManagerAK>();
                }
            }

            return _Instance;
        }
    }
    public virtual void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void CheckAndLoadScene()
    {
        if (SceneManager.GetActiveScene().name == ("SampleScene"))
        {
            SceneManager.LoadScene("Level2");

        }
        else if (SceneManager.GetActiveScene().name == ("Level2"))
        {
            SceneManager.LoadScene("Level3");

        }
        else if (SceneManager.GetActiveScene().name == ("Level3"))
        {
            SceneManager.LoadScene("EndScene");
        }


    }
   

}
