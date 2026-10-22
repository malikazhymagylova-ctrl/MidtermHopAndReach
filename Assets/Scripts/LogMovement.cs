using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public bool moveRight = true;

    public float leftLimit = -6f;
    public float rightLimit = 6f;

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x > rightLimit)
            {
                transform.position = new Vector3(
                    leftLimit,
                    transform.position.y,
                    transform.position.z
                );
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x < leftLimit)
            {
                transform.position = new Vector3(
                    rightLimit,
                    transform.position.y,
                    transform.position.z
                );
            }
        }
    }
}