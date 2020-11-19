using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class LoadElement : MonoBehaviour
    {
        public TextMeshProUGUI SceneName;
        public TextMeshProUGUI Date;
        public int index;
        
        public void Setup(string sceneName, DateTime date, int i)
        {
            SceneName.text = sceneName;
            Date.text = date.ToString();
            index = i;
        }
    }
}
