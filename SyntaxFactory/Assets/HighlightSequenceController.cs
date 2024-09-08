using UnityEngine;

public class HighlightSequenceController : MonoBehaviour
{
    public HighlightAnimator firstHighlightAnimator;  // Reference to the first HighlightAnimator
    public HighlightAnimator secondHighlightAnimator; // Reference to the second HighlightAnimator

    void Start()
    {
        if (firstHighlightAnimator == null || secondHighlightAnimator == null)
        {
            Debug.LogError("HighlightAnimator references are not assigned. Please assign them in the Inspector.");
            return;
        }

        // Subscribe to the event of the first highlight animation ending
        firstHighlightAnimator.OnAnimationFinished += StartSecondHighlightAnimation;

        // Start only the first highlight animation
        firstHighlightAnimator.StartHighlightAnimation();
    }

    void StartSecondHighlightAnimation()
    {
        // Start the second highlight animation when the first one ends
        secondHighlightAnimator.StartHighlightAnimation();
    }
}
