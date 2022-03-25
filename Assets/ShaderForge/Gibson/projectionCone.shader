// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3921569,fgcg:0.8823529,fgcb:1,fgca:1,fgde:0.01,fgrn:0,fgrf:120,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-2309-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32471,y:32812,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:5497,x:32037,y:32487,ptovrint:False,ptlb:projectionCone,ptin:_projectionCone,varname:node_5497,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1444-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9579,x:31695,y:32473,varname:node_9579,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1444,x:31863,y:32473,varname:node_1444,prsc:2,spu:0,spv:0.3|UVIN-9579-UVOUT;n:type:ShaderForge.SFN_VertexColor,id:1688,x:32050,y:32701,varname:node_1688,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2309,x:32354,y:32634,varname:node_2309,prsc:2|A-6386-OUT,B-1688-RGB,C-3239-OUT,D-3021-OUT;n:type:ShaderForge.SFN_Fresnel,id:5800,x:31848,y:32864,varname:node_5800,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:3239,x:32007,y:32864,varname:node_3239,prsc:2|IN-5800-OUT;n:type:ShaderForge.SFN_Multiply,id:248,x:32283,y:32459,varname:node_248,prsc:2|A-5497-RGB,B-1502-OUT;n:type:ShaderForge.SFN_Vector1,id:1502,x:32156,y:32409,varname:node_1502,prsc:2,v1:2;n:type:ShaderForge.SFN_Color,id:1566,x:31625,y:32636,ptovrint:False,ptlb:color,ptin:_color,varname:node_1566,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:6386,x:31943,y:32630,varname:node_6386,prsc:2|A-248-OUT,B-1566-RGB,T-2022-OUT;n:type:ShaderForge.SFN_Slider,id:2022,x:31643,y:32791,ptovrint:False,ptlb:colorLerp,ptin:_colorLerp,varname:node_2022,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:5688,x:31705,y:32996,varname:node_5688,prsc:2;n:type:ShaderForge.SFN_Sin,id:9313,x:32091,y:33036,varname:node_9313,prsc:2|IN-6678-OUT;n:type:ShaderForge.SFN_Add,id:3021,x:32471,y:33032,varname:node_3021,prsc:2|A-5025-OUT,B-8407-OUT;n:type:ShaderForge.SFN_Vector1,id:8407,x:32248,y:33156,varname:node_8407,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6678,x:31928,y:33053,varname:node_6678,prsc:2|A-5688-TTR,B-9912-OUT;n:type:ShaderForge.SFN_Vector1,id:9912,x:31721,y:33145,varname:node_9912,prsc:2,v1:30;n:type:ShaderForge.SFN_Multiply,id:5025,x:32276,y:32996,varname:node_5025,prsc:2|A-9313-OUT,B-4367-OUT;n:type:ShaderForge.SFN_Vector1,id:4367,x:32064,y:33156,varname:node_4367,prsc:2,v1:0.2;proporder:7241-5497-1566-2022;pass:END;sub:END;*/

Shader "Shader Forge/projectionCone" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _projectionCone ("projectionCone", 2D) = "white" {}
        _color ("color", Color) = (0.5,0.5,0.5,1)
        _colorLerp ("colorLerp", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _projectionCone; uniform float4 _projectionCone_ST;
            uniform float4 _color;
            uniform float _colorLerp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_2741 = _Time;
                float2 node_1444 = (i.uv0+node_2741.g*float2(0,0.3));
                float4 _projectionCone_var = tex2D(_projectionCone,TRANSFORM_TEX(node_1444, _projectionCone));
                float4 node_5688 = _Time;
                float3 emissive = (lerp((_projectionCone_var.rgb*2.0),_color.rgb,_colorLerp)*i.vertexColor.rgb*(1.0 - (1.0-max(0,dot(normalDirection, viewDirection))))*((sin((node_5688.a*30.0))*0.2)+2.0));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
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
