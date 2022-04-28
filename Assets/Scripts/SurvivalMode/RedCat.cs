using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCat : MonoBehaviour
{
    public float interactiveZone;
    [SerializeField] PlayerController playerController;
    public float buffTime = 0.5f;
    public bool buffActive = false;
    [SerializeField] SurvivalMode survivalMode;

    public int count;
    public float distance;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        buffActive = false;
        count = 0;

        survivalMode = FindObjectOfType<SurvivalMode>();
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(playerController.hero.position, transform.position);
        if (distance <= interactiveZone)
        {
            Buff();
        }

        if (buffActive == true && buffTime > 0)
        {
            buffTime -= Time.fixedDeltaTime;
            if (buffTime <= 0)
            {
                playerController.speed -= 1f;
                buffActive = false;
                Destroy(gameObject);
                count = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, interactiveZone);
    }

    public void Buff()
    {
        if (count == 0)
        {
            playerController = FindObjectOfType<PlayerController>();
            playerController.speed += 1f;
            playerController.GetComponent<PlayerStat>().TakeDamage(-5f);
            count = 1;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            survivalMode.maxScore += survivalMode.pointsForEnergy;
            survivalMode.energyCount++;
        }
        buffActive = true;
    }
}
