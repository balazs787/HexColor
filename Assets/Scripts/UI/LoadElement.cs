using Assets.Load;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class LoadElement : MonoBehaviour
    {
        public TextMeshProUGUI SceneName;
        public TextMeshProUGUI Date;
        public int index;
        
        public void Setup(string sceneName, string date, int i)
        {
            SceneName.text = sceneName;
            Date.text = date;
            index = i;
        }

        public void OnElementClicked()
        {
            LoadProperties.GameLoading = true;

            var saveModel = FindObjectOfType<Menu>().SaveModels.ElementAt(index);

            LoadProperties.HexagonModels = saveModel.SaveModels;
            LoadProperties.ActiveAis = saveModel.ActiveAis;
            LoadProperties.ActivePlayer = saveModel.ActivePlayer;
            LoadProperties.ActivePlayers = saveModel.ActivePlayers;
            LoadProperties.AiLevel = saveModel.AiLevel;
            LoadProperties.Names = saveModel.Names;

            SceneManager.LoadScene(saveModel.SceneName);
        }
    }
}
