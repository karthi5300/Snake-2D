using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShieldBarController : MonoBehaviour
{

    public Slider slider;
    public GameObject shieldBar;

    public void EnableSnailBar()
    {
        shieldBar.SetActive(true);
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
        shieldBar.SetActive(false);
    }
}