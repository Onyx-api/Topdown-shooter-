using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Button win;
    //public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
    
       win.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void ButtonClicked(){
        SP.sp=true;
        SceneManager.LoadScene(0);
        

    }
}
