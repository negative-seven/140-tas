using System;
using System.Collections.Generic;
using UnityEngine;

public partial class GlobalBeatMaster : MonoBehaviour
{
	private void Update()
	{
		if (!this.beatStarted)
		{
			this.startBeatTimer -= Time.deltaTime;
			if (this.startBeatTimer > 0f)
			{
				return;
			}
			this.beatStarted = true;
			this.masterLoop.Play();
			if (this.globalBeatStarted != null)
			{
				this.globalBeatStarted();
			}
		}
		float num = this.masterLoop.time;
		float num2 = num - this.old_looptime;
		if (num2 < 0f)
		{
			num2 += this.masterLoop.clip.length;
		}
		this.time += Time.deltaTime; // Modified line
		Globals.musicTimeSinceLevelLoad = this.time;
		this.beatTimer -= Time.deltaTime; // Modified line
		if (this.beatTimer < 0f)
		{
			this.hit();
			this.beatTimer += this.masterLoop.clip.length / 64f;
		}
		this.highResBeatTimer -= Time.deltaTime; // Modified line
		if (this.highResBeatTimer < 0f)
		{
			if (this.onHighResBeat != null)
			{
				this.onHighResBeat();
			}
			this.highResBeatTimer += this.masterLoop.clip.length / 64f;
		}
		this.old_looptime = num;
	}
}
