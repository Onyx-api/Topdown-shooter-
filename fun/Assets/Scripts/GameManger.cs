using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public Camera cam;
    private static GameManger _instance;
    public static GameManger instance{
     get  {
    if(_instance==null){
        Debug.LogError("Error");
    }
    return _instance;
     }
    }
    // Start is called before the first frame update
    void Awake()
    {
    _instance = this;
            
    }
    void Start(){
  //      cam = GameObject.Find("MainCamera").GetComponent<Camera>();
  DontDestroyOnLoad(cam);

    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
