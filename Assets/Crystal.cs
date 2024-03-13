using UnityEngine;

public class Crystal : MonoBehaviour
{
    public PortalBossController portalBossController; // Przypisz referencjê do skryptu PortalBossController w inspektorze

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Jeœli gracz zetknie siê z kryszta³em, usuñ kryszta³
            Destroy(gameObject);

            // W³¹cz skrypt PortalBossController po zniszczeniu kryszta³u
            if (portalBossController != null)
            {
                portalBossController.StartScript();
            }
        }
    }
}
