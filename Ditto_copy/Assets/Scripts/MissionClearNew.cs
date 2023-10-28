using UnityEngine;
using UnityEngine.UI;

public class MissionClearNew : MonoBehaviour
{
    private GameManager gameManager;
    public Button button; // Unity Button 컴포넌트로 변경
    public float pressDepth = 0.01f;

    void Awake()
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    }

    void Start()
    {
        // Button 클릭 이벤트 핸들러 연결
        button.onClick.AddListener(OnButtonClicked);
    }

    // Button 클릭 이벤트 핸들러
    void OnButtonClicked()
    {
        AnimateButtonPress();
        gameManager.getFinishCMButton = true;
    }

    void AnimateButtonPress()
    {
        Vector3 newPosition = button.transform.localPosition; // Unity Button 컴포넌트의 transform 사용
        newPosition.y -= pressDepth;
        button.transform.localPosition = newPosition; // Unity Button 컴포넌트의 transform 사용
    }
}
