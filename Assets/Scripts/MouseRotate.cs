//
// drag mouse to rotate on one axis
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
   public bool NormalizeForScreenRes = true;
   public float MouseRotateSpeedMult = 750.0f;
   public float KeyMoveSpeedMult = 300.0f;

   bool _isRotating = false;
   bool _canRotate = true;

   public bool GetIsRotating()
   {
      return _isRotating;

   }

   public void SetCanRotate(bool b) { _canRotate = b; }


   void Update()
   {
      _isRotating = false;

      if (!_canRotate)
      {
         return;
      }

      float moveAmount = 0.0f;
      if(Input.GetMouseButton(0))
      {
         float div = NormalizeForScreenRes ? (float)Screen.width : 1.0f;
         float mouseMoveX = Input.GetAxis("Mouse X") / div;
         //Debug.Log("MOUSE DELTA: " + mouseMoveX);

         moveAmount = (mouseMoveX * Time.deltaTime * MouseRotateSpeedMult);

         _isRotating = true;
      }

      if (Input.GetKey(KeyCode.RightArrow))
      {
         moveAmount = KeyMoveSpeedMult * Time.deltaTime;
         _isRotating = true;
      }
      if (Input.GetKey(KeyCode.LeftArrow))
      {
         moveAmount = -1.0f * KeyMoveSpeedMult * Time.deltaTime;
         _isRotating = true;
      }

      if(_isRotating)
      {
         Vector3 localEuler = this.transform.localEulerAngles;
         localEuler.y += moveAmount;
         this.transform.localEulerAngles = localEuler;
      }
   }
}
