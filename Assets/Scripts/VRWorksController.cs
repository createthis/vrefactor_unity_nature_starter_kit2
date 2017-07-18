using System;
using UnityEngine;
using NVIDIA;

public class VRWorksController : MonoBehaviour {
    [Flags]
    public enum Features {
        // Default rendering
        None = VRWorks.Feature.None,
        // MRS
        MultiResolution = VRWorks.Feature.MultiResolution,
        // SPS
        SinglePassStereo = VRWorks.Feature.SinglePassStereo,
        // LMS
        LensMatchedShading = VRWorks.Feature.LensMatchedShading,
    };

    public bool enable;
    public VRWorks vrworks;
    [BitMask(typeof(Features))]
    public Features features;

    public static bool IsFlagSet(Enum value, Enum flag) {
        long lValue = Convert.ToInt64(value);
        long lFlag = Convert.ToInt64(flag);
        return (lValue & lFlag) != 0;
    }

    private void EnableVRWorksFeatures() {
        foreach (VRWorks.Feature value in VRWorks.Feature.GetValues(features.GetType())) {
            if (IsFlagSet(features, value)) {
                vrworks.SetActiveFeature(value);
            }
        }
    }

	// Use this for initialization
	void Start () {
        if (enable) EnableVRWorksFeatures();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
