using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    // lets us add an image and and animationcurve in the inspector
    public Image img;
    public AnimationCurve curve;

    // starts the ienumerator fadein
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // runs the ienumerator fadeto
    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    // changes the alpha channel from 1 to 0 to fade into the scene
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    // changes the alpha channel from 0 to 1 to fade out of the scene
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

}
