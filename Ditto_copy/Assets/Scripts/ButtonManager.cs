using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button screenOnButton, bookshelfOnButton, cmsOnButton, lightOnButton, allOnButton;
    public Button screenOffButton, bookshelfOffButton, cmsOffButton, lightOffButton, allOffButton;

    private Color defaultColor = Color.white;

    private void Start()
    {
            // Off buttons are colored red by default
        ChangeButtonColor(screenOffButton, Color.red);
        ChangeButtonColor(bookshelfOffButton, Color.red);
        ChangeButtonColor(cmsOffButton, Color.red);

        // On buttons are colored green by default
        ChangeButtonColor(lightOnButton, Color.green);

        // All buttons are in their default color (white)
        ChangeButtonColor(allOnButton, defaultColor);
        ChangeButtonColor(allOffButton, Color.red);
        // 각 버튼의 클릭 이벤트에 함수를 연결
        screenOnButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(screenOnButton, Color.green);
            ChangeButtonColor(screenOffButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });
        
        bookshelfOnButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(bookshelfOnButton, Color.green);
            ChangeButtonColor(bookshelfOffButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        cmsOnButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(cmsOnButton, Color.green);
            ChangeButtonColor(cmsOffButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        lightOnButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(lightOnButton, Color.green);
            ChangeButtonColor(lightOffButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        allOnButton.onClick.AddListener(() => 
        {
            ChangeAllOnButtonsColor();
            ChangeAllOffButtonsToDefaultColor();
        });

        screenOffButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(screenOffButton, Color.red);
            ChangeButtonColor(screenOnButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        bookshelfOffButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(bookshelfOffButton, Color.red);
            ChangeButtonColor(bookshelfOnButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        cmsOffButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(cmsOffButton, Color.red);
            ChangeButtonColor(cmsOnButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        lightOffButton.onClick.AddListener(() => 
        {
            ChangeButtonColor(lightOffButton, Color.red);
            ChangeButtonColor(lightOnButton, defaultColor);
            ChangeButtonColor(allOnButton, defaultColor);
            ChangeButtonColor(allOffButton, Color.red);
        });

        allOffButton.onClick.AddListener(() => 
        {
            ChangeAllOffButtonsColor();
            ChangeAllOnButtonsToDefaultColor();
        });
    }

    private void ChangeButtonColor(Button btn, Color color)
    {
        btn.GetComponent<Image>().color = color;
    }

    private void ChangeAllOnButtonsColor()
    {
        ChangeButtonColor(allOnButton, Color.green);
        ChangeButtonColor(screenOnButton, Color.green);
        ChangeButtonColor(bookshelfOnButton, Color.green);
        ChangeButtonColor(cmsOnButton, Color.green);
        ChangeButtonColor(lightOffButton, Color.red);
    }

    private void ChangeAllOffButtonsColor()
    {
        ChangeButtonColor(allOffButton, Color.red);
        ChangeButtonColor(screenOffButton, Color.red);
        ChangeButtonColor(bookshelfOffButton, Color.red);
        ChangeButtonColor(cmsOffButton, Color.red);
        ChangeButtonColor(lightOnButton, Color.green);
    }

    private void ChangeAllOnButtonsToDefaultColor()
    {
        ChangeButtonColor(screenOnButton, defaultColor);
        ChangeButtonColor(bookshelfOnButton, defaultColor);
        ChangeButtonColor(cmsOnButton, defaultColor);
        ChangeButtonColor(lightOffButton, defaultColor);
        ChangeButtonColor(allOnButton, defaultColor);
    }

    private void ChangeAllOffButtonsToDefaultColor()
    {
        ChangeButtonColor(screenOffButton, defaultColor);
        ChangeButtonColor(bookshelfOffButton, defaultColor);
        ChangeButtonColor(cmsOffButton, defaultColor);
        ChangeButtonColor(lightOnButton, defaultColor);
        ChangeButtonColor(allOffButton, defaultColor);
    }
}
