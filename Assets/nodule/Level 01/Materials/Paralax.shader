Shader "Unlit/Paralax"{
        Properties{
                
                [HideInInspector]_MainTex ("Texture", 2D) = "white" {}
                _Next ("Texture Buff", 2d) = "white" {}
                _SplitScreem ("Split Screem", Range(-.5,1.5)) = 0.0
                _Ligth ("Ligth Factor", Range(0,1)) = 0
                _Distance ("Distance", Float) = 0
                _Leveler("Leveler",float) = 0
                _Unit("Unity", float) = 18
                
        }
        SubShader{  
                BlendOp Add     
                Blend SrcAlpha OneMinusSrcAlpha
                Cull Off
                Lighting On
                ZWrite off
                ZTest always
                pass{                    
                        CGPROGRAM
                        #pragma vertex vertexUpdate
                        #pragma fragment fragmentUpdate

                        #include "UnityCG.cginc"

                        struct appdata{
                                float4 vertex : POSITION;
                                float2 uv : TEXCOORD0;
                        };
                        struct v2f{
                                float4 pos: SV_POSITION;
                                float2 uv: TEXCOORD0;
                        };
                        struct image{
                                float4 data;
                                float2 uv;
                                float alphaInterpolation;
                        };
                        
                        sampler2D _MainTex;
                        sampler2D _Next;
                        float _SplitScreem;
                        float _Ligth;
                        float _Distance;
                        float _Leveler;
                        float _Unit;

                        v2f vertexUpdate(appdata IN){
                                v2f OUT;
                                OUT.pos = UnityObjectToClipPos(IN.vertex);
                                OUT.uv = IN.uv;
                                return OUT;
                        }

                        fixed4 fragmentUpdate(v2f IN): SV_TARGET{
                                image left;
                                image right;

                                left.alphaInterpolation = 0;
                                right.alphaInterpolation = 0;
                                
                                float4 buff;
                                float _Smoothness = 16;

                                left.uv = float2(IN.uv.x  + (_Distance / _Unit) * _Leveler, IN.uv.y);
                                right.uv = float2(IN.uv.x + (_Distance / _Unit) * _Leveler, IN.uv.y);

                                IN.uv.x -= _SplitScreem;
                                
                                if(IN.uv.x < 0.25){
                                        left.data = tex2D(_MainTex,left.uv);
                                }
                                if(IN.uv.x > -0.25){
                                        right.data = tex2D(_Next,right.uv);
                                }

                                if (IN.uv.x > 0){
                                        left.alphaInterpolation = pow(IN.uv.x,2) * _Smoothness;

                                }if (IN.uv.x < 0){
                                        right.alphaInterpolation = pow(IN.uv.x,2) * _Smoothness;
                                }

                                left.data = float4(left.data.xyz,(1 - left.alphaInterpolation) * left.data.a);
                                right.data = float4(right.data.xyz,(1 - right.alphaInterpolation) * right.data.a);

                                buff = float4(left.data.xyz * left.data.a, left.data.a + right.data.a) + float4(right.data.xyz * right.data.a,right.data.a + left.data.a);

                                buff.xyz *= float4(_Ligth,_Ligth,_Ligth,1);

                                return buff;
                        }
                        ENDCG
                        Cull off
                } 
             

        }
}