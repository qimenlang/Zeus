#version 330 core
out vec4 FragColor;
in vec2 TexCoord;
in vec3 normal;
in vec3 FragPos;

uniform vec3 viewPos;
uniform sampler2D ourTexture;

const float Ka = 0.1;
const float Kd = 1.0;
const float Ks = 0.6;

struct Light{
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct Material{
    sampler2D diffuse;
    sampler2D specular;
    float shininess; 
};
uniform Light light;    
uniform Material material;

void main()
{
    vec4 tex = texture(material.diffuse, TexCoord);
    //ambient = Ka * I
    vec3 ambient = light.ambient*tex.rgb;

    //diffuse  = Kd * I/r^2 *max(0,n*l)
    // ������ϵ�������յ�ǿ�ȡ��뾶��ƽ����0�� ��������߷����� cos�����ֵ
    vec3 lightDir =  normalize(light.position - FragPos);
    vec3 norm  = normalize(normal);
    float diff = max(0.0,dot(norm,lightDir));
    vec3 diffuse = light.diffuse * (diff * tex.rgb);

    //specular  = Ks * I/r^2 * max(0,h*n)  
    // h �ǰ�������� h = (v+l) ;��������߷�����ӵõ��������
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir,viewDir);
    float spec = pow(max(dot(reflectDir,viewDir),0.0),material.shininess);

    vec4 spec_tex = texture(material.specular, TexCoord);
    vec3 specular = Ks * spec * light.specular * spec_tex.rgb;


    vec3 result = (ambient+diffuse +specular); 
    FragColor = vec4(result, 1.0);
}