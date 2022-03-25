// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:5,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:4,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3921569,fgcg:0.8823529,fgcb:1,fgca:1,fgde:0.01,fgrn:0,fgrf:120,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33426,y:32703,varname:node_1873,prsc:2|emission-7999-OUT,alpha-9965-OUT;n:type:ShaderForge.SFN_Tex2d,id:2358,x:32300,y:32735,ptovrint:False,ptlb:scoreSprites,ptin:_scoreSprites,varname:node_2358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ad54bde0f85a3f54cb8c1f0d01606e2a,ntxv:0,isnm:False|UVIN-5022-OUT;n:type:ShaderForge.SFN_VertexColor,id:2603,x:32426,y:32913,varname:node_2603,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7999,x:32946,y:32783,varname:node_7999,prsc:2|A-6127-OUT,B-9617-OUT,C-2603-RGB;n:type:ShaderForge.SFN_Vector1,id:9617,x:32728,y:32902,varname:node_9617,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:9965,x:32928,y:32932,varname:node_9965,prsc:2|A-2358-A,B-2603-A;n:type:ShaderForge.SFN_TexCoord,id:6832,x:31482,y:32335,varname:node_6832,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8726,x:31696,y:32485,varname:node_8726,prsc:2|A-6832-V,B-9156-OUT;n:type:ShaderForge.SFN_Vector1,id:9156,x:31465,y:32572,varname:node_9156,prsc:2,v1:0.0625;n:type:ShaderForge.SFN_Append,id:5022,x:31908,y:32364,varname:node_5022,prsc:2|A-6832-U,B-7049-OUT;n:type:ShaderForge.SFN_Add,id:7049,x:31863,y:32517,varname:node_7049,prsc:2|A-8726-OUT,B-7819-OUT;n:type:ShaderForge.SFN_Multiply,id:7819,x:31711,y:32715,varname:node_7819,prsc:2|A-9156-OUT,B-997-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9749,x:31198,y:32753,ptovrint:False,ptlb:idx,ptin:_idx,varname:node_9749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Round,id:997,x:31540,y:32734,varname:node_997,prsc:2|IN-6807-OUT;n:type:ShaderForge.SFN_Subtract,id:6807,x:31373,y:32734,varname:node_6807,prsc:2|A-7585-OUT,B-9749-OUT;n:type:ShaderForge.SFN_Vector1,id:7585,x:31198,y:32633,varname:node_7585,prsc:2,v1:16;n:type:ShaderForge.SFN_Lerp,id:6127,x:32692,y:32582,varname:node_6127,prsc:2|A-2358-RGB,B-4094-OUT,T-9435-OUT;n:type:ShaderForge.SFN_RgbToHsv,id:5185,x:32485,y:32416,varname:node_5185,prsc:2|IN-2358-RGB;n:type:ShaderForge.SFN_Add,id:7381,x:32672,y:32399,varname:node_7381,prsc:2|A-7250-OUT,B-5185-HOUT;n:type:ShaderForge.SFN_Time,id:2986,x:32323,y:32224,varname:node_2986,prsc:2;n:type:ShaderForge.SFN_HsvToRgb,id:4094,x:32848,y:32399,varname:node_4094,prsc:2|H-7381-OUT,S-5185-SOUT,V-5185-VOUT;n:type:ShaderForge.SFN_Multiply,id:7250,x:32595,y:32271,varname:node_7250,prsc:2|A-2986-TTR,B-4962-OUT;n:type:ShaderForge.SFN_Vector1,id:4962,x:32416,y:32343,varname:node_4962,prsc:2,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:9435,x:32436,y:32616,ptovrint:False,ptlb:pwrFlash,ptin:_pwrFlash,varname:node_9435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:2358-9749-9435;pass:END;sub:END;*/

Shader "Shader Forge/hitScore" {
    Properties {
        _scoreSprites ("scoreSprites", 2D) = "white" {}
        _idx ("idx", Float ) = 0
        _pwrFlash ("pwrFlash", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "Queue"="Overlay"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZTest NotEqual
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _scoreSprites; uniform float4 _scoreSprites_ST;
            uniform float _idx;
            uniform float _pwrFlash;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float node_9156 = 0.0625;
                float2 node_5022 = float2(i.uv0.r,((i.uv0.g*node_9156)+(node_9156*round((16.0-_idx)))));
                float4 _scoreSprites_var = tex2D(_scoreSprites,TRANSFORM_TEX(node_5022, _scoreSprites));
                float4 node_2986 = _Time;
                float4 node_5185_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_5185_p = lerp(float4(float4(_scoreSprites_var.rgb,0.0).zy, node_5185_k.wz), float4(float4(_scoreSprites_var.rgb,0.0).yz, node_5185_k.xy), step(float4(_scoreSprites_var.rgb,0.0).z, float4(_scoreSprites_var.rgb,0.0).y));
                float4 node_5185_q = lerp(float4(node_5185_p.xyw, float4(_scoreSprites_var.rgb,0.0).x), float4(float4(_scoreSprites_var.rgb,0.0).x, node_5185_p.yzx), step(node_5185_p.x, float4(_scoreSprites_var.rgb,0.0).x));
                float node_5185_d = node_5185_q.x - min(node_5185_q.w, node_5185_q.y);
                float node_5185_e = 1.0e-10;
                float3 node_5185 = float3(abs(node_5185_q.z + (node_5185_q.w - node_5185_q.y) / (6.0 * node_5185_d + node_5185_e)), node_5185_d / (node_5185_q.x + node_5185_e), node_5185_q.x);;
                float3 emissive = (lerp(_scoreSprites_var.rgb,(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(((node_2986.a*2.0)+node_5185.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_5185.g)*node_5185.b),_pwrFlash)*1.5*i.vertexColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_scoreSprites_var.a*i.vertexColor.a));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
