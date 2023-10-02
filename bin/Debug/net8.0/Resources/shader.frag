#version 450 core

out vec4 FragColor;
uniform vec3 tint;
uniform sampler2D texture0;
uniform vec2 aTexCoord;

void main()
{   
    FragColor = vec4(1.0f);
    //FragColor = texture(texture0, aTexCoord);
}