using UnityEngine;

public class StudentPassAttack : MonoBehaviour
{
    //public GameObject student_pass_prefab;
    //[SerializeField] GameObject current_student_pass;

    Vector2 distance;
    [SerializeField]
    float distance_hero_pass;
    [SerializeField] bool student_pass_attack = false;

    [SerializeField] PlayerController player_controller;

    private void Start()
    {
        player_controller = FindObjectOfType<PlayerController>();
        student_pass_attack = true;
        //distance = new Vector2(player_controller.student_pass.transform.position.x + 10f * player_controller.transform.localScale.normalized.x, player_controller.student_pass.transform.position.y);
    }

    private void Update()
    {
             //float distance = Vector2.Distance(current_student_pass.transform.position, last_student_point.transform.position);
        //     distance_hero_pass = Vector2.Distance(distance, transform.position);

        //     if (student_pass_attack == true)
        //     {
        //    transform.Rotate(0, 0, -5f);
        //         transform.position = Vector2.MoveTowards(transform.position, distance, 8f * Time.deltaTime);
        //     }
             
        //     if (distance_hero_pass < 0.5f)
        //     {
        //         student_pass_attack = false;
        //     }

        //     if (student_pass_attack == false)
        //    {
        //    transform.Rotate(0, 0, 5f);
        //    transform.position = Vector2.MoveTowards(transform.position, player_controller.student_pass.transform.position, 8f * Time.deltaTime);
        //    }

        //     if (Vector2.Distance(player_controller.student_pass.transform.position, transform.position) <= 0.1f && student_pass_attack == false)
        //     {
        //        player_controller.student_pass.SetActive(true);
        //        Destroy(gameObject);
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        collision.GetComponent<EnemyStats>().TakeDamage(15f);
    //    }
    //}
}
