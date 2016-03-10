﻿using UnityEngine;
using System.Collections.Generic;

public class PlantAsset : ScriptableObject
{
    public List<Sprite> sprites = new List<Sprite>();

    public float myDelay;

    public int minMoney, maxMoney;
    public int minDust, maxDust;

    public ParticleSystem myParticles;

    public bool isAvailable;
}
