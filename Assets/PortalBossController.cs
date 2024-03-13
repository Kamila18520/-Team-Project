using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBossController : MonoBehaviour
{
    [SerializeField] bool bossGate = false;
    [SerializeField] string withLevel = "[Wpisz nazw� poziomu]";
    [SerializeField] int levelNumber;
    [SerializeField] int sceneNumber = 0;
    private bool isActive = false; // Pocz�tkowo skrypt jest wy��czony

    void Start()
    {
        // Wy��cz skrypt po za�adowaniu mapy
        StopScript();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            Debug.Log("Za�adowano scen�: [" + withLevel + "] numer: " + sceneNumber);

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
        // W��czanie skryptu
        isActive = true;
    }

    public void StopScript()
    {
        // Zatrzymywanie skryptu
        isActive = false;
    }
}
