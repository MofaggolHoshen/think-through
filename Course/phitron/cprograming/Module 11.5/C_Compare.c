#include <stdio.h>
#include <string.h>

int main()
{
    char x[201], y[201];

    scanf("%s %s", &x, &y);
    //int i = 0, j = 0;

    int len_x = strcmp(x, y);

    if(len_x < 0)
    {
        printf("%s", x);

    }else if(len_x > 0)
    {
        printf("%s", y);
    }else{
        printf("%s", x);
    }
    
    return 0;
}