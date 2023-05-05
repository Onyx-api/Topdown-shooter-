using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject Player;
    public GameObject PlayerPrefab;
    Transform SpawnLocation;

 void Awake() {
    SpawnLocation = gameObject.transform;
   
   
   
    if(GameObject.FindGameObjectWithTag("Player") != null){
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = SpawnLocation.position;

    } else{
        Player = Instantiate(PlayerPrefab);
        Player.transform.position = SpawnLocation.position;
    }




 }
}
