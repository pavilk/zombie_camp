using UnityEngine;

public class LockPickCheker : MonoBehaviour
{ 
    void Update()
    {
        if (FirstPinScript.Fixed && SecondPinScript.Fixed && ThirdPinScript.Fixed)
        {
            if (FirstPinScript.RightSequence && SecondPinScript.RightSequence && ThirdPinScript.RightSequence)
                Debug.Log("�����");
            else
            {
                FirstPinScript.Reset();
                SecondPinScript.Reset();
                ThirdPinScript.Reset();
                Debug.Log("� ���������");
            }
        }   
    }
}
