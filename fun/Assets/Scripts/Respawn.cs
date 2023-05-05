using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Button respawn;
    // Start is called before the first frame update
    void Start()
    {
        
        respawn.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void ButtonClicked(){
        SceneManager.LoadScene(0);
    }
}
