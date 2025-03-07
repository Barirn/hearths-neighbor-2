﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HearthsNeighbor2
{
    /// <summary>
    /// Fix for the lighting bug
    /// </summary>
    public class LibraryLightFix : MonoBehaviour
    {
        private Light light;

        private void Start()
        {
            light = GetComponent<Light>();
            light.shadowBias = -1;
            light.shadowNearPlane = 1;
            ChangeLightQuality(PlayerData.GetGraphicSettings());
            GlobalMessenger<GraphicSettings>.AddListener("GraphicSettingsUpdated", ChangeLightQuality);
        }

        private void ChangeLightQuality(GraphicSettings settings)
        {
            if (light == null) light = GetComponent<Light>();
            switch (settings.shadowQuality)
            {
                case ShadowQuality.LOW:
                    light.shadowCustomResolution = 1024;
                    break;
                case ShadowQuality.MEDIUM:
                    light.shadowCustomResolution = 2048;
                    break;
                case ShadowQuality.HIGH:
                    light.shadowCustomResolution = 4096;
                    break;
                case ShadowQuality.VERY_HIGH:
                    light.shadowCustomResolution = 8192;
                    break;
                default:
                    light.shadowCustomResolution = 1024;
                    break;
            }
        }
    }
}
