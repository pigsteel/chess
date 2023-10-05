#version 450 core

out vec4 FragColor;
uniform vec3 tint;
uniform vec2 screenSize;
uniform sampler2D texture0;
in vec2 texCoord;

void main()
{   
    //vec2 texCoord = screenSize / aTexCoord;
    FragColor = texture(texture0, texCoord);
}