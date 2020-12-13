using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{

    public int countdownTimeS;
    public Slider slider;

    private void OnEnable()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        var time = 0f;
        var timeMultiplayer = slider.maxValue / countdownTimeS;
        while (time <= countdownTimeS + 1)
        {
            slider.value = time++ * timeMultiplayer;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
