    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour
{
    [SerializeField] AudioClip flashlightOnSound;
    [SerializeField] GameObject lightComponent;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider staminaBar;
    [SerializeField] WaitForSeconds cooldownTick = new WaitForSeconds(.2f);
    bool isReloading = false;
    float currentStamina;
    float maxStamina = 100;
    bool isActive;
    float amount = .2f;
    bool isNotDoneOnce = true;
    bool controlsDisabled;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        lightComponent.SetActive(true);
        isReloading = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        isActive = lightComponent.activeInHierarchy;
        if(controlsDisabled){return;}
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            isReloading = isActive;
            if(isNotDoneOnce)
            {
                StartCoroutine(DecreaseFlashlightBar(amount)); 
                isNotDoneOnce = false;
            }
           
                 lightComponent.SetActive(!isActive);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(flashlightOnSound);
            }
          
           
        }

        //DELETE THIS LATER (THIS IS FOR TEST BUILDS)
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }
       

    }


        IEnumerator DecreaseFlashlightBar(float amount)
        { 
            while(currentStamina > 0)
            {
               if(!isReloading && currentStamina != 0){
                   currentStamina -= amount; 
                   
                staminaBar.value = currentStamina; 
                
               
               }
                 yield return new WaitForSeconds(.1f);
            }
            isReloading = true;
            StartCoroutine(IncreaseFlashlightBar());
            controlsDisabled = true;
           
        }

        IEnumerator IncreaseFlashlightBar()
        {
            lightComponent.SetActive(false);
            yield return new WaitForSeconds(2);
            while(currentStamina < maxStamina)
            {
                currentStamina = currentStamina + amount*10;
                staminaBar.value = currentStamina;
                yield return cooldownTick;
            }
            isReloading = false;
            controlsDisabled = false;
            isNotDoneOnce= true;
        }
}
