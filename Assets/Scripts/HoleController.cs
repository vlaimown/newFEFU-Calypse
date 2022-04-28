using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleController : MonoBehaviour
{
    [SerializeField] float maxHoleWaitTime;
    [SerializeField] float currentHoleWaitTime;

    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialoguesController dialoguesController;

    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] Image fade;

    private void Awake()
    {
        fade.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(true);
    }

    private void Start()
    {
        currentHoleWaitTime = maxHoleWaitTime;
    }

    private void FixedUpdate()
    {
        if (currentHoleWaitTime > 0)
        {
            currentHoleWaitTime -= Time.deltaTime;
        }

        if (currentHoleWaitTime <= 0 && dialogManager.dialogueNumber == 1)
        {
            dialogManager.dialogueWindow.SetActive(true);
            dialoguesController.tenthDialogue.TriggerDialog();
        }
    }
}
