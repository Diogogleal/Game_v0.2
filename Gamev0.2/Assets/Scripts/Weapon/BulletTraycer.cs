using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTraycer : MonoBehaviour
{
    public float tracerDuration = 0.1f;
    public LineRenderer lineRenderer;

    private void Start()
    {
        if (lineRenderer == null)
        {
            // Create a Line Renderer component if not already assigned
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Set up the Line Renderer
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.enabled = false; // Initially, the line should be hidden
    }

    public void ShowTracer(Vector3 startPosition, Vector3 endPosition)
    {
        // Clear the previous positions
        lineRenderer.positionCount = 0;

        // Set the start and end positions of the line in world space
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition); // Set the end position initially to start position

        // Show the line
        lineRenderer.enabled = true;

        // Animate the line from the start to the end position over time
        StartCoroutine(MoveLine(endPosition));

        // Hide the line after a short duration
        Invoke("HideTracer", tracerDuration);
    }

    private void HideTracer()
    {
        // Hide the line
        lineRenderer.enabled = false;
    }

    private IEnumerator MoveLine(Vector3 endPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < tracerDuration)
        {
            // Interpolate the line's end position over time
            lineRenderer.SetPosition(1, Vector3.Lerp(lineRenderer.GetPosition(1), endPosition, elapsedTime / tracerDuration));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the line's end position is set to the final position
        lineRenderer.SetPosition(1, endPosition);
    }
}
