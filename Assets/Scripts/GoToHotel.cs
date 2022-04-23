using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToHotel : MonoBehaviour
{
    public Transform hotelPoint;
    public Image buttonToHotel;

    public int goToHotelFlag;
    public bool hotelSceneEnable = false;

    public CircleCollider2D heroCircleCollider;

    public PlayerController player;
    public Animator anim;

    public Vector2 TriggerPoint = new Vector2();

    private void Start()
    {
        goToHotelFlag = 0;
        hotelSceneEnable = false;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(player.hero.transform.position, TriggerPoint) <= 3.3f && player.moveToHotelFlag == 1 && hotelSceneEnable == true)
        {
            buttonToHotel.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                goToHotelFlag = 1;
            }
                if (goToHotelFlag == 1)
                {
                    heroCircleCollider.enabled = false;

                    if ((player.character.position.x > TriggerPoint.x && player.facingRight == true) || (player.character.position.x < TriggerPoint.x && player.facingRight == false))
                {
                    player.Flip();
                }
                    anim.Play("HeroMovement");
                    player.hero.transform.position = Vector2.MoveTowards(player.hero.transform.position, hotelPoint.position, player.speed * Time.deltaTime);

                Vector3 defaultScale = player.character.transform.localScale;
                Vector3 scaler = player.character.transform.localScale;
                if (scaler.y > 0.215f)
                    {
                        scaler.y -= Time.fixedDeltaTime;
                        if (scaler.x >= -0.215f)
                        {
                            scaler.x -= Time.fixedDeltaTime;
                        }
                        else if (scaler.x <= 0.215f)
                        {
                            scaler.x += Time.fixedDeltaTime;
                        }
                        player.character.transform.localScale = scaler;
                    }

                    //player.character.LookAt(hotelPoint);

                    if (Vector2.Distance(player.character.position, hotelPoint.position) < 0.21f)
                    {
                        heroCircleCollider.enabled = true;
                        SceneManager.LoadScene(2);
                        goToHotelFlag = 0;
                        player.character.transform.localScale = defaultScale;
                    }
                }
            }
        else
        {
            buttonToHotel.gameObject.SetActive(false);
        }
        }
    }