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
Shader "MMD/PMDMaterial"
{
	Properties
	{
		_Color("Diffuse Color", Color) = (1,1,1,1)
		_SpecularColor("Specular Color", Color) = (1,1,1)
		_AmbColor("Ambiant Color", Color) = (1,1,1)
		_Shininess("Shininess", Float) = 0
		_MainTex("Main Texture", 2D) = "white" {}
		_ToonTex("Toon Texture", 2D) = "white" {}
		_SphereAddTex("Sphere Add Texture", 2D) = "black" {}
		_SphereMulTex("Sphere Mul Texture", 2D) = "white" {}
	}

	SubShader
	{
		Cull Back

		// Surface Shader
		CGPROGRAM
		#pragma surface surf MMD
		#include "MeshPmdMaterialSurface.cginc"
		ENDCG
	}

	// Other Environment
	Fallback "Diffuse"
}
