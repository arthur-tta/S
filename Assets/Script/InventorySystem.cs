using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreenUI;
    public bool isOpen { private set; get; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        isOpen = false;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B) && !isOpen)
        {

            Debug.Log("open the bag");
            inventoryScreenUI.SetActive(true);
            isOpen = true;

            Cursor.lockState = CursorLockMode.None;


        }
        else if (Input.GetKeyDown(KeyCode.B) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            isOpen = false;

            Cursor.lockState = CursorLockMode.Locked;

        }
    }

}