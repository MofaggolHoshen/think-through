#include <stdio.h>
int main()
{
    int a;
    scanf("%d", &a);
    int p = 0;
    int n = 0;
    

    for(int i = 0; i < a; i++)
    {
        int b;
        scanf("%d", &b);

        // Positive
        if(b > 0)
        {
            p += b;
        }else{
            n += b;
        }

    }
    
    printf("%d %d", p, n);

    return 0;
}