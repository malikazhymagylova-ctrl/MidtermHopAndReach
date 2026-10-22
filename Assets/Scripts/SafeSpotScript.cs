using UnityEngine;

public class SafeSpotScript : MonoBehaviour
{
    public int points = 100;
    public Color filledColor = Color.white;
    private bool filled = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Frog")) return;

        if (!filled)
        {
            filled = true;
            sr.color = filledColor;
            SoundManager.Instance.PlaySafeSpot();
            GameManager.Instance.AddScore(points);
            GameManager.Instance.ResetFrog();
            GameManager.Instance.SpotFilled();
        }
        else
        {
            GameManager.Instance.LoseLife();
        }
    }
}