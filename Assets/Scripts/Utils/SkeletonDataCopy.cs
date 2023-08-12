using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkeletonDataCopy : MonoBehaviour {

    [Tooltip("Original Skeleton")]

    public GameObject[] OriginalLimbs;


    public GameObject Original_Hips;
    public GameObject Original_Spine;
    public GameObject Original_Head;

    public GameObject Original_ArmLeft;
    public GameObject Original_ForearmLeft;
    public GameObject Original_HandLeft;
    public GameObject Original_ArmRight;
    public GameObject Original_ForearmRight;
    public GameObject Original_HandRight;

    public GameObject Original_UpLegLeft;
    public GameObject Original_LegLeft;
    public GameObject Original_FootLeft;
    public GameObject Original_UpLegRight;
    public GameObject Original_LegRight;
    public GameObject Original_FootRight;

    [Tooltip("New Skeleton")]

    public GameObject[] NewLimbs;


    public GameObject New_Hips;
    public GameObject New_Spine;
    public GameObject New_Head;

    public GameObject New_ArmLeft;
    public GameObject New_ForearmLeft;
    public GameObject New_HandLeft;
    public GameObject New_ArmRight;
    public GameObject New_ForearmRight;
    public GameObject New_HandRight;

    public GameObject New_UpLegLeft;
    public GameObject New_LegLeft;
    public GameObject New_FootLeft;
    public GameObject New_UpLegRight;
    public GameObject New_LegRight;
    public GameObject New_FootRight;

    private int Arms = 6;
    private int WOFeet = 10;
    private int Limbs = 12;
    private int All = 15;

    [ContextMenu("CopySkeletonData")]
    public void CopySkeletonData() {

        OriginalLimbs = new GameObject[All];

        OriginalLimbs[0] = Original_ArmLeft;
        OriginalLimbs[1] = Original_ForearmLeft;
        OriginalLimbs[2] = Original_HandLeft;
        OriginalLimbs[3] = Original_ArmRight;
        OriginalLimbs[4] = Original_ForearmRight;
        OriginalLimbs[5] = Original_HandRight;

        OriginalLimbs[6] = Original_UpLegLeft;
        OriginalLimbs[7] = Original_LegLeft;
        OriginalLimbs[8] = Original_UpLegRight;
        OriginalLimbs[9] = Original_LegRight;

        OriginalLimbs[10] = Original_FootLeft;
        OriginalLimbs[11] = Original_FootRight;

        OriginalLimbs[12] = Original_Hips;
        OriginalLimbs[13] = Original_Spine;
        OriginalLimbs[14] = Original_Head;

        NewLimbs = new GameObject[All];

        NewLimbs[0] = New_ArmLeft;
        NewLimbs[1] = New_ForearmLeft;
        NewLimbs[2] = New_HandLeft;
        NewLimbs[3] = New_ArmRight;
        NewLimbs[4] = New_ForearmRight;
        NewLimbs[5] = New_HandRight;

        NewLimbs[6] = New_UpLegLeft;
        NewLimbs[7] = New_LegLeft;
        NewLimbs[8] = New_UpLegRight;
        NewLimbs[9] = New_LegRight;

        NewLimbs[10] = New_FootLeft;
        NewLimbs[11] = New_FootRight;

        NewLimbs[12] = New_Hips;
        NewLimbs[13] = New_Spine;
        NewLimbs[14] = New_Head;


        EditorUtility.CopySerialized(Original_Hips.GetComponent<BoxCollider>(), New_Hips.AddComponent<BoxCollider>());
        EditorUtility.CopySerialized(Original_Spine.GetComponent<BoxCollider>(), New_Spine.AddComponent<BoxCollider>());
        EditorUtility.CopySerialized(Original_Head.GetComponent<SphereCollider>(), New_Head.AddComponent<SphereCollider>());

        for (int i = 0; i < WOFeet; i++) {
            EditorUtility.CopySerialized(OriginalLimbs[i].GetComponent<CapsuleCollider>(), NewLimbs[i].AddComponent<CapsuleCollider>());
        }

        EditorUtility.CopySerialized(OriginalLimbs[10].GetComponentInChildren<CapsuleCollider>(), NewLimbs[8].AddComponent<CapsuleCollider>());
        EditorUtility.CopySerialized(OriginalLimbs[11].GetComponentInChildren<CapsuleCollider>(), NewLimbs[11].AddComponent<CapsuleCollider>());


        for (int i = 0; i < All; i++) {
            EditorUtility.CopySerialized(OriginalLimbs[i].GetComponent<Rigidbody>(), NewLimbs[i].AddComponent<Rigidbody>());
        }

        EditorUtility.CopySerialized(Original_Spine.GetComponent<CharacterJoint>(), New_Spine.AddComponent<CharacterJoint>());
        New_Spine.GetComponent<CharacterJoint>().connectedBody = New_Hips.GetComponent<Rigidbody>();
        EditorUtility.CopySerialized(Original_Head.GetComponent<CharacterJoint>(), New_Head.AddComponent<CharacterJoint>());
        New_Spine.GetComponent<CharacterJoint>().connectedBody = New_Spine.GetComponent<Rigidbody>();

        for (int i = 0; i < Limbs; i++) {
            EditorUtility.CopySerialized(OriginalLimbs[i].GetComponent<CharacterJoint>(), NewLimbs[i].AddComponent<CharacterJoint>());
            NewLimbs[i].GetComponent<CharacterJoint>().connectedBody = New_Hips.GetComponent<Rigidbody>();
        }



        for (int i = 0; i < All; i++) {
            EditorUtility.CopySerialized(OriginalLimbs[i].GetComponent<RagdollPart>(), NewLimbs[i].AddComponent<RagdollPart>());
        }

    } 

}
