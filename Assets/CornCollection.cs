// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// // code to collect corn
// public class CornCollection : MonoBehaviour
// {
//     private int Corn = 0;
//     public void OnTriggerEnter(Collider other)
//     {
//         if (other.transform.tag == "Corn")
//         {
//             Corn++;
//             Debug.Log(Corn);
//             Destroy(other.gameObject);
//         }
// }
// }


// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class CornCollector : MonoBehaviour
// {
//     private int Corn = 0;

//     public TextMeshProUGUI CornText;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.transform.tag == "Corn")
//         {
//             Corn++;
//             CornText.text = "Corn: " + Corn.ToString();
//             Debug.Log("Corn collected: " + Corn);
//             Destroy(other.gameObject);

//             // Check if the current corn count meets the condition for the current level
//             if (GameManager.Instance.GetCurrentLevel() == 1 && Corn >= 50)
//             {
//                 // Load the next level
//                 GameManager.Instance.LoadNextLevel();
//             }
//             else if (GameManager.Instance.GetCurrentLevel() == 2 && Corn >= 100)
//             {
//                 // Load the next level
//                 GameManager.Instance.LoadNextLevel();
//             }
//             else if (GameManager.Instance.GetCurrentLevel() == 3 && Corn >= 150)
//             {
//                 // Load the next level
//                 GameManager.Instance.LoadWinScene();
//             }
//         }
//     }
// }

