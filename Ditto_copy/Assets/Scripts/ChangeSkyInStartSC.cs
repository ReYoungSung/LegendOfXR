using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyInStartSC : MonoBehaviour
{
    [SerializeField] private GameObject skyBox;
    private Transform SkyBoxTransform; 

    private float moveSpeed = 20f;
    [SerializeField] private Transform targetTransform;


    

    // Start is called before the first frame update
    void Start() 
    {
        SkyBoxTransform = skyBox.transform;
        StartCoroutine(ChangeSky());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeSky() 
    {
        yield return new WaitForSeconds(8.3f);
        skyBox.SetActive(true);
        MoveXRScreenToTargetPosition();  
    }


    // XRScreen�� ��ǥ ��ġ�� õõ�� �̵��ϴ� �޼���
    public void MoveXRScreenToTargetPosition()
    {
        StartCoroutine(MoveToTargetPosition(targetTransform.position));
    }

    private IEnumerator MoveToTargetPosition(Vector3 target)
    {
        float journeyLength = Vector3.Distance(SkyBoxTransform.position, target);
        float startTime = Time.time;

        while (SkyBoxTransform.position != target)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            SkyBoxTransform.position = Vector3.Lerp(SkyBoxTransform.position, target, fractionOfJourney);

            yield return null;
        }
    }
}
