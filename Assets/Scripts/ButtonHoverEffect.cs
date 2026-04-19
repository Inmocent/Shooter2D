using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for detecting mouse hover

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    public Color hoverColor = new Color(1f, 1f, 1f, 0.7f); // Slightly transparent/brighter
    private Color originalColor;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }

    // Runs when mouse enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor;
    }

    // Runs when mouse leaves the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = originalColor;
    }
}