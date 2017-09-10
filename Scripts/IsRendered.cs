using UnityEngine;
using System.Collections;

public class IsRendered : MonoBehaviour {

  //メインカメラに付いているタグ名
  private const string MAIN_CAMERA_TAG_NAME = "MainCamera";

  //カメラに表示されているか
  private bool isRendered = false;

  private void Update () {

    if(isRendered){
      Debug.Log ("カメラに映ってるよ！");
    }

    isRendered = false;
  }

  //カメラに映ってる間に呼ばれる
  private void OnWillRenderObject(){
    //メインカメラに映った時だけisRenderedを有効に
    if(Camera.current.tag == MAIN_CAMERA_TAG_NAME){
      isRendered = true;
    }
  }
  
  public bool getIsRendered() {

  	return isRendered;
  }

}