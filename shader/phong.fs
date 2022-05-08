#version 330 core
out vec4 FragColor;
in vec2 TexCoord;
in vec3 normal;
in vec3 FragPos;

uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;
uniform sampler2D ourTexture;

const float Ka = 0.1;
const float Kd = 1.0;
const float Ks = 0.6;

void main()
{
    vec4 tex = texture(ourTexture, TexCoord);
    //ambient = Ka * I
    vec3 ambient = Ka * lightColor;

    //diffuse  = Kd * I/r^2 *max(0,n*l)
    // ������ϵ�������յ�ǿ�ȡ��뾶��ƽ����0�� ��������߷����� cos�����ֵ
    vec3 lightDir =  normalize(lightPos - FragPos);
    vec3 norm  = normalize(normal);
    vec3 diffuse = lightColor * max(0.0,dot(norm,lightDir));

    //specular  = Ks * I/r^2 * max(0,h*n)  
    // h �ǰ�������� h = (v+l) ;��������߷�����ӵõ��������
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir,viewDir);
    float spec = pow(max(dot(reflectDir,viewDir),0.0),32);
    vec3 specular = Ks * spec * lightColor;


    vec3 result = (ambient+diffuse +specular) * tex.rgb;
    FragColor = vec4(result, 1.0);
}