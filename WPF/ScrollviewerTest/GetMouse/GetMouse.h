// GetMouse.h - Contains declarations of change display setting function by using ChangeDisplaySettingsExW function(winuser.h)
#pragma once

#ifdef GETMOUSE_EXPORTS
#define GETMOUSE_API __declspec(dllexport)
#else
#define GETMOUSE_API __declspec(dllimport)
#endif

//change top-left point of the target monitor 
extern "C" GETMOUSE_API void GetMouse(
    int targetMonitorIndex, long xPos, long yPos);
