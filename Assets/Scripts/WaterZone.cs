using UnityEngine;

public class WaterZone : MonoBehaviour
{
    private float nextAllowedTime = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < nextAllowedTime) return;

        if (other.CompareTag("Frog"))
        {
            FrogController frog = other.GetComponent<FrogController>();

            if (frog != null && !frog.IsOnLog())
            {
                nextAllowedTime = Time.time + 0.2f;
                SoundManager.Instance.PlayWater();
                GameManager.Instance.LoseLife();
                Physics2D.SyncTransforms();
            }
        }
    }
}