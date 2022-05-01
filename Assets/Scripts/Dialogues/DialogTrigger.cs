using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialogue dialog;
    public float radius;

    public void TriggerDialog() {
        FindObjectOfType<DialogManager>().StartDialogue(dialog);
        //FindObjectOfType<DialogManager>().UpdateIcon(dialog);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
