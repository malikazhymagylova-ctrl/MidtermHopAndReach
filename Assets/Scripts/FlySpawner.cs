using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject flyPrefab;
    public Collider2D[] spawnZones;
    public SpriteRenderer widthReference;
    public float spawnInterval = 6f;
    public int maxFlies = 1;
    public float margin = 0.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFly), spawnInterval, spawnInterval);
    }

    void SpawnFly()
    {
        if (GameObject.FindGameObjectsWithTag("Fly").Length >= maxFlies) return;

        Collider2D zone = spawnZones[Random.Range(0, spawnZones.Length)];
        Bounds b = zone.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        if (widthReference != null)
        {
            x = Mathf.Clamp(x, widthReference.bounds.min.x + margin, widthReference.bounds.max.x - margin);
        }

        Instantiate(flyPrefab, new Vector3(x, y, 0f), Quaternion.identity);
    }
}