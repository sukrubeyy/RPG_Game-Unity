using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    bool interacted = false;

    public Transform interactionsTransform;
    private void Update()
    {
        if(isFocus)
        {
            float distance = Vector3.Distance(player.transform.position, interactionsTransform.position);
            if(distance<=radius && !interacted)
            {
                Interact();
                interacted = true;
            }
        }
    }

    public virtual void Interact()
    {
        
    }
    public void OnFocus(Transform playerTransform)
    {
        isFocus = true;
        interacted = false;
        player = playerTransform.transform;
    }
    public void OnEnFocus()
    {
        isFocus = false;
        interacted = false;
        player = null;
    }
    public void OnDrawGizmosSelected()
    {
        if (interactionsTransform == null)
            interactionsTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionsTransform.position,radius);
    }
}
