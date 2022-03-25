// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4117647,fgcg:0.1921569,fgcb:1,fgca:1,fgde:0,fgrn:83.9,fgrf:369.1,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33591,y:32702,varname:node_2865,prsc:2|diff-6510-OUT,spec-4662-OUT,gloss-4662-OUT,emission-6510-OUT,amdfl-4662-OUT,amspl-4662-OUT,difocc-4662-OUT,spcocc-4662-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31961,y:32732,ptovrint:True,ptlb:flipbookTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4946,x:32804,y:32787,varname:node_4946,prsc:2|A-2967-OUT,B-6190-OUT;n:type:ShaderForge.SFN_Vector1,id:6190,x:32593,y:32932,varname:node_6190,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Vector1,id:4662,x:32752,y:33026,varname:node_4662,prsc:2,v1:0;n:type:ShaderForge.SFN_Desaturate,id:2077,x:32963,y:32777,varname:node_2077,prsc:2|COL-4946-OUT,DES-6832-OUT;n:type:ShaderForge.SFN_Slider,id:6832,x:32363,y:33033,ptovrint:False,ptlb:desaturation,ptin:_desaturation,varname:node_6832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_FragmentPosition,id:6426,x:32235,y:33224,varname:node_6426,prsc:2;n:type:ShaderForge.SFN_Vector3,id:7338,x:32248,y:33379,varname:node_7338,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Distance,id:7396,x:32469,y:33281,varname:node_7396,prsc:2|A-6426-XYZ,B-7338-OUT;n:type:ShaderForge.SFN_Multiply,id:1741,x:32658,y:33313,varname:node_1741,prsc:2|A-7396-OUT,B-3228-OUT;n:type:ShaderForge.SFN_Hue,id:5547,x:32995,y:33243,varname:node_5547,prsc:2|IN-3504-OUT;n:type:ShaderForge.SFN_Lerp,id:715,x:32156,y:32857,varname:node_715,prsc:2|A-7736-RGB,B-5547-OUT,T-1926-OUT;n:type:ShaderForge.SFN_Frac,id:5168,x:32831,y:33313,varname:node_5168,prsc:2|IN-1741-OUT;n:type:ShaderForge.SFN_Time,id:3034,x:32658,y:33157,varname:node_3034,prsc:2;n:type:ShaderForge.SFN_Add,id:3504,x:32852,y:33167,varname:node_3504,prsc:2|A-3034-TSL,B-5168-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1926,x:31869,y:32941,ptovrint:False,ptlb:gradientLevel,ptin:_gradientLevel,varname:node_1926,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:3228,x:32453,y:33464,ptovrint:False,ptlb:gradientSize,ptin:_gradientSize,varname:node_3228,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:5036,x:32112,y:32645,ptovrint:False,ptlb:hueShift,ptin:_hueShift,varname:node_5036,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RgbToHsv,id:1617,x:32306,y:32746,varname:node_1617,prsc:2|IN-715-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:2967,x:32645,y:32774,varname:node_2967,prsc:2|H-5876-OUT,S-1617-SOUT,V-1617-VOUT;n:type:ShaderForge.SFN_Add,id:5876,x:32477,y:32645,varname:node_5876,prsc:2|A-5036-OUT,B-1617-HOUT;n:type:ShaderForge.SFN_Depth,id:308,x:32285,y:32324,varname:node_308,prsc:2;n:type:ShaderForge.SFN_Lerp,id:6510,x:33248,y:32583,varname:node_6510,prsc:2|A-6999-OUT,B-2077-OUT,T-7303-OUT;n:type:ShaderForge.SFN_Clamp01,id:3561,x:32716,y:32449,varname:node_3561,prsc:2|IN-1645-OUT;n:type:ShaderForge.SFN_OneMinus,id:9439,x:32878,y:32469,varname:node_9439,prsc:2|IN-3561-OUT;n:type:ShaderForge.SFN_Multiply,id:1645,x:32533,y:32464,varname:node_1645,prsc:2|A-308-OUT,B-2795-OUT;n:type:ShaderForge.SFN_Step,id:7303,x:33068,y:32492,varname:node_7303,prsc:2|A-1282-OUT,B-9439-OUT;n:type:ShaderForge.SFN_Vector1,id:1282,x:32878,y:32422,varname:node_1282,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Vector3,id:6999,x:33104,y:32193,varname:node_6999,prsc:2,v1:0.5,v2:0.5,v3:0.5;n:type:ShaderForge.SFN_Divide,id:2795,x:32330,y:32478,varname:node_2795,prsc:2|A-9180-OUT,B-8653-OUT;n:type:ShaderForge.SFN_Vector1,id:9180,x:32134,y:32393,varname:node_9180,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:8296,x:31919,y:32432,cmnt:maxDistance,varname:node_8296,prsc:2,v1:30;n:type:ShaderForge.SFN_ValueProperty,id:8653,x:31948,y:32512,ptovrint:False,ptlb:maxAgentDist,ptin:_maxAgentDist,varname:node_8653,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7736-6832-5036;pass:END;sub:END;*/

