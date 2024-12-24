#include <iostream>
#include "glfw3.h"

class Vector3
{
public:
	Vector3(float x, float y, float z)
	{
		this->x = x;
		this->y = y;
		this->z = z;
	}
	float x, y, z;
};

extern "C"
{
	__declspec(dllexport) Vector3* NewVector3(float x, float y, float z)
	{
		return new Vector3(x, y, z);
	}

	__declspec(dllexport) void DeleteVector3(Vector3* instance)
	{
		delete instance;
	}

	__declspec(dllexport) float GetVector3Field(Vector3* instance, int index)
	{
		if (!instance) return 0.0f;

		switch (index)
		{
		case 0: return instance->x;
		case 1: return instance->x;
		case 2: return instance->x;
		default: 0.0f;
		}
	}
}

extern "C" __declspec(dllexport) int Add(int num1, int num2)
{
	return num1 + num2;
}