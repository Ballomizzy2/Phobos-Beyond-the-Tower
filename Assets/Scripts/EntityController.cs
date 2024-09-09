using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class EntityController : MonoBehaviour
{

    [SerializeField] private Transform mainCharacter;

    [SerializeField, Range(0f, 10f)]
    private float followDamp = 10F;

    [SerializeField, Range(0f, 1f)]
    private float followIntensity = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if player is not dead
        FollowTarget(mainCharacter);
    }

    public void FollowTarget(Transform target)
    {
        // Follow the target with smooth damping
        Vector3 desiredPosition = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followIntensity * Time.deltaTime * followDamp);
        transform.position = smoothedPosition;

        // Optionally, rotate towards the target if needed
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * followDamp);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Kill / Jumpscare the main character
            Debug.Log("You diewwwwweee");
        }
    }
}
