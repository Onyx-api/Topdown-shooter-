using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    GameObject target;
    public float health;
    private Rigidbody2D rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     float step = speed*Time.deltaTime;
     transform.position = Vector2.MoveTowards(transform.position, target.transform.position,step);
     if(health<=0){
        Destroy(gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("player bullet")){
            if(target.GetComponent<Player>().sp==true){health -= 10000000;}
            else {health -= 10f;}


        }


    }
}
