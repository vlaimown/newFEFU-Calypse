using System.Collections.Generic;
using UnityEngine;

public class BJD_skill : MonoBehaviour
{
    [SerializeField] float skill_range;
    [SerializeField] float max_alive_time;
    [SerializeField] float current_alive_time;

    [SerializeField] float damage_by_bjd;


    [SerializeField] PlayerController playerController;

    [SerializeField] LayerMask enemyLayers;

    [SerializeField] List<EnemyStats> list;

    private Collider2D[] cols;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        current_alive_time = max_alive_time;
        playerController.coolDownBJD.gameObject.SetActive(true);

       cols = Physics2D.OverlapCircleAll(transform.position, skill_range, enemyLayers);
       //Debug.Log(cols.Length);
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
            foreach (EnemyStats enemy in list)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
            playerController.BJD_weapon.SetActive(true);
            playerController.act = false;
            playerController.skillCoolDownTime_BJD = playerController.maxSkillCoolDownTime_BJD;
            list.Clear();
            list = new List<EnemyStats>(0);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Collider2D col in cols)
        {
                Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                list.Add(col.GetComponent<EnemyStats>());
                float directionx = transform.position.x - col.GetComponent<Transform>().transform.position.x;
                float directiony = transform.position.y - col.GetComponent<Transform>().transform.position.y;

                Vector2 distance = new Vector2(directionx, directiony);

                rb.AddForce(new Vector2(col.transform.position.x + distance.normalized.x * (-28000f), col.transform.position.y + distance.normalized.y * (-28000f)), ForceMode2D.Impulse);
        }
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyStats>().TakeDamage(10f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, skill_range);
    }
}
