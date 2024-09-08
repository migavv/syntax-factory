using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import for TextMeshPro

public class TextBubbleController : MonoBehaviour
{
    public GameObject textBubble; // Reference to the text bubble panel
    public TextMeshProUGUI bubbleText; // Reference to the TextMeshPro component for the bubble text
    public HighlightAnimator highlightAnimator; // Reference to the HighlightAnimator component

    void Start()
    {
        if (highlightAnimator == null)
        {
            Debug.LogError("HighlightAnimator is not assigned. Please assign the HighlightAnimator component.");
            return;
        }

        // Ensure the text bubble is initially active
        textBubble.SetActive(true);


        // Subscribe to the highlight animation finished event
        highlightAnimator.OnAnimationFinished += HideBubble;
    }

    void HideBubble()
    {
        textBubble.SetActive(false);
    }
}
