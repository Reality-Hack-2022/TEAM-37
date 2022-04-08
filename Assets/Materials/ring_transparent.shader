// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33575,y:32666,varname:node_3138,prsc:2|emission-3720-OUT,alpha-3327-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32484,y:32546,ptovrint:False,ptlb:FillFromColor,ptin:_FillFromColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.01757743,c2:0.3410021,c3:0.745283,c4:1;n:type:ShaderForge.SFN_TexCoord,id:4113,x:31520,y:33262,varname:node_4113,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:1670,x:31753,y:33262,varname:node_1670,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4113-UVOUT;n:type:ShaderForge.SFN_Length,id:882,x:31991,y:33279,varname:node_882,prsc:2|IN-1670-OUT;n:type:ShaderForge.SFN_Add,id:4779,x:32362,y:33226,varname:node_4779,prsc:2|A-2906-OUT,B-6507-OUT;n:type:ShaderForge.SFN_Floor,id:4444,x:32538,y:33226,varname:node_4444,prsc:2|IN-4779-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9920,x:31753,y:33093,varname:node_9920,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1670-OUT;n:type:ShaderForge.SFN_ArcTan2,id:9101,x:32163,y:32994,varname:node_9101,prsc:2,attp:2|A-9920-G,B-9920-R;n:type:ShaderForge.SFN_Ceil,id:1593,x:32768,y:32996,varname:node_1593,prsc:2|IN-9881-OUT;n:type:ShaderForge.SFN_OneMinus,id:6213,x:32966,y:32996,varname:node_6213,prsc:2|IN-1593-OUT;n:type:ShaderForge.SFN_Subtract,id:9881,x:32564,y:32971,varname:node_9881,prsc:2|A-8658-OUT,B-8131-OUT;n:type:ShaderForge.SFN_Multiply,id:1118,x:33153,y:33147,varname:node_1118,prsc:2|A-6213-OUT,B-7098-OUT;n:type:ShaderForge.SFN_OneMinus,id:4882,x:32958,y:33520,varname:node_4882,prsc:2|IN-4444-OUT;n:type:ShaderForge.SFN_OneMinus,id:8658,x:32389,y:33018,varname:node_8658,prsc:2|IN-9101-OUT;n:type:ShaderForge.SFN_Color,id:7998,x:32484,y:32741,ptovrint:False,ptlb:FillToColor,ptin:_FillToColor,varname:_FromColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.01415092,c2:0.452306,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:24,x:32761,y:32629,varname:node_24,prsc:2|A-7241-RGB,B-7998-RGB,T-8131-OUT;n:type:ShaderForge.SFN_Multiply,id:3720,x:33344,y:32863,varname:node_3720,prsc:2|A-24-OUT,B-1118-OUT;n:type:ShaderForge.SFN_Floor,id:44,x:32346,y:33382,varname:node_44,prsc:2|IN-6507-OUT;n:type:ShaderForge.SFN_OneMinus,id:6490,x:32538,y:33382,varname:node_6490,prsc:2|IN-44-OUT;n:type:ShaderForge.SFN_Multiply,id:7098,x:32760,y:33256,varname:node_7098,prsc:2|A-4444-OUT,B-6490-OUT;n:type:ShaderForge.SFN_Slider,id:2906,x:32006,y:33181,ptovrint:False,ptlb:ring_thickness,ptin:_ring_thickness,varname:node_2906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2932818,max:1;n:type:ShaderForge.SFN_Slider,id:8131,x:31950,y:32826,ptovrint:False,ptlb:fill_progress,ptin:_fill_progress,varname:node_8131,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:6507,x:32106,y:33469,varname:node_6507,prsc:2|A-882-OUT,B-28-OUT;n:type:ShaderForge.SFN_Slider,id:8385,x:33028,y:33339,ptovrint:False,ptlb:fade,ptin:_fade,varname:node_8385,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:3327,x:33335,y:33151,varname:node_3327,prsc:2|A-1118-OUT,B-8385-OUT;n:type:ShaderForge.SFN_Slider,id:8993,x:31295,y:33599,ptovrint:False,ptlb:ring_size,ptin:_ring_size,varname:node_8993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:28,x:31695,y:33591,varname:node_28,prsc:2,frmn:0,frmx:1,tomn:16,tomx:1|IN-8993-OUT;proporder:7241-7998-2906-8131-8385-8993;pass:END;sub:END;*/

Shader "Shader Forge/ring_transparent" {
    Properties {
        _FillFromColor ("FillFromColor", Color) = (0.01757743,0.3410021,0.745283,1)
        _FillToColor ("FillToColor", Color) = (0.01415092,0.452306,1,1)
        _ring_thickness ("ring_thickness", Range(0, 1)) = 0.2932818
        _fill_progress ("fill_progress", Range(0, 1)) = 1
        _fade ("fade", Range(0, 1)) = 1
        _ring_size ("ring_size", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _FillFromColor;
            uniform float4 _FillToColor;
            uniform float _ring_thickness;
            uniform float _fill_progress;
            uniform float _fade;
            uniform float _ring_size;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_1670 = (i.uv0*2.0+-1.0);
                float2 node_9920 = node_1670.rg;
                float node_6507 = (length(node_1670)*(_ring_size*-15.0+16.0));
                float node_4444 = floor((_ring_thickness+node_6507));
                float node_1118 = ((1.0 - ceil(((1.0 - ((atan2(node_9920.g,node_9920.r)/6.28318530718)+0.5))-_fill_progress)))*(node_4444*(1.0 - floor(node_6507))));
                float3 emissive = (lerp(_FillFromColor.rgb,_FillToColor.rgb,_fill_progress)*node_1118);
                float3 finalColor = emissive;
                return fixed4(finalColor,(node_1118*_fade));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
