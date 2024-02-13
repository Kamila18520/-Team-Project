using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maksymalne zdrowie gracza w liczbie pe�nych serduszek
    public float healthPerHeart = 1.0f; // Warto�� zdrowia reprezentowanej przez jedno serduszko (1.0f = pe�ne serduszko)
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth * healthPerHeart; // Obliczanie pocz�tkowej warto�ci zdrowia
    }

    // Function to handle player taking damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth * healthPerHeart); // Ograniczenie zdrowia w granicach od 0 do maksymalnego zdrowia
    }

    // Function to handle player healing
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth * healthPerHeart); // Ograniczenie zdrowia w granicach od 0 do maksymalnego zdrowia
    }
}