using UnityEngine;

public class WinZone : MonoBehaviour
{

    public Transform player;
    public float winDistance = 1f;

    public GameObject winUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < winDistance)
        {
            winUI.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}
