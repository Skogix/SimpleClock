using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
	public Transform hoursTransform,
									 minutesTransform,
									 secondsTransform;
	const float degreesPerHour = 30f,
							degreesPerMinute = 6f,
							degreesPerSecond = 6f;
	public bool continuous;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			continuous = !continuous;
		}

		if (continuous)
		{
			UpdateContinous();
		} else
		{
			UpdateDiscrete();
		}
	}
	// För att få fractional data så använda timeofday och
	// downcasta till float
	private void UpdateContinous()
	{
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation = 
			Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
	}
	private void UpdateDiscrete()
	{
		DateTime time = DateTime.Now;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
	}
}