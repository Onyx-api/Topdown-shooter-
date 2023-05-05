using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletspeed;
    GameObject target;
    public float health;
    private Rigidbody2D rb;
    GameObject bullet;
    private float cooldowntimer;
    //public GameObject player;

    void Start()
    {
        
           target=GameObject.FindWithTag("Player");
           bullet=GameObject.FindWithTag("enemy bullet");
    }

    // Update is called once per frame
    void Update()
    {
     Shoot();
    transform.right= transform.position-target.transform.position;
   
     if(health<=0){
        Destroy(gameObject);
        }
    
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("player bullet")){
            if(target.GetComponent<Player>().sp==true){health -= 10000000;}
            else {health -= 10f;}

        Destroy(col.gameObject);

        }


    }
    void Shoot() {
        cooldowntimer -= Time.deltaTime;
        if(cooldowntimer > 0 )return;
        cooldowntimer = 0.5f;
        GameObject firedBullet = Instantiate(bullet,transform.position,transform.rotation);
    
        firedBullet.GetComponent<Rigidbody2D>().AddForce(transform.right*15*-1,ForceMode2D.Impulse);
        
       
    }
 
}
