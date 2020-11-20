using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Save
{
    [Serializable]
    public class SaveModel
    {
        [SerializeField] public List<HexagonModel> SaveModels;
        [SerializeField] public string SceneName;
        [SerializeField] public DateTime SaveTime;
    }
}
