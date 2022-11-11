// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// Clock Class
//This code handles the keeping of time and movement of clock hands
//This code also displays the time next to the clock
//The class triggers the lose screen if the player does not reach the goal when the clock reaches the goal time

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Clock : MonoBehaviour
{
    public float secondsPerDay = 60f;
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    public Image hourHand;
    public Image minuteHand;
    public float dayEnd;
    private Text timeText;

    public float day;



	private void Awake()
    {
        clockHourHandTransform = transform.Find("HourHand");
        clockMinuteHandTransform = transform.Find("MinuteHand");
        timeText = transform.Find("timeText").GetComponent<Text>();

	}
	private void Update()
	{
        day += Time.deltaTime / secondsPerDay;

        float dayNormalized = day % 1f;

        float degreesToRotate = 360f;

        clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * degreesToRotate);

        float hoursPerDay = 12f;

        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * degreesToRotate * hoursPerDay);
        if (day>.35f){
            hourHand.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            minuteHand.GetComponent<Image>().color = new Color32(255, 0, 0, 100);

        }
        string hoursString=Mathf.Floor(dayNormalized*hoursPerDay).ToString("00");
        float minPerHour = 60f;
        string minString = Mathf.Floor(((dayNormalized * hoursPerDay)% 1f) * minPerHour).ToString("00");
        timeText.text = hoursString + ":" + minString;


        if(day>=dayEnd){
            SceneManager.LoadScene("LoseScreen");

        }

	}


}
