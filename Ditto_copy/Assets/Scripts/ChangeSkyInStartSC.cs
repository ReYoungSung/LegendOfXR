using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyInStartSC : MonoBehaviour
{
    [SerializeField] private GameObject skyBox;
    private Transform SkyBoxTransform; 

    private float moveSpeed = 20f;
    [SerializeField] private Transform targetTransform;

    [SerializeField] private GameObject[] Particle1;
    [SerializeField] private GameObject[] Particle2;
    [SerializeField] private GameObject[] Particle3;
    [SerializeField] private GameObject[] Particle4;
    [SerializeField] private GameObject[] Particle5;
    [SerializeField] private GameObject[] Particle6;
    [SerializeField] private GameObject Particle8;
    [SerializeField] private GameObject Particle9;
    [SerializeField] private GameObject Particle10;

    

    // Start is called before the first frame update
    void Start() 
    {
        SkyBoxTransform = skyBox.transform;
        StartCoroutine(ChangeSky());
        StartCoroutine(CineStartFlow());
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

    private IEnumerator CineStartFlow() 
    {
        yield return new WaitForSeconds(18f); 
         
        for(int i = 0; i < Particle1.Length; i++)
        {
            Particle1[i].SetActive(true);
        }

        yield return new WaitForSeconds(15f); 
    for(int i = 0; i < Particle2.Length; i++)
        {
            Particle2[i].SetActive(true);
        }

        yield return new WaitForSeconds(15f); 
        for(int i = 0; i < Particle3.Length; i++)
        {
            Particle3[i].SetActive(true);
        }

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
