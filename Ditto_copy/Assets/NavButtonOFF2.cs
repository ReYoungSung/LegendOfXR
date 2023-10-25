using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class NavButtonOFF2 : MonoBehaviour

{    
    private Transform target = null;
    
    [SerializeField] private GameObject navArrow;
    [SerializeField] private Button offButton;

    private void Start()
    {
        offButton.onClick.AddListener(DeactivateNavArrow);
    }

    void Update()
    {
        if (target != null)
        {
            // Rotate the navigation arrow towards the target.
            navArrow.transform.LookAt(target.position);
        }
    }


    public void DeactivateNavArrow()
    {
        navArrow.SetActive(false);
    }
}
