#version 330 core
out vec4 FragColor;
in vec2 TexCoord;
in vec3 normal;
uniform vec3 lightColor;

uniform sampler2D ourTexture;

void main()
{
    vec4 tex = texture(ourTexture, TexCoord);
    //ambient = Ka * I
    float ambientCoeff = 0.1;
    vec3 ambient = ambientCoeff * lightColor;

    //diffuse  = Kd * I/r^2 *max(0,n*l)
    // ������ϵ�������յ�ǿ�ȡ��뾶��ƽ����0�� ��������߷����� cos�����ֵ

    //specular  = Ks * I/r^2 * max(0,h*n)  
    // h �ǰ�������� h = (v+l) ;��������߷�����ӵõ��������


    vec3 result = ambient * tex.rgb;
    FragColor = vec4(normal, 1.0);
}