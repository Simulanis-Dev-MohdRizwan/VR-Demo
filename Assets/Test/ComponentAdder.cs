using ReadyPlayerMe.Core;
using ReadyPlayerMe.Samples.QuickStart;
using ReadyPlayerMe.XR;
using RootMotion.FinalIK;
using System;
using UnityEngine;

public class ComponentAdder : MonoBehaviour
{
    public GameObject downloadedAvatart;
    public static Action ComponentAdd;
    public ThirdPersonLoader ThirdPersonLoader;
    //public AvatarComponentReferences AvatarComponentReferences;

    private void OnEnable()
    {
        //ComponentAdd += AddComponents;
        ThirdPersonLoader.OnLoadComplete += AddComponents;
    }

    private void OnDisable()
    {
        ThirdPersonLoader.OnLoadComplete -= AddComponents;
        //ComponentAdd -= AddComponents;
    }

    [ContextMenu("assignComponets")]
    public void AddComponents()
    {
        downloadedAvatart = ThirdPersonLoader.AvatarDownloaded;
        VRIK vrik =  downloadedAvatart.AddComponent<VRIK>();
        TwistRelaxer twistRelaxer= downloadedAvatart.AddComponent<TwistRelaxer>();
        ///twistRelaxer.ik = vrik;

        HeightCalibrator hc =  downloadedAvatart.AddComponent<HeightCalibrator>();
        ArmStretcher armStretcher = downloadedAvatart.AddComponent<ArmStretcher>();
        CapsuleCollider cl = downloadedAvatart.AddComponent<CapsuleCollider>();
        AvatarData ad = downloadedAvatart.GetComponent<AvatarData>();
        Animator animator = downloadedAvatart.GetComponent<Animator>();
        cl.isTrigger = true;
        cl.center = new Vector3(0, 0.9f, 0);
        cl.radius = 0.3f;
        cl.height = 1.8f;
        Rigidbody rb = downloadedAvatart.AddComponent<Rigidbody>();
        rb.mass = 1.0f;
        rb.automaticCenterOfMass = true;
        rb.automaticInertiaTensor = true;
        rb.useGravity = true;
        rb.isKinematic = true;

        downloadedAvatart.tag = "Player";

        AvatarComponentReferences.Instance.HeightCalibrator = hc;

        AvatarComponentReferences.Instance.AvatarData = ad;

        AvatarComponentReferences.Instance.Vrik = vrik;

        AvatarComponentReferences.Instance.Animator = animator;

    }
}
