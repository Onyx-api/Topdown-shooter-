using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{       
    Transform player;
    public float offset = 2f;
   public float followspeed = 20f;
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x,player.position.y+offset, -20f);
        transform.position= Vector3.Slerp(transform.position,newPos,followspeed*Time.deltaTime);
    }
}
