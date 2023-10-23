using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavButtonOn2 : MonoBehaviour
{

    private Transform target = null;

    [SerializeField] private GameObject navArrow;
    [SerializeField] private Button onButton;


    private void Start()
    {
        onButton.onClick.AddListener(ActivateNavArrow);

    }

    void Update()
    {
        if (target != null)
        {
            // Rotate the navigation arrow towards the target.
            navArrow.transform.LookAt(target.position);
        }
    }


    public void ActivateNavArrow()
    {
        navArrow.SetActive(true);
    }


}
