using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text clocktext;

    public int Duration;

    private int remaningDuration;
    private void Start()
    {
        Begin(Duration);
    }

    // Update is called once per frame
    private void Begin(int Second)
    {
        remaningDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while (remaningDuration >= 0)
        {
            clocktext.text = $"{remaningDuration / 60:00}:{remaningDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remaningDuration);
            remaningDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }
    private void OnEnd() 
    {
        print("End");
    }
}
