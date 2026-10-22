using UnityEngine;

public class FrogCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            SoundManager.Instance.PlayCarHit();
            GameManager.Instance.LoseLife();
        }
    }
}