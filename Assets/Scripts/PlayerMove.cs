using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float movement = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(movex, movey, 0f);

        transform.Translate(moveDirection * movement * Time.deltaTime);
    }
}
