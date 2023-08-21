using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    public IKTargetFollowVRRig[] ikScripts; // Assign the IKTargetFollowVRRig scripts from GameObjects here
    
    private int currentActiveIndex = 0;

    private void Start()
    {
        DisableAllScripts();
        EnableScript(currentActiveIndex);
    }

    private void Update()
    {
        // Check for spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisableScript(currentActiveIndex);
            currentActiveIndex = (currentActiveIndex + 1) % ikScripts.Length;
            EnableScript(currentActiveIndex);
        }
    }

    private void EnableScript(int index)
    {
        ikScripts[index].enabled = true;
    }

    private void DisableScript(int index)
    {
        ikScripts[index].enabled = false;
        //이전 캐릭터 돌아갈 위치 설정
    }

    private void DisableAllScripts()
    {
        foreach (var script in ikScripts)
        {
            script.enabled = false;
        }
    }
}
