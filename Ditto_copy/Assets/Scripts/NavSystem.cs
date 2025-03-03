using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavSystem : MonoBehaviour
{
    [SerializeField] private Transform target1; 
    [SerializeField] private Transform target2;
    [SerializeField] private Transform target3;
    [SerializeField] private Transform target4;
    [SerializeField] private Transform target5;
    [SerializeField] private Transform target6;
    [SerializeField] private Transform target7;

    private Transform target = null;

    [SerializeField] private GameObject navArrow;

    void Update()
    {
        if (target != null)
        {
            // 현재 객체(this)를 목표물을 향하도록 회전시킵니다.
            navArrow.transform.LookAt(target.position);
        }
    }

    public void selectNavTarget(int UISelectNum = 0)
    {
        if(UISelectNum == 0) 
        {
            return;
        }
        else if(UISelectNum == 1) 
        {
            target = target1;
        }
        else if(UISelectNum == 2)
        {
            target = target2;
        }
        else if(UISelectNum == 3)
        {
            target = target3;
        }
        else if(UISelectNum == 4)
        {
            target = target4;
        }
        else if(UISelectNum == 5)
        {
            target = target5;
        }
        else if(UISelectNum == 6)
        {
            target = target6;
        }

        else if( UISelectNum == 7)
        {
            target = target7;
        }
    }

    public void ActiveNavArrow(bool activeButton)
    {
        navArrow.SetActive(activeButton);

    } 
}
