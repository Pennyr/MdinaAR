using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{

    private CanvasGroup group;


    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }


    IEnumerator FadeFromTo(float from, float to)
    {
        var curve = new AnimationCurve(new Keyframe[] 
        {
            new Keyframe(0f, from),
            new Keyframe(1f, to)
        });

        float time = 0f;

        while (time < 1f)
        {
            @group.alpha = curve.Evaluate(time);
            time += Time.deltaTime;

            yield return null;
        }

        // Ensure that alpha is set to the t=1 value
        @group.alpha = curve.Evaluate(1f);
        

    }

    void OnEnable()
    {
        StartCoroutine(FadeFromTo(0, 1f));
        //Debug.Log("PrintOnEnable: script was enabled");
    }
}
