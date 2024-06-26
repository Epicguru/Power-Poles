﻿using RimForge.Buildings;
using RimWorld;
using UnityEngine;
using Verse;

namespace RimForge
{
    [StaticConstructorOnStartup]
    public static class PolesContent
    {
        public static readonly Texture2D LinkIcon = ContentFinder<Texture2D>.Get("RF/UI/Link", true);
        public static readonly Texture2D SwapIcon = ContentFinder<Texture2D>.Get("RF/UI/Swap", true);
        public static readonly Texture2D SlackIcon = ContentFinder<Texture2D>.Get("RF/UI/Slack", true);

        public static void DrawCustomOverlay(this Thing drawer)
        {
            if (!(drawer is ICustomOverlayDrawer))
            {
                PolesCore.Warn(drawer.LabelCap + " cannot draw a custom overlay since it's building class does not implement the ICustomOverlayDrawer interface.");
                return;
            }
            drawer.Map.overlayDrawer.DrawOverlay(drawer, OverlayTypes.BrokenDown);
        }

        internal static Vector2 WorldToFlat(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        internal static Vector3 FlatToWorld(this Vector2 vector, float height)
        {
            return new Vector3(vector.x, height, vector.y);
        }
    }
}
