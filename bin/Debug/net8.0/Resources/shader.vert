#version 450 core
layout(location = 0) in vec3 aPosition;
layout(location = 1) uniform vec2 screenSize;
layout(location = 2) uniform vec3 tint;
layout(location = 3) uniform mat3 modelMatrix;
layout(location = 4) uniform mat3 viewMatrix;

void main()
{
    vec3 pos = modelMatrix * vec3(aPosition.x / (screenSize.x / 2), aPosition.y / (screenSize.y / 2), 1.0);

    gl_Position = vec4(pos, 1.0);
}