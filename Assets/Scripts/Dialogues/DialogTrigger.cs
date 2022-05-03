using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public float radius;

    public void TriggerDialog() {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
