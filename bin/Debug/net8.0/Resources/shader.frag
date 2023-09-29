#version 450 core

out vec4 FragColor;
uniform vec2 screenSize;
uniform vec3 color;

void main()
{
    FragColor = vec4(color.x, color.y, color.z, 1.0f);
}