using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBossController : MonoBehaviour
{
    [SerializeField] bool bossGate = false;
    [SerializeField] string withLevel = "[Wpisz nazwê poziomu]";
    [SerializeField] int levelNumber;
    [SerializeField] int sceneNumber = 0;
    private bool isActive = false; // Pocz¹tkowo skrypt jest wy³¹czony

    void Start()
    {
        // Wy³¹cz skrypt po za³adowaniu mapy
        StopScript();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            Debug.Log("Za³adowano scenê: [" + withLevel + "] numer: " + sceneNumber);

            if (!bossGate)
            {
                SceneManager.LoadScene(sceneNumber);
            }
            else
            {
                SceneManager.LoadScene(levelNumber);
            }
        }
    }

    public void StartScript()
    {
        // W³¹czanie skryptu
        isActive = true;
    }

    public void StopScript()
    {
        // Zatrzymywanie skryptu
        isActive = false;
    }
}
