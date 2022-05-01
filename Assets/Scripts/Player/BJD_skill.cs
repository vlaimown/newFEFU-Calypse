using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJD_skill : MonoBehaviour
{
    [SerializeField] float skill_range;
    [SerializeField] float max_alive_time;
    [SerializeField] float current_alive_time;

    [SerializeField] PlayerController playerController;

    [SerializeField] LayerMask enemyLayers;

    [SerializeField] List<Enemy> list;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        current_alive_time = max_alive_time;
        playerController.coolDownBJD.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (current_alive_time > 0)
        {
            current_alive_time -= Time.deltaTime;
            playerController.coolDownBJD.fillAmount = current_alive_time / max_alive_time;
        }
        if (current_alive_time <= 0)
        {
            foreach (Enemy enemy in list)
            {
                 enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                 enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            playerController.BJD_weapon.SetActive(true);
            playerController.act = false;
            playerController.skillCoolDownTime_BJD = playerController.maxSkillCoolDownTime_BJD;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, skill_range, enemyLayers);
        foreach (Collider2D col in cols)
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            list.Add(col.GetComponent<Enemy>());
            float directionx = transform.position.x - col.GetComponent<Transform>().transform.position.x;
            float directiony = transform.position.y - col.GetComponent<Transform>().transform.position.y;

            Vector2 distance = new Vector2(directionx, directiony);

            //rb.AddForce(new Vector2(col.transform.position.x + distance.normalized.x * (-30000f), col.transform.position.x + distance.normalized.y * (-30000f), ForceMode2D.Impulse));
            col.GetComponent<CharacterStats>().TakeDamage(10f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, skill_range);
    }
}
