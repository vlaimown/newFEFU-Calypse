using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
       // Debug.Log("Interacting wiht " + transform.name);
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            //float distance = Vector2.Distance((player.position, interactionTransform.position) <radius);
            //if (distance <= radius)
            //{
                //Interact();
                //hasInteracted = true;
            //}
        }
    }
}