Shader "Shader Forge/voxelsAgents" {
    Properties {
        _MainTex ("flipbookTex", 2D) = "white" {}
        _desaturation ("desaturation", Range(0, 1)) = 0
        _hueShift ("hueShift", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _desaturation;
            uniform float _gradientLevel;
            uniform float _gradientSize;
            uniform float _hueShift;
            uniform float _maxAgentDist;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_4662 = 0.0;
                float gloss = node_4662;
                float perceptualRoughness = 1.0 - node_4662;
                float roughness = perceptualRoughness * perceptualRoughness;
/////// GI Data:
                UnityLight light; // Dummy light
                light.color = 0;
                light.dir = half3(0,1,0);
                light.ndotl = max(0,dot(normalDirection,light.dir));
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = 1;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
////// Specular:
                float3 specularColor = float3(node_4662,node_4662,node_4662);
                float specularMonochrome;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_3034 = _Time;
                float3 node_715 = lerp(_MainTex_var.rgb,saturate(3.0*abs(1.0-2.0*frac((node_3034.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel);
                float4 node_1617_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1617_p = lerp(float4(float4(node_715,0.0).zy, node_1617_k.wz), float4(float4(node_715,0.0).yz, node_1617_k.xy), step(float4(node_715,0.0).z, float4(node_715,0.0).y));
                float4 node_1617_q = lerp(float4(node_1617_p.xyw, float4(node_715,0.0).x), float4(float4(node_715,0.0).x, node_1617_p.yzx), step(node_1617_p.x, float4(node_715,0.0).x));
                float node_1617_d = node_1617_q.x - min(node_1617_q.w, node_1617_q.y);
                float node_1617_e = 1.0e-10;
                float3 node_1617 = float3(abs(node_1617_q.z + (node_1617_q.w - node_1617_q.y) / (6.0 * node_1617_d + node_1617_e)), node_1617_d / (node_1617_q.x + node_1617_e), node_1617_q.x);;
                float3 node_6510 = lerp(float3(0.5,0.5,0.5),lerp(((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_hueShift+node_1617.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1617.g)*node_1617.b)*1.5),dot(((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_hueShift+node_1617.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1617.g)*node_1617.b)*1.5),float3(0.3,0.59,0.11)),_desaturation),step(0.9,(1.0 - saturate((partZ*(0.1/_maxAgentDist))))));
                float3 diffuseColor = node_6510; // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular + float3(node_4662,node_4662,node_4662));
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += float3(node_4662,node_4662,node_4662); // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= node_4662; // Diffuse AO
                diffuseColor *= 1-specularMonochrome;
////// Emissive:
                float3 emissive = node_6510;
/// Final Color:
                outDiffuse = half4( diffuseColor, node_4662 );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( node_6510, 1 );
                outEmission.rgb += indirectSpecular;
                outEmission.rgb += indirectDiffuse * diffuseColor;
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _desaturation;
            uniform float _gradientLevel;
            uniform float _gradientSize;
            uniform float _hueShift;
            uniform float _maxAgentDist;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD11;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_4662 = 0.0;
                float gloss = node_4662;
                float perceptualRoughness = 1.0 - node_4662;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularAO = node_4662;
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = float3(node_4662,node_4662,node_4662);
                float specularMonochrome;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_3034 = _Time;
                float3 node_715 = lerp(_MainTex_var.rgb,saturate(3.0*abs(1.0-2.0*frac((node_3034.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel);
                float4 node_1617_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1617_p = lerp(float4(float4(node_715,0.0).zy, node_1617_k.wz), float4(float4(node_715,0.0).yz, node_1617_k.xy), step(float4(node_715,0.0).z, float4(node_715,0.0).y));
                float4 node_1617_q = lerp(float4(node_1617_p.xyw, float4(node_715,0.0).x), float4(float4(node_715,0.0).x, node_1617_p.yzx), step(node_1617_p.x, float4(node_715,0.0).x));
                float node_1617_d = node_1617_q.x - min(node_1617_q.w, node_1617_q.y);
                float node_1617_e = 1.0e-10;
                float3 node_1617 = float3(abs(node_1617_q.z + (node_1617_q.w - node_1617_q.y) / (6.0 * node_1617_d + node_1617_e)), node_1617_d / (node_1617_q.x + node_1617_e), node_1617_q.x);;
                float3 node_6510 = lerp(float3(0.5,0.5,0.5),lerp(((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_hueShift+node_1617.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1617.g)*node_1617.b)*1.5),dot(((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_hueShift+node_1617.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1617.g)*node_1617.b)*1.5),float3(0.3,0.59,0.11)),_desaturation),step(0.9,(1.0 - saturate((partZ*(0.1/_maxAgentDist))))));
                float3 diffuseColor = node_6510; // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular + float3(node_4662,node_4662,node_4662)) * specularAO;
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += float3(node_4662,node_4662,node_4662); // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= node_4662; // Diffuse AO
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_6510;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _desaturation;
            uniform float _gradientLevel;
            uniform float _gradientSize;
            uniform float _hueShift;
            uniform float _maxAgentDist;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float4 projPos : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_3034 = _Time;
                float3 node_715 = lerp(_MainTex_var.rgb,saturate(3.0*abs(1.0-2.0*frac((node_3034.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel);
                float4 node_1617_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1617_p = lerp(float4(float4(node_715,0.0).zy, node_1617_k.wz), float4(float4(node_715,0.0).yz, node_1617_k.xy), step(float4(node_715,0.0).z, float4(node_715,0.0).y));
                float4 node_1617_q = lerp(float4(node_1617_p.xyw, float4(node_715,0.0).x), float4(float4(node_715,0.0).x, node_1617_p.yzx), step(node_1617_p.x, float4(node_715,0.0).x));
                float node_1617_d = node_1617_q.x - min(node_1617_q.w, node_1617_q.y);
                float node_1617_e = 1.0e-10;
                float3 node_1617 = float3(abs(node_1617_q.z + (node_1617_q.w - node_1617_q.y) / (6.0 * node_1617_d + node_1617_e)), node_1617_d / (node_1617_q.x + node_1617_e), node_1617_q.x);;
                float3 node_6510 = lerp(float3(0.5,0.5,0.5),lerp(((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_hueShift+node_1617.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1617.g)*node_1617.b)*1.5),dot(((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_hueShift+node_1617.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1617.g)*node_1617.b)*1.5),float3(0.3,0.59,0.11)),_desaturation),step(0.9,(1.0 - saturate((partZ*(0.1/_maxAgentDist))))));
                o.Emission = node_6510;
                
                float3 diffColor = node_6510;
                float node_4662 = 0.0;
                float3 specColor = float3(node_4662,node_4662,node_4662);
                float specularMonochrome = max(max(specColor.r, specColor.g),specColor.b);
                diffColor *= (1.0-specularMonochrome);
                float roughness = 1.0 - node_4662;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
