using UnityEngine;

public class FrogBounds : MonoBehaviour
{
    public SpriteRenderer fieldReference;
    public float tolerance = 0.1f;
    private float nextAllowedTime = 0f;

    void Update()
    {
        if (fieldReference == null) return;
        if (Time.time < nextAllowedTime) return;

        Bounds b = fieldReference.bounds;
        float x = transform.position.x;

        if (x < b.min.x - tolerance || x > b.max.x + tolerance)
        {
            nextAllowedTime = Time.time + 0.3f;
            SoundManager.Instance.PlayWater();
            GameManager.Instance.LoseLife();
            Physics2D.SyncTransforms();
        }
    }
}