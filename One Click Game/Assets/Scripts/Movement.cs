using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //movement mechs
    public GameObject cam;
    public float movementSpeed;
    public float attackSpeed;
    public static bool attackable = false;

    //stamina mechs
    public Slider staminaBar;
    public float rechargeRate;
    public float maxStamina;
    float stamina;
    bool cooldowning = false;

    public GameObject gameP, deathP;

    void Awake()
    {
        stamina = maxStamina;
    }
    
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (stamina == 0)
                StartCoroutine(StaminaCooldown());
            else
                OnAttack();
        }
        else if (!cooldowning)
            MoveForward();

        staminaBar.value = stamina / maxStamina;
    }

    void MoveForward()
    {
        cam.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);   
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        
        RechargeStamina();

        attackable = false;
    }

    void OnAttack()
    {
        if (!cooldowning)
        { 
            cam.transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);

            DrainStamina();

            attackable = true; 
        }
    }

    void DrainStamina()
    {
        stamina -= Time.deltaTime;
        stamina = (stamina <= 0) ? 0 : stamina;
    }

    void RechargeStamina()
    {
        stamina += rechargeRate * Time.deltaTime;
        stamina = (stamina > maxStamina) ? maxStamina : stamina;
    }

    IEnumerator StaminaCooldown()
    {
        while (stamina != maxStamina)
        {
            MoveForward();
            cooldowning = true;
            yield return null;
        }

        cooldowning = false;
        yield break;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            gameP.SetActive(false);
            deathP.SetActive(true);
            gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

}
