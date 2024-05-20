#include<stdio.h>
int maxArea(int height[], int heightSize) {
    int left=0;
    int right=heightSize-1;
    int area=0;
    while(left<right)
    {
        int width=right-left;
        int height=min(height[left],height[right]);
        area=height*width;
        if(height[left]<height[right])
        {
            left++;
        }
        else if (height[left]>height[right])
        {
           right--;
        }
        else{
            left++;
            right--;
        }
        
    }
}
return area;
}