﻿//--------------------------------------------------
// Motion Framework
// Copyright©2019-2020 何冠峰
// Licensed under the MIT license
//--------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using MotionFramework.Utility;
using UnityEngine;

namespace MotionFramework.Console
{
	public static class ConsoleGUI
	{
		private static bool _initGlobalStyle = false;

		public static GUIStyle SliderStyle { private set; get; }
		public static GUIStyle SliderThumbStyle { private set; get; }
		public static GUIStyle ToolbarStyle { private set; get; }
		public static GUIStyle ButtonStyle { private set; get; }
		public static GUIStyle ToogleStyle1 { private set; get; }
		public static GUIStyle ToogleStyle2 { private set; get; }
		public static GUIStyle TextFieldStyle { private set; get; }
		public static GUIStyle LableStyle { private set; get; }
		public static GUIStyle RichLabelStyle { private set; get; }
		public static int RichLabelFontSize { private set; get; }

		/// <summary>
		/// 创建一些高度和字体大小固定的控件样式
		/// 控制台的标准分辨率为 : 1920X1080
		/// </summary>
		internal static void InitGlobalStyle()
		{
			if (_initGlobalStyle == false)
			{
				_initGlobalStyle = true;

				float scale;
				if (Screen.height > Screen.width)
				{
					// 竖屏Portrait
					scale = Screen.width / 1080f;
				}
				else
				{
					// 横屏Landscape
					scale = Screen.width / 1920f;
				}

				SliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
				SliderStyle.fixedHeight = (int)(20 * scale);

				SliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
				SliderThumbStyle.fixedHeight = (int)(25 * scale);
				SliderThumbStyle.fixedWidth = (int)(25 * scale);

				ToolbarStyle = new GUIStyle(GUI.skin.button);
				ToolbarStyle.fontSize = (int)(28 * scale);
				ToolbarStyle.fixedHeight = (int)(40 * scale);

				ButtonStyle = new GUIStyle(GUI.skin.button);
				ButtonStyle.fontSize = (int)(28 * scale);
				ButtonStyle.fixedHeight = (int)(40 * scale);

				ToogleStyle1 = new GUIStyle(GUI.skin.button);
				ToogleStyle1.fontSize = (int)(26 * scale);
				ToogleStyle1.fixedHeight = (int)(35 * scale);

				ToogleStyle2 = new GUIStyle(GUI.skin.box);
				ToogleStyle2.fontSize = (int)(26 * scale);
				ToogleStyle2.fixedHeight = (int)(35 * scale);

				TextFieldStyle = new GUIStyle(GUI.skin.textField);
				TextFieldStyle.fontSize = (int)(22 * scale);
				TextFieldStyle.fixedHeight = (int)(30 * scale);

				LableStyle = new GUIStyle(GUI.skin.label);
				LableStyle.fontSize = (int)(24 * scale);

				RichLabelStyle = GUIStyle.none;
				RichLabelStyle.richText = true;
				RichLabelFontSize = (int)(24 * scale);
			}
		}

		public static Vector2 BeginScrollView(Vector2 pos, int fixedViewHeight)
		{
			float scrollWidth = Screen.width;
			float scrollHeight = Screen.height - ButtonStyle.fixedHeight - fixedViewHeight - 10;
			return GUILayout.BeginScrollView(pos, GUILayout.Width(scrollWidth), GUILayout.Height(scrollHeight));
		}
		public static void EndScrollView()
		{
			GUILayout.EndScrollView();
		}
		public static bool Toggle(string name, bool checkFlag)
		{
			GUIStyle style = checkFlag ? ToogleStyle1 : ToogleStyle2;
			if (GUILayout.Button(name, style))
			{
				checkFlag = !checkFlag;
			}
			return checkFlag;
		}
		public static void Lable(string text)
		{
			GUILayout.Label($"<size={RichLabelFontSize}><color=white>{text}</color></size>", RichLabelStyle);
		}
		public static void RedLable(string text)
		{
			GUILayout.Label($"<size={RichLabelFontSize}><color=red>{text}</color></size>", RichLabelStyle);
		}
		public static void YellowLable(string text)
		{
			GUILayout.Label($"<size={RichLabelFontSize}><color=yellow>{text}</color></size>", RichLabelStyle);
		}
	}
}