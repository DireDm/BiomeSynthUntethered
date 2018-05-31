using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class PlayerScript : MonoBehaviour {

	public bool launchOculus, launchVive;
	public Transform leftPalm;
	public Transform rightPalm;
	public WindZone wind;
	void Start () {
		VRTK_SDKManager m = gameObject.AddComponent(typeof(VRTK_SDKManager)) as VRTK_SDKManager;
		m.scriptAliasLeftController = transform.Find("[VRTK_Scripts]").Find("LeftController").gameObject;
		m.scriptAliasRightController = transform.Find("[VRTK_Scripts]").Find("RightController").gameObject;
		m.autoLoadSetup = false;
		VRTK_SDKSetup[] list = {transform.Find("OculusVR").GetComponent<VRTK_SDKSetup>(), transform.Find("SteamVR").GetComponent<VRTK_SDKSetup>()};
		int index = (launchOculus) ? 0 : ((launchVive) ? 1 : -1);
		m.TryLoadSDKSetup(index, true, list);
		m.scriptAliasLeftController.GetComponent<VRTK_ControllerEvents>().enabled = true;
		m.scriptAliasRightController.GetComponent<VRTK_ControllerEvents>().enabled = true;
	}
	// Update is called once per frame
	void Update () {
		wind.transform.eulerAngles = new Vector3(0f, (rightPalm.transform.position.y-1)*360, 0f);
	}
}
