using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenController : MonoBehaviour
{
    public static bool kitchenVisisted = false;

    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialoguesController dialoguesController;

    [SerializeField] Image fade;
    [SerializeField] Image blackout;

    private void Awake()
    {
        fade.gameObject.SetActive(true);
    }

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        dialoguesController = FindObjectOfType<DialoguesController>();
    }
}
