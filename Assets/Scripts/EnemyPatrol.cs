using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public int positionOfPatrol;
   // public Transform point;
   
  //  bool moveingRight = true;
    bool chill = true;
    bool angry = false;
    bool goBack = false ;

    public  Transform player;

    public float stoppingDistance;



    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       // if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
      //  {
         //   chill = true;
            
       // }

        if (Vector2.Distance(transform.position,player.position) < stoppingDistance )
        {
            angry = true;
            goBack = false;
            chill = false;
        }
        
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            angry = false;
            goBack = true ;
           
        }

        if (chill == true)
        {
            Chill();
        }

        else if(angry == true)
            {
                Angry(); 
            } 

        else if (goBack == true)
            {
                GoBack(); 
            }
    }

    void Chill()

    {
       /* speed = 2;
        if ( transform.position.x > point.position.x + positionOfPatrol )
        {
            moveingRight = false ;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true ;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y );
            transform.localScale = new Vector2(-(float)0.72, (float)0.62);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2((float)0.72, (float)0.62);
        }
       */
    }

    void Angry()
    {
        if (player.position.x < transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.localScale = new Vector2( (float)0.72 , (float)0.62);
        }
        else if (player.position.x > transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(-(float)0.72, (float)0.62);
        }
    }

    void GoBack()
    {
       //  transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
      //  speed = 3;

    }
    }
