/*
 * MMD Shader for Unity
 *
 * Copyright 2012 Masataka SUMI, Takahiro INOUE
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */
Shader "MMD/Transparent/PMDMaterial-with-Outline"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Opacity("Opacity", Float) = 1.0
		_SpecularColor("SpecularColor", Color) = (1,1,1)
		_AmbColor("Ambiant Color", Color) = (1,1,1)
		_Shininess("Shininess", Float) = 0
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth("Outline Width", Float) = 0.2
		_MainTex("Main Texture", 2D) = "white" {}
		_ToonTex("Toon Texture", 2D) = "white" {}
		_SphereAddTex("Sphere Add Texture", 2D) = "black" {}
		_SphereMulTex("Sphere Mul Texture", 2D) = "white" {}
	}

	SubShader
	{
		// Settings
		Tags
		{
			"Queue" = "Transparent+1"
			"RenderType" = "Transparent"
			"IgnoreProjector" = "True"
		}
		Cull Back
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		#pragma surface surf MMD alpha:fade
		#include "MeshPmdMaterialSurface.cginc"
		ENDCG
		
		Pass
		{
			Cull Front
			Lighting Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "MeshPmdMaterialVertFrag.cginc"
			ENDCG
		}
	}

	// Other Environment
	Fallback "Transparent/Diffuse"
}
