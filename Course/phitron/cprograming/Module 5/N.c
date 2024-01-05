#include <stdio.h>
int main()
{
    char a;
    scanf("%c",&a);
    if(a>='a' && a<='z')
    {
        int i=a-32;
        // printf("%d", i);

        printf("%c",i);
    }
    else 
    {
        int j=a+32;
        printf("%c",j);
    }

    return 0;
}