using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;


    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

        
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

    }
}
