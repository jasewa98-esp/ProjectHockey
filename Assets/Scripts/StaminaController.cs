using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private CanvasGroup canvasGroup;
    private ThirdPersonController thirdPersonController;

    float velocity = 5f;

    private void Start()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        slider.value = 1;
    }

    private void Update()
    {
        if (slider.value <= 0)
        {
            thirdPersonController.SetSprintSpeed(true);
        }
        else
        {
            thirdPersonController.SetSprintSpeed(false);
        }

        if (thirdPersonController.GetSprintCondition())
        {
            canvasGroup.alpha = 1;
            slider.value -= velocity / 2500;
        }
        else if (slider.value < 1)
        {
            slider.value += velocity / 2500;
        }

        if (slider.value >= 1) canvasGroup.alpha = 0;
    }


    public void ResetStamina()
    {
        slider.value = 1;
        canvasGroup.alpha = 0;
        thirdPersonController.SetSprintSpeed(false);
    }
}
