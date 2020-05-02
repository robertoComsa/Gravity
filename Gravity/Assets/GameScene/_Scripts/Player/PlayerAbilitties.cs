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
    bool isMagnetOn = false;
    public bool GetIsMagnetOn() { return isMagnetOn; }

    // Shield - E
    bool isShieldOnCd = false;
    Image shieldImage = null;
    bool isShieldOn = false;
    [SerializeField] GameObject shield=null;
    public bool GetIsShieldOn() { return isShieldOn; }

    // Ultimate - R
    bool isUltimateOnCd = false;
    Image ultimateImage = null;
    [SerializeField] Image ultimateEffectImage = null;

    PlayerController player = null;

    // ------------------------------------------------------ Variabile vizibile in editor ------------------------------------------------ //

    [SerializeField] GameObject superSpeedAbltBtn =null;
    [SerializeField] GameObject heartMagnetAbltBtn = null;
    [SerializeField] GameObject shieldAbltBtn = null;
    [SerializeField] GameObject ultimateAbltBtn = null;

    [SerializeField] float superSpeedAbltCD = 0f;
    [SerializeField] float heartMagnetAbltCD = 0f;
    [SerializeField] float shieldAbltCD = 0f;
    [SerializeField] float ultimateAbltCD = 0f;

    // ----------------------------------------------------------------- Metode sistem --------------------------------------------------------- //

    private void Update()
    {
        ManageAbilities();
    }

    private void Awake()
    { 
        // Abilities
        superSpeedImage = superSpeedAbltBtn.GetComponentInChildren<Image>();
        heartMagnetImage = heartMagnetAbltBtn.GetComponentInChildren<Image>();
        shieldImage = shieldAbltBtn.GetComponentInChildren<Image>();
        ultimateImage = ultimateAbltBtn.GetComponentInChildren<Image>();
        shield.SetActive(false);
        // Others
        player = GetComponent<PlayerController>();
    }

    // --------------------------------------------------------------------- Metode ------------------------------------------------------------ //

    private void ManageAbilities()
    {
        SuperSpeedAbility(); // Q
        HeartMagnetAbility(); // W 
        ShieldAbility(); // E 
        UltimateAbility(); // R
    }


    // ------------ Prima abilitate - Super viteza - Q -------------- //  

    bool ablt1check = false;

    IEnumerator ApplyCooldownOnAblt_1(float cooldown)
    {
        ablt1check = true;
        yield return new WaitForSeconds(cooldown);
        superSpeedImage.color = new Color32(255, 255, 255, 255);
        isSuperSpeedOnCd = false;
        ablt1check = false;
    }

    private void SuperSpeedAbility()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isSuperSpeedOnCd==false)
        {
            isSuperSpeedOnCd = true;
            superSpeedImage.color = new Color32(108, 108, 108, 255);
            StartCoroutine(IncreaseSpeed());
        }

        if (isSuperSpeedOnCd && !ablt1check)
        {
            StartCoroutine(ApplyCooldownOnAblt_1(superSpeedAbltCD));
        }
    }

    IEnumerator IncreaseSpeed()
    {
        player.SetPlayerSpeed(player.GetPlayerSpeed * 2f);
        // Aici adaugi efeect , pana trec cele 1,3 secunde de speedboost ( ex : caracterul lasa dunga particule )
        yield return new WaitForSeconds(1.3f);
        player.SetPlayerSpeed(player.GetPlayerSpeed / 2f);
    }

    // ------------ A 2-a abilitate - Magnet inimi - W -------------- //

    bool ablt2check = false;

    IEnumerator ApplyCooldownOnAblt_2(float cooldown)
    {
        ablt2check = true;
        yield return new WaitForSeconds(cooldown);
        heartMagnetImage.color = new Color32(255, 255, 255, 255);
        isHeartMagnetOnCd = false;
        ablt2check = false;
    }

    private void HeartMagnetAbility()
    {
        if (Input.GetKeyDown(KeyCode.W) && isHeartMagnetOnCd==false)
        {
            isHeartMagnetOnCd = true;
            heartMagnetImage.color = new Color32(108, 108, 108, 255);
            StartCoroutine(ActivateHeartMagnet());
        }

        if(isHeartMagnetOnCd && !ablt2check)
        {
            StartCoroutine(ApplyCooldownOnAblt_2(heartMagnetAbltCD));
        }
    }

    IEnumerator ActivateHeartMagnet()
    {
        isMagnetOn = true;
        yield return new WaitForSeconds(5f);
        isMagnetOn = false;
    }

    // ---------------- A 3-a abilitate - Shield - E ------------- // 

    bool ablt3check = false;

    IEnumerator ApplyCooldownOnAblt_3(float cooldown)
    {
        ablt3check = true;
        yield return new WaitForSeconds(cooldown);
        shieldImage.color = new Color32(255, 255, 255, 255);
        isShieldOnCd = false;
        ablt3check = false;
    }

    private void ShieldAbility()
    {
        if (Input.GetKeyDown(KeyCode.E) && isShieldOnCd==false)
        {
            isShieldOnCd = true;
            shieldImage.color = new Color32(108, 108, 108, 255);
            StartCoroutine(ActivateShield());
        }

        if (isShieldOnCd && !ablt3check)
        {
            StartCoroutine(ApplyCooldownOnAblt_3(shieldAbltCD));
        }
    }

    IEnumerator ActivateShield()
    {
        isShieldOn = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(3f);
        shield.SetActive(false);
        isShieldOn = false;
    }

    // ---------------- A 4-a abilitate - Ultimata - R ------------- // 

    bool ablt4check = false;

    IEnumerator ApplyCooldownOnAblt_4(float cooldown)
    {
        ablt4check = true;
        yield return new WaitForSeconds(cooldown);
        ultimateImage.color = new Color32(255, 255, 255, 255);
        isUltimateOnCd = false;
        ablt4check = false;
    }

    private void UltimateAbility()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isUltimateOnCd)
        {
            isUltimateOnCd = true;
            ultimateImage.color = new Color32(108, 108, 108, 255);
            ApplyUltimateAbility();
        }

        if (isUltimateOnCd && !ablt4check)
        {
            StartCoroutine(ApplyCooldownOnAblt_4(ultimateAbltCD));
        }
    }

    private void ApplyUltimateAbility()
    {
        StartCoroutine(FlashOnScreenForUltimate());
        SpaceObject[] spaceObjects = FindObjectsOfType<SpaceObject>();
        foreach (SpaceObject spaceObject in spaceObjects)
        {
            if (spaceObject.CompareTag("Asteroid")) Destroy(spaceObject.gameObject);
            else if(spaceObject.CompareTag("Satellite"))
                spaceObject.SetDestination(spaceObject.GetSatelliteReturnDestination());
        }
    }

    IEnumerator FlashOnScreenForUltimate()
    {
        ultimateEffectImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        ultimateEffectImage.gameObject.SetActive(false);
    }
}
