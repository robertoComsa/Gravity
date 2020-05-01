using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilitties : MonoBehaviour
{
    // -------------------------------------------------------------- Variabile ----------------------------------------------------------- //

    // SuperSpeed - Q
    bool isSuperSpeedOnCd = false;
    Image superSpeedImage = null;

    // HeartMagnet - W 
    bool isHeartMagnetOnCd = false;
    Image heartMagnetImage = null;

    // Warp - E
    bool isWarpOnCd = false;
    Image warpImage = null;

    // Ultimate - R
    bool isUltimateOnCd = false;
    Image ultimateImage = null;

    // ------------------------------------------------------ Variabile vizibile in editor ------------------------------------------------ //

    [SerializeField] GameObject superSpeedAbltBtn =null;
    [SerializeField] GameObject heartMagnetAbltBtn = null;
    [SerializeField] GameObject warpAbltBtn = null;
    [SerializeField] GameObject ultimateAbltBtn = null;

    [SerializeField] float superSpeedAbltCD = 0f;
    [SerializeField] float heartMagnetAbltCD = 0f;
    [SerializeField] float warpAbltCD = 0f;
    [SerializeField] float ultimateAbltCD = 0f;

    // ----------------------------------------------------------------- Metode sistem --------------------------------------------------------- //

    private void Update()
    {
        ManageAbilities();
    }

    private void Awake()
    { 
        superSpeedImage = superSpeedAbltBtn.GetComponentInChildren<Image>();
        heartMagnetImage = heartMagnetAbltBtn.GetComponentInChildren<Image>();
        warpImage = warpAbltBtn.GetComponentInChildren<Image>();
        ultimateImage = ultimateAbltBtn.GetComponentInChildren<Image>();
    }

    // --------------------------------------------------------------------- Metode ------------------------------------------------------------ //

    private void ManageAbilities()
    {
        SuperSpeedAbbility(); // Q
        HeartMagnetAbillity(); // W 
        WarpAbillity(); // E 
        UltimateAbillity(); // R
    }

    private void ApplyCooldownOnAblt(float cooldown, Image image, bool isAbltOnCD)
    {
        image.fillAmount += 1 / cooldown * Time.deltaTime;
        if (image.fillAmount >= 1)
        {
            image.fillAmount = 0;
            isAbltOnCD = false;
            image.color = new Color32(255, 255, 255, 255);
        }
    }

    // ------------ Prima abilitate - Super viteza - Q -------------- //  
    private void SuperSpeedAbbility()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isSuperSpeedOnCd = true;
            superSpeedImage.color = new Color32(108, 108, 108, 255);
        }

        if (isSuperSpeedOnCd) ApplyCooldownOnAblt(superSpeedAbltCD, superSpeedImage, isSuperSpeedOnCd);
    }

    // ------------ A 2-a abilitate - Magnet inimi - W -------------- //
    private void HeartMagnetAbillity()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isHeartMagnetOnCd = true;
            heartMagnetImage.color = new Color32(108, 108, 108, 255);
        }

        if (isHeartMagnetOnCd) ApplyCooldownOnAblt(heartMagnetAbltCD, heartMagnetImage, isHeartMagnetOnCd);
    }

    // ---------------- A 3-a abilitate - Teleportare - E ------------- // 
    private void WarpAbillity()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isWarpOnCd = true;
            warpImage.color = new Color32(108, 108, 108, 255);
        }

        if (isWarpOnCd) ApplyCooldownOnAblt(warpAbltCD, warpImage, isWarpOnCd);
    }

    // ---------------- A 4-a abilitate - Ultimata - R ------------- // 
    private void UltimateAbillity()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isUltimateOnCd = true;
            ultimateImage.color = new Color32(108, 108, 108, 255);
        }

        if (isUltimateOnCd) ApplyCooldownOnAblt(ultimateAbltCD, ultimateImage, isUltimateOnCd);
    }
}
