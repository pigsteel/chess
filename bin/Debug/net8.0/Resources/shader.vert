#version 450 core
layout(location = 0) in vec3 aPosition;
layout(location = 1) uniform vec2 screenSize;
layout(location = 2) uniform vec3 color;

void main()
{
    gl_Position = vec4(aPosition.x / screenSize.x, aPosition.y / screenSize.y, aPosition.z, 1.0);
}