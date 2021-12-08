using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnailBarController : MonoBehaviour
{
    public Slider slider;
    public GameObject snailBar;

    public void EnableSnailBar()
    {
        snailBar.SetActive(true);
    }

    public void SetSnailBarTimer(int time)
    {
        slider.maxValue = time;
        slider.value = time;
        StartCoroutine(StartCountDownTimer(time));
    }

    public IEnumerator StartCountDownTimer(int time)
    {
        slider.maxValue = time;
        slider.value = time;
        for (int i = time; i >= 0; i--)
        {
            slider.value = i; ;
            yield return new WaitForSeconds(1f);
        }
        snailBar.SetActive(false);
    }
}
