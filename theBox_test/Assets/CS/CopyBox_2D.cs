using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBox_2D : MonoBehaviour
{
    public Transform targetBox;
    public int TargetRotation;  // x = targetbox's x y z (0, 1, 2)
    //public int TransToRotation; // y = selftransfer x y z (0, 1, 2)
    public FaceUp faceup;
    // Start is called before the first frame update
    void Start()
    {
        faceup = GameObject.FindGameObjectWithTag("Cube").GetComponent<FaceUp>();
        GetCorrectionEuler();
    }

    void GetCorrectionEuler()
    {
        switch (faceup.DiceValue_Front)
        {
            case 1:
                switch (faceup.DiceValue_Up)
                {
                    case 5:
                        CorrectionEuler = 0;
                        break;
                    case 3:
                        CorrectionEuler = -90;
                        break;
                    case 4:
                        CorrectionEuler = -270;
                        break;
                    case 2:
                        CorrectionEuler = -180;
                        break;
                    default:
                        break;
                }
                break;

            case 2:
                switch (faceup.DiceValue_Up)
                {
                    case 1:
                        CorrectionEuler = 0;
                        break;
                    case 3:
                        CorrectionEuler = -90;
                        break;
                    case 4:
                        CorrectionEuler = -270;
                        break;
                    case 6:
                        CorrectionEuler = -180;
                        break;
                    default:
                        break;
                }
                break;

            case 3:
                switch (faceup.DiceValue_Up)
                {
                    case 1:
                        CorrectionEuler = 0;
                        break;
                    case 5:
                        CorrectionEuler = -90;
                        break;
                    case 2:
                        CorrectionEuler = -270;
                        break;
                    case 6:
                        CorrectionEuler = -180;
                        break;
                    default:
                        break;
                }
                break;

            case 4:
                switch (faceup.DiceValue_Up)
                {
                    case 1:
                        CorrectionEuler = 0;
                        break;
                    case 2:
                        CorrectionEuler = -90;
                        break;
                    case 5:
                        CorrectionEuler = -270;
                        break;
                    case 6:
                        CorrectionEuler = -180;
                        break;
                    default:
                        break;
                }
                break;

            case 5:
                switch (faceup.DiceValue_Up)
                {
                    case 1:
                        CorrectionEuler = 0;
                        break;
                    case 4:
                        CorrectionEuler = -90;
                        break;
                    case 3:
                        CorrectionEuler = -270;
                        break;
                    case 6:
                        CorrectionEuler = -180;
                        break;
                    default:
                        break;
                }
                break;

            case 6:
                switch (faceup.DiceValue_Up)
                {
                    case 2:
                        CorrectionEuler = 0;
                        break;
                    case 3:
                        CorrectionEuler = -90;
                        break;
                    case 4:
                        CorrectionEuler = -270;
                        break;
                    case 5:
                        CorrectionEuler = -180;
                        break;
                    default:
                        break;
                }
                break;

            default:
                break;
        }
    }

    int upv = -1;
    int frv = -1;

    bool isTurning = false;
    public Quaternion Origin_Rotation;
    public Quaternion Target_Rotation;
    int CorrectionEuler;
    float TransTimer = 0;
    float TransTime = 0.6f;
    float Gravity_Scale = 13;

    public Rigidbody2D[] ObjectUsesGravity;

    public bool method2 = true; // DELETE THIS TO RESTORE IT'S GLORY!!!!!

    // Update is called once per frame
    void Update()
    {
        if (method2)
        {
            switch (faceup.DiceValue_Front)
            {
                case 1:
                    this.transform.rotation = Quaternion.Euler(0, 0, faceup.gameObject.transform.eulerAngles.y);
                    break;

                case 2:
                    this.transform.rotation = Quaternion.Euler(0, 0, -faceup.gameObject.transform.eulerAngles.z);
                    break;

                case 3:
                    this.transform.rotation = Quaternion.Euler(0, 0, faceup.gameObject.transform.eulerAngles.x);
                    break;

                case 4:
                    this.transform.rotation = Quaternion.Euler(0, 0, -faceup.gameObject.transform.eulerAngles.x);
                    break;

                case 5:
                    this.transform.rotation = Quaternion.Euler(0, 0, faceup.gameObject.transform.eulerAngles.z);
                    break;

                case 6:
                    this.transform.rotation = Quaternion.Euler(0, 0, -faceup.gameObject.transform.eulerAngles.y);
                    break;

                default:
                    break;
            }
        }

        #region Old
        /*else if (upv != faceup.DiceValue_Up && !isTurning)
        {
            if (faceup.DiceValue_Front == 2 && faceup.DiceValue_Up != -1)
            {
                upv = faceup.DiceValue_Up;
                switch (faceup.DiceValue_Up)
                {
                    case 1: //0
                        Origin_Rotation = this.transform.rotation;
                        Target_Rotation = Quaternion.Euler(0, 0, 0 + CorrectionEuler);
                        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 3: //90
                        Origin_Rotation = this.transform.rotation;
                        Target_Rotation = Quaternion.Euler(0, 0, 90 + CorrectionEuler);
                        //this.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case 4: //270
                        Origin_Rotation = this.transform.rotation;
                        Target_Rotation = Quaternion.Euler(0, 0, 270 + CorrectionEuler);
                        //this.transform.rotation = Quaternion.Euler(0, 0, 270);
                        break;
                    case 6: //180
                        Origin_Rotation = this.transform.rotation;
                        Target_Rotation = Quaternion.Euler(0, 0, 180 + CorrectionEuler);
                        //this.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    default:
                        break;
                }
                CloseGravity();
                isTurning = true;
            }
        }*/
        #endregion

        if (isTurning)
        {
            TransTimer += Time.deltaTime;
            this.transform.rotation = Quaternion.Lerp(Origin_Rotation, Target_Rotation, (TransTimer / TransTime));
            if (TransTimer >= TransTime)
            {
                isTurning = false;
                OpenGravity();
                TransTimer = 0;
            }
        }

        if (frv != faceup.DiceValue_Front)
        {
            frv = faceup.DiceValue_Front;
        }
    }

    public void CloseGravity()
    {
        foreach (Rigidbody2D rig in ObjectUsesGravity)
        {
            rig.gravityScale = 0;
            rig.velocity = Vector2.zero;
        }
    }

    public void OpenGravity()
    {
        foreach (Rigidbody2D rig in ObjectUsesGravity)
        {
            rig.gravityScale = Gravity_Scale;
        }
    }
}
