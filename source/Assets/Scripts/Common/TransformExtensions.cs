using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    public static IEnumerator Bump(this Transform transform, float resize)
    {
        Vector3 sizeble = new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);

        Vector3 originalSize = transform.localScale;
        Vector3 localScale = transform.localScale;

        for (float time = 1; time < resize; time += Time.deltaTime)
        {
            localScale += sizeble;
            transform.localScale = localScale;

            yield return 0;
        }

        for (float time = resize; time > 1; time -= Time.deltaTime)
        {
            localScale -= sizeble;
            transform.localScale = localScale;

            yield return 0;
        }

        transform.localScale = originalSize;
    }
}