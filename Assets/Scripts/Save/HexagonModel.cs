﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Save
{
    [Serializable]
    public class HexagonModel
    {
        [SerializeField] public Player Player;
        [SerializeField] public Color Color;
    }
}