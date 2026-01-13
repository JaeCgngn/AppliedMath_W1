using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

 
    public GameObject rocketPrefab;
    public float fireInterval = 2f;
    public int rocketCount = 4;
    public int maxCount = 8;
    public float rocketSpeed = 10f;

    private float fireTimer;


    void Start()
    {
        PlayerMovement();
        FireRockets();
    }

    void Update()
    {
        PlayerMovement();
        Firing();
    }

    void PlayerMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        Vector3 dir = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Firing()
    {

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            FireRockets();
            Debug.Log("Timer Reset");
        }

        Debug.Log("Timer Active");
    }

    void FireRockets()
    {
        float angleStep = 360f / rocketCount;
        float startAngle = 45f;

        for (int i = 0; 1 < rocketCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Vector3 dir = AngleToDirection(angle);

            GameObject rocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);

            rocket.GetComponent<Rocket>().SetDirection(dir);
        }

        Debug.Log("Rockets Spawned");
    }

    Vector3 AngleToDirection(float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);

    }

    public void IncreaseRocketCount()
    {
        rocketCount = Mathf.Min(rocketCount + 1, maxCount);
    }


}
