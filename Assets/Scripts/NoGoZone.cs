using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    public Transform player;
    public float shakeProximity = 0.5f;
    public float shakeStrength = 0.1f;
    public float failDistance = 1f;

    private Vector3 originalPosition;


    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;

        originalPosition = transform.localPosition;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < shakeProximity)
        {

            float x = Random.Range(-1f, 1f) * shakeStrength;
            float y = Random.Range(-1f, 1f) * shakeStrength;

            transform.localPosition = originalPosition + new Vector3 (x, y, 0f);

            if (distance < failDistance)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            transform.position = originalPosition;
        }
    }
}
