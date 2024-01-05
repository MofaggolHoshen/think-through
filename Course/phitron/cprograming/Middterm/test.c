#include <stdio.h>
int main()
{
    char a = '0';
     if(a >= 'a' && a <= 'z')
            {
                // small letter 
                printf("Small");
            }else if(a >= 'A' && a <= 'Z')
            {
                // big letter 
                printf("Big");
            }else if(a >= '0' && a <= '9')
            {
                // digit
                printf("Digit");
            }
    return 0;
}