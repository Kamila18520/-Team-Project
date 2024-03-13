using UnityEngine;

public class Crystal : MonoBehaviour
{
    public PortalBossController portalBossController; // Przypisz referencj� do skryptu PortalBossController w inspektorze

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Je�li gracz zetknie si� z kryszta�em, usu� kryszta�
            Destroy(gameObject);

            // W��cz skrypt PortalBossController po zniszczeniu kryszta�u
            if (portalBossController != null)
            {
                portalBossController.StartScript();
            }
        }
    }
}
