 Shader "Custom/Chowder Shader" {
     //Define what properties are used for the shader
     Properties {

         //Put the main sprite here
         [PerRendererData] _MainTex ("Tex For Alpha (RGB)", 2D) = "white" {}

         //Put the testure you want here
         _TextureSlot1 ("TextureSlot1 (RGB)", 2D) = "white" {}
         _Color ("Tint", Color) = (1,1,1,1)
         [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0

     }
     SubShader {
         //Normal shader stuff that makes sure the sprite draws correctly
         Tags {
             "RenderType"="Transparent"
             "Queue"="Transparent"
             "IgnoreProjector"="True"
             "CanUseSpriteAtlas"="True"
             "PreviewType"="Plane"
         }

         Cull Off
         Lighting Off
         Zwrite Off
         Fog {Mode Off}
         Blend SrcAlpha OneMinusSrcAlpha
         
         //The actual Shader
         CGPROGRAM 
         //saying what type of shader it is. this is a Surface shader
         #pragma surface surf Lambert alpha
         
         sampler2D _MainTex;
         sampler2D _TextureSlot1;
         float4 _Color;

         struct Input {
             float2 uv_MainTex;
             float2 uv_TextureSlot1;
             float4 screenPos;
         };

             void surf (Input IN, inout SurfaceOutput o) {
              
                 //Locks the texture to the screen UVs so it doesn't move when the object does
                 half2 screenUV = IN.screenPos.xy/IN.screenPos.w;
                 half4 primary = tex2D (_MainTex, IN.uv_MainTex);
                 half4 slot1 = tex2D (_TextureSlot1, screenUV);

                 //Replace White with desired texture. Sprite areas that you want to change must be white not transparent
                 if(primary.r>.5 && primary.g>.5 && primary.b>.5) //White
                     o.Albedo=slot1.rgb * _Color.rgb;
                 o.Alpha=primary.a; //Keep sprite transparency
                 o.Albedo=o.Albedo*5; //Restore normal brightness
        }
             

         ENDCG
     } 
     //gets rid of the effect if system can't handle the shader
     FallBack "Diffuse"
 }