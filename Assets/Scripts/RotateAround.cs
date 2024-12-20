using UnityEngine;

// Place this script on a game object to make it rotate around a target object
public class RotateAround : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;

    private float radius;

    void Start()
    {
     
        radius = Vector3.Distance(transform.position, target.transform.position);
    }

    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        float rotation = Time.deltaTime * speed;

     
        transform.RotateAround(targetPosition, Vector3.forward, rotation);

   
        Vector3 currentOffset = transform.position - targetPosition;
        transform.position = targetPosition + currentOffset.normalized * radius;
    }
}
