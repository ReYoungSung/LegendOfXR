using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageChange : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public Image buttonImage;
    public Sprite selectedPressedSprite;

    private Sprite normalSprite;

    private void Start()
    {
        normalSprite = buttonImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the sprite when the mouse pointer enters the button
        buttonImage.sprite = selectedPressedSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Handle button click here
        // You can put your button click logic here
    }

    public void ResetButtonImage()
    {
        // Reset the sprite to the normal state
        buttonImage.sprite = normalSprite;
    }
}
