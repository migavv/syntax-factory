using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightAnimator : MonoBehaviour
{
    public Image highlightImage; // Reference to the Image component for the highlight animation
    public Color startColor = Color.clear; // The starting color (e.g., fully transparent)
    public Color endColor = Color.yellow;  // The ending color (highlight color)
    public float animationDuration = 1.0f; // Duration of one color change cycle
    public int pulseCount = 3; // Number of times the color changes

    private Color originalColor; // To store the original color of the image

     // Event to notify when the pulsing effect is finished
    public delegate void AnimationFinished();
    public event AnimationFinished OnAnimationFinished;

    void Start()
    {
        if (highlightImage == null)
        {
            Debug.LogError("Highlight Image is not assigned. Please assign an Image component.");
            return;
        }

        // Store the original color of the image
        originalColor = highlightImage.color;

        // Start the pulsing animation
      //  StartHighlightAnimation();
    }
      public void StartHighlightAnimation()
    {
        StartCoroutine(PulseHighlight());
    }

    private IEnumerator PulseHighlight()
    {
        int currentPulse = 0;

        while (currentPulse < pulseCount)
        {
            // Animate from startColor to endColor
            yield return StartCoroutine(ChangeColor(startColor, endColor, animationDuration / 2));

            // Animate back from endColor to startColor
            yield return StartCoroutine(ChangeColor(endColor, startColor, animationDuration / 2));

            currentPulse++;
        }

        // Ensure the color is set back to the original color at the end
        highlightImage.color = originalColor;
        // Trigger the animation finished event
        OnAnimationFinished?.Invoke();
    }

    private IEnumerator ChangeColor(Color fromColor, Color toColor, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // Lerp the color over time
            highlightImage.color = Color.Lerp(fromColor, toColor, elapsedTime / duration);
            yield return null;
        }
        // Ensure the color is set to the final value
        highlightImage.color = toColor;
    }
}