using UnityEngine;

public class S_stick : MonoBehaviour
{
    private bool isStuck = false;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Collider collider;

    [SerializeField]
    GameObject stickArrow;

    private void OnCollisionEnter(Collision collision){
        if (!isStuck){
            StickToTarget(collision.gameObject);
        }
    }

    private void StickToTarget(GameObject target){
        rigidbody.isKinematic = true;
        collider.isTrigger = true;
        
        // Attach the arrow to the target by setting its parent.
        transform.parent = target.transform;

        GameObject arrow = Instantiate(stickArrow);
        arrow.transform.localPosition = transform.position;
        arrow.transform.forward = transform.forward;

        Destroy(gameObject);
    }
}
