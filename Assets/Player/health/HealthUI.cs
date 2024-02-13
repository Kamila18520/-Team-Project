using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth; // Referencja do skryptu obsługującego zdrowie gracza
    public Image heartImage; // Referencja do obrazka serduszka w UI

    // Update is called once per frame
    void Update()
    {
        // Obliczanie procentowego zdrowia gracza
        float healthPercentage = playerHealth.currentHealth / (playerHealth.maxHealth * playerHealth.healthPerHeart);

        // Aktualizacja rozmiaru serduszka w zależności od zdrowia gracza
        heartImage.rectTransform.localScale = new Vector3(healthPercentage, healthPercentage, 1f);
    }
}
