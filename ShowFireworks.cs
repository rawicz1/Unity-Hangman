using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFireworks : MonoBehaviour
{
    public GameObject particlePrefab; // Assign the particle prefab in the Inspector
    private float spawnTimer = 0f;
    private float spawnInterval = 1f; // Spawn every 1 second

    private void Start()
    {
        SpawnParticle();
    }
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnParticle();
            spawnTimer = 0f;
        }
    }

    void SpawnParticle()
    {
        // Get the camera's bounds
        Camera camera = Camera.main;
        float cameraWidth = camera.orthographicSize * camera.aspect;
        float cameraHeight = camera.orthographicSize;

        // Define the inset area within the camera's bounds
        float insetX = cameraWidth * 0.2f; // 20% inset from left and right
        float insetY = cameraHeight * 0.2f; // 20% inset from top and bottom

        float minX = -cameraWidth + insetX;
        float maxX = cameraWidth - insetX;
        float minY = -cameraHeight + insetY;
        float maxY = cameraHeight - insetY;

        // Generate a random position within the inset area
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 position = new Vector3(x, y, 0f);

        // Instantiate the particle prefab at the random position
        Instantiate(particlePrefab, position, Quaternion.identity);

        // Generate a random starting color for the particles
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color randomColor = new Color(r, g, b);

        // Instantiate the particle prefab at the random position with the random color
        GameObject particle = Instantiate(particlePrefab, position, Quaternion.identity);
        var particleSystem = particle.GetComponent<ParticleSystem>();
        var mainModule = particleSystem.main;
        mainModule.startColor = randomColor;

        // Change the color over time
        var colorOverLifetime = particleSystem.colorOverLifetime;
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)),
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f))
        );

        StartCoroutine(DestroyInactiveParticles());
    }
    IEnumerator DestroyInactiveParticles()
    {
        // Find all ParticleSystem components in the scene
        ParticleSystem[] particleSystems = FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem ps in particleSystems)
        {
            // Check if the particle system is not playing
            if (!ps.isPlaying)
            {
                // Destroy the GameObject if the particle system is inactive
                Destroy(ps.gameObject);
                // Optionally, yield to allow for frame updates
                yield return null; // Wait for the next frame
            }
        }
    }
}
