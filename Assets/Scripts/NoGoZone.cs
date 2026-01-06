using System.Collections;
using UnityEngine;

public class NoGoZone : MonoBehaviour
{
    public Transform player;
    public float shakeProximity = 0.5f;
    public float shakeStrength = 0.1f;
    public float shakeDistance = 5f;
    public float shake = 2f;

    private Vector3 originalPosition;


    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;

        originalPosition = transform.position;
    }

    void Update()
    {
         float distance = player.position.magnitude;
        if (distance < shakeProximity) 
        { 
            float proximityStrength = Mathf.Lerp(0f, shakeStrength, 1f - (distance / shakeProximity));

            StartCoroutine(Shake());

        }


    }

    private IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDistance)
        {
            float x = Random.Range (-1f, 1f) * shakeStrength;
            float y = Random.Range(-1f, 1f) * shakeStrength;

            transform.localPosition = originalPosition + new Vector3 (x, y, 0f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;

    }
}
