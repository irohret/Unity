using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class S_stick : MonoBehaviour
{
    private bool isStuck = false;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Collider collider;

    [SerializeField]
    GameObject stickArrowPrefab, NonStickArrowPrefab;

    private S_ObjectPool nonStickArrowPool;
    private S_ObjectPool stickArrowPool;
    private bool isDestroyed = false;

    private void OnCollisionEnter(Collision collision){
        // Debug.Log("stick :: Collision with: " + collision.gameObject.tag);
        if (!isStuck && collision.gameObject.tag == "Target"){
            StickToTarget(collision.gameObject);
        } else {
            DontStickToTarget(collision.gameObject);
        }
    }

    // Allow the arrow to stick to object that have the Tag and Lay "Target
    private void StickToTarget(GameObject target){
        rigidbody.isKinematic = true;
        collider.isTrigger = true;
        
        // Attach the arrow to the target by setting its parent.
        transform.parent = target.transform;
        // transform.localRotation = Quaternion.identity;

        GameObject arrow = Instantiate(stickArrowPrefab);
        arrow.transform.localPosition = transform.position;
        arrow.transform.forward = transform.forward;
        
        isDestroyed = true;

        Destroy(gameObject);
    }

    private void DontStickToTarget(GameObject target){
        rigidbody.isKinematic = false;

        transform.parent = target.transform;
     
        GameObject arrow = Instantiate(NonStickArrowPrefab);
        arrow.transform.localPosition = transform.position;
        arrow.transform.localRotation = transform.localRotation;
        isDestroyed = true;
    
        Destroy(gameObject);
    }

}
