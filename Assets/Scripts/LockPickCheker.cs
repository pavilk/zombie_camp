using UnityEngine;
using UnityEngine.SceneManagement;

public class LockPickCheker : MonoBehaviour
{ 
    void Update()
    {
        if (FirstPinScript.Fixed && SecondPinScript.Fixed && ThirdPinScript.Fixed)
        {
            if (FirstPinScript.RightSequence && SecondPinScript.RightSequence && ThirdPinScript.RightSequence)
            {
                SceneManager.LoadScene(4);
            }

            else
            {
                FirstPinScript.Reset();
                SecondPinScript.Reset();
                ThirdPinScript.Reset();
                Debug.Log("Я попытался");
            }
        }   
    }
}
