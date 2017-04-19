using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {

  public bool cursorVisible;

  void Awake ()
  {
    Cursor.visible = cursorVisible;
  }
}
