using UnityEngine;

public class PowerUps : MonoBehaviour
{
    void Start()
    {
      
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player rocketIncrease = other.GetComponent<Player>();
        if (rocketIncrease != null)
        {
            rocketIncrease.IncreaseRocketCount();
            Destroy(gameObject);
        }

    }

}
