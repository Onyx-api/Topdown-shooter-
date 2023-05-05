using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;
    public GameObject bullet;
    private Vector2 lookDir;
    private float aimAngle;
    public Transform firepoint;
    Vector2 moveDir;
       public float health; 
     public bool sp;
       public Sprite sprite;
       public GameObject enemy;
       
    private GameManger gm;
    
    // Start is called before the first frame update
    void Start()
    {
       //  cam = GameObject.Find("MainCamera").GetComponent<Camera>();

        sp=SP.sp;
        rb = GetComponent<Rigidbody2D>();
       
      gm = GameManger.instance;



       DontDestroyOnLoad(gameObject);
        if (sp==true ){
          
            for (int i = 0; i < 3; i++)
            {
                Vector2 pos = new Vector2(Random.Range(-26f,31f),Random.Range(-30f,28f));
               GameObject newEnemy = Instantiate(enemy,pos,enemy.transform.rotation);
               //newEnemy.target = gameObject.transform;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(cam == null) {
        //     cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        // }

        Debug.Log(sp);
        lookDir = gm.cam.ScreenToWorldPoint(Input.mousePosition);
      
       // firepoint.rotation = Quaternion.Euler(0f, 0f, lookAngle);
      // transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
       float moveX = Input.GetAxisRaw("Horizontal");
       float moveY = Input.GetAxisRaw("Vertical");
       moveDir = new Vector2(moveX,moveY).normalized;

    
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }
        if(health<=0){
        Destroy(gameObject);
        SceneManager.LoadScene(1);

        }
        if(GameObject.FindGameObjectsWithTag("enemy").Length<=0 && GameObject.FindGameObjectsWithTag("enemy moving").Length<=0)  {
            SceneManager.LoadScene(2);
        }
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(moveDir.x*speed,moveDir.y*speed);
        Vector2 aimDir = lookDir - rb.position;
        aimAngle = Mathf.Atan2(aimDir.y, aimDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = aimAngle;
    }

    void Shoot() { 
        if(sp==true){
            bullet.GetComponent<SpriteRenderer>().sprite=sprite;
            bullet.GetComponent<AudioSource>().Play();
        }
        GameObject firedBullet = Instantiate(bullet,firepoint.position,firepoint.rotation);
//firedBullet.transform.position = firepoint.position;
        //firedBullet.transform.rotation = Quaternion.Euler(0,0,lookDir);
        firedBullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up*15f,ForceMode2D.Impulse);
        /////////firedBullet.GetComponent<Rigidbody2D>().velocity = firepoint.right*15f;
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawRay(firepoint.position,firepoint.right);
    }
      void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("enemy bullet")){
            health -= 10f;
        Destroy(col.gameObject);
        }

        }
        void OnCollisionEnter2D(Collision2D col){
             if(col.gameObject.CompareTag("enemy moving")){
            health -= 10f;
        }
        }
       
}
