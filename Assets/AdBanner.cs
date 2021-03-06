﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdBanner : MonoBehaviour {

	// Use this for initialization
	void Start () {

		ShowBannerAd();

	}

	private void ShowBannerAd()
	{
		//string adID = "ca-app-pub-3940256099942544/6300978111";
		string adID = "ca-app-pub-4288592540157567/3222063597";

		//***For Testing in the Device***
		AdRequest request = new AdRequest.Builder()
//			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
//			.AddTestDevice("8F81DE33520C4C2A7C6EBEBFEB19D011")  // My test device.
			.Build();

		//***For Production When Submit App***
		//AdRequest request = new AdRequest.Builder().Build();

		BannerView bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Bottom);
		bannerAd.LoadAd(request);
	}

	// Update is called once per frame
	void Update () {

	}
}
