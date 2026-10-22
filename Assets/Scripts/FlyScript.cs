using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public float lifetime = 5f;
    public int points = 50;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Frog")) return;

        SoundManager.Instance.PlayEatFly();
        GameManager.Instance.AddCharge();
        GameManager.Instance.AddScore(points);
        Destroy(gameObject);
    }
}