using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //左フリッパー
    private const string LEFT_FRIPPER_TAG = "LeftFripperTag";
    //右フリッパー
    private const string RIGHT_FRIPPER_TAG = "RightFripperTag";

    // Use this for initialization
    void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle, tag);
    }

    // Update is called once per frame
    void Update () {
        InputTouch ();
        InputMouse ();
        InputKeyboard ();
    }

    void InputTouch(){
        for(int i=0 ; i<Input.touchCount; i++){
            Debug.Log ("touch position x = " + Input.touches [i].position.x);
            Touch touch = Input.GetTouch (i);
            if (touch.position.x > Screen.width * 0.5f) {
                //右側判定
                SetAngle (this.flickAngle, RIGHT_FRIPPER_TAG);
            } else {
                //左側判定
                SetAngle (this.flickAngle, LEFT_FRIPPER_TAG);
            }

            switch (touch.phase) {
                case TouchPhase.Began:
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    break;
                default:
                    if (this.myHingeJoint.spring.targetPosition != defaultAngle) {
                        SetAngle (this.defaultAngle, tag);
                    }
                    break;
            }
        }
    }

    void InputMouse(){
        
        if (Input.GetMouseButtonDown(0)) {
            if (Input.mousePosition.x > Screen.width * 0.5f) {
                //右側判定
                SetAngle (this.flickAngle, RIGHT_FRIPPER_TAG);
            } else {
                //左側判定
                SetAngle (this.flickAngle, LEFT_FRIPPER_TAG);
            }
        }
        if (Input.GetMouseButtonUp (0)) {
            if(this.myHingeJoint.spring.targetPosition != defaultAngle){
                SetAngle (this.defaultAngle, tag);
            }
        }
    }

    void InputKeyboard(){
        
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetAngle (this.flickAngle, LEFT_FRIPPER_TAG);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SetAngle (this.flickAngle, RIGHT_FRIPPER_TAG);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            SetAngle (this.defaultAngle, LEFT_FRIPPER_TAG);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            SetAngle (this.defaultAngle, RIGHT_FRIPPER_TAG);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle, string targetTag){
        if (tag == targetTag) {
            JointSpring jointSpr = this.myHingeJoint.spring;
            jointSpr.targetPosition = angle;
            this.myHingeJoint.spring = jointSpr;
        }
    }
}