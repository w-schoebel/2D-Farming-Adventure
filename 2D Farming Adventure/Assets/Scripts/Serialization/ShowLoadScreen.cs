using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Serialization
{
    public class ShowLoadScreen : MonoBehaviour
    {
     /*  public void ShowLoadScreen()
        {
            GetLoadFiles();

            foreach (Transform button in loadArea)
            {

                Destroy(button.gameObject);
            }

            for (int i = 0; i < saveFiles.Length; i++)
            {
                GameObject buttonObject = Instantiate(loadButtonPrefab);
                buttonObject.transform.SetParent(loadArea.transform, false);

                var index = i;
                buttonObject.GetComponent<Button>().onClick.AddListener(() =>
                    {
                    PlayerManager.OnLoad(saveFiles[index]);
                });
            buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[index].Replace(Application.persistentDataPath + "/saves/", "");
            }
      } */
    }
}