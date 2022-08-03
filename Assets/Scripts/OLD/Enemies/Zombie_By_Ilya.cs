using UnityEngine;

public class Zombie_By_Ilya : MonoBehaviour
{
    //[SerializeReference] PlayerController playerController;
    //[SerializeField] float zombie_speed;

    //[SerializeField] GameObject attack_point;

    //Animator animator;

    //[SerializeField] float attack_zone_1;
    //[SerializeField] float attack_zone_2;
    //[SerializeField] float attack_zone_3;

    //[SerializeField] float stop_move;

    //bool zombieFacingRight;

    //private void Start()
    //{
    //    playerController = FindObjectOfType<PlayerController>();
    //    animator = GetComponent<Animator>();
    //    zombieFacingRight = true;
    //}

    //private void Update()
    //{
    //    if (Vector2.Distance(playerController.hero.position, transform.position) > stop_move)
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, playerController.hero.position, zombie_speed * Time.deltaTime);
    //        animator.Play("Zombie_by_Ilya_Movement");
    //    }

    //    if (Vector2.Distance(playerController.hero.position, attack_point.transform.position) <= attack_zone_1 &&
    //        Vector2.Distance(playerController.hero.position, attack_point.transform.position) > attack_zone_2 &&
    //        Vector2.Distance(playerController.hero.position, attack_point.transform.position) > attack_zone_3)
    //    {
    //        playerController.GetComponent<PlayerStat>().TakeDamage(Time.fixedDeltaTime);
    //        Debug.Log(Time.deltaTime);
    //    }

    //    else if (Vector2.Distance(playerController.hero.position, attack_point.transform.position) <= attack_zone_2 &&
    //            Vector2.Distance(playerController.hero.position, attack_point.transform.position) > attack_zone_3)
    //    {
    //        playerController.GetComponent<PlayerStat>().TakeDamage(Time.fixedDeltaTime * 5f);
    //        Debug.Log(Time.deltaTime * 10f);
    //    }

    //    else if (Vector2.Distance(playerController.hero.position, attack_point.transform.position) <= attack_zone_3)
    //    {
    //        playerController.GetComponent<PlayerStat>().TakeDamage(Time.fixedDeltaTime * 10f);
    //        Debug.Log(Time.deltaTime * 100f);
    //    }

    //    if (zombieFacingRight == true && playerController.hero.transform.position.x < transform.position.x)
    //    {
    //        Flip();
    //    }

    //    else if (zombieFacingRight == false && playerController.hero.transform.position.x > transform.position.x)
    //    {
    //        Flip();
    //    }
    //}

    //public void Flip()
    //{
    //    zombieFacingRight = !zombieFacingRight;
    //    Vector3 scaler = transform.localScale;
    //    scaler.x *= -1;

    //    transform.localScale = scaler;
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(attack_point.transform.position, attack_zone_1);
    //    Gizmos.DrawWireSphere(attack_point.transform.position, attack_zone_2);
    //    Gizmos.DrawWireSphere(attack_point.transform.position, attack_zone_3);
    //}
}
