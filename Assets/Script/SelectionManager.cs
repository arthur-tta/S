using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }



    [SerializeField] private GameObject interaction_Info_UI;
    private TextMeshProUGUI interaction_Text;


    private Ray ray;
    private RaycastHit hit;
    private Transform selectionTranform;

    private InteractableObject interactable;

    public bool onTarget { private set; get; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        onTarget = false;
        interaction_Text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // selection object
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 5f))
        {
            selectionTranform = hit.transform;

            interactable = selectionTranform.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                interaction_Text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);
                onTarget = true;
            }
            else // if there a hit but not an interactable object
            {
                interaction_Info_UI.SetActive(false);
                onTarget = false;
            }
        }
        else // if there is not hit at all
        {
            interaction_Info_UI.SetActive(false);
            onTarget = false;
        }

        // pick up item
        
        if (Input.GetKeyDown(KeyCode.F) && onTarget)
        {
            interactable.PickUp();
        }
    }
}
