// ---------------------------��2D Sprite Ӱ�ӡ�---------------------------
Shader "shader2D/player
"
{
    Properties{
        _PlayerTex("_PlayerTex",2D) = "white"
        _MainTex("Main Tex",2D) = "white"
    }
    // ---------------------------������ɫ����---------------------------
    SubShader
    {
        // No culling or depth
        Cull Off 
        ZWrite Off 
        ZTest Always
        // ����͸����
        Blend SrcAlpha OneMinusSrcAlpha
        // ������Ⱦ����
        Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }

        // ---------------------------��ͨ��һ��---------------------------
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            // ������ɫ��ȡ
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.uv.y = 1 - o.uv.y;
                return o;
            }

            //ͨ��c#��ȡ�����������ݹ���
            sampler2D _PlayerTex;
            sampler2D _MainTex;

            // ƬԪ��ɫ��ȡ
            fixed4 frag(v2f  i) : SV_Target
            {
                // ����������������
                fixed4 col = tex2D(_PlayerTex, i.uv);
            // ������step����if
            // �� ͸����ֵ����1ʱ, �ͳ��ֺ�ɫ(��Ӱ��)
            col.rgb = 1 - step(0,col.a);
            return col;
        }
        ENDCG
    }
    }
}