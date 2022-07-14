using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start ()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update ()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)) && tag == "LeftFripperTag")
        {
            SetAngle (this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))&& tag == "RightFripperTag")
        {
            SetAngle (this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S)) && tag == "LeftFripperTag")
        {
            SetAngle (this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.S)) && tag == "RightFripperTag")
        {
            SetAngle (this.defaultAngle);
        }

        //画面のタッチでフリッパーを動かす
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            //Touch touch1 = Input.GetTouch(1);

            //　画面の右側をタッチされた時
            if (touch.phase == TouchPhase.Began)
            {
                if (Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle (this.flickAngle);
                }
                if (Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle (this.flickAngle);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            print("xの境界は；" + Screen.width / 2);
            print("touchは；" + touch.position.x);
            print("touch1は；" + touch1.position.x);

            //　画面の右側をタッチされた時
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle (this.flickAngle);
                    print("touchは右");
                }
                if (touch.position.x <= Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle (this.flickAngle);
                    print("touchは左");
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
            }

            if (touch1.phase == TouchPhase.Began)
            {
                if (touch1.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle (this.flickAngle);
                    print("touch１は右");
                }
                if (touch1.position.x <= Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle (this.flickAngle);
                    print("touch１は左");
                }
            }
            else if (touch1.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}