using System.Collections;
using UnityEngine;

public class LerpingScript : MonoBehaviour
{
    public float lerpDuration = 3;
    public Transform targetCharacter; // Referencja do drugiej postaci

    void Start()
    {
        
        StartCoroutine(Lerp());
    }

    IEnumerator Lerp()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetCharacter.position;

        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition; // Ustaw pozycjê na docelow¹ pozycjê drugiej postaci
    }
}
