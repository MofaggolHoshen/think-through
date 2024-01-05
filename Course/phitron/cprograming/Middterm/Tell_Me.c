#include <stdio.h>
int main()
{
    int t;
    scanf("%d", &t);
    for (int k = 0; k < t; k++)
    {
        int n;
        scanf("%d", &n);

        int ar[n];

        for (int i = 0; i < n; i++)
        {
            scanf("%d", &ar[i]);
        }

        int x;
        scanf("%d", &x);

        int isExist = -1;

        for (int i = 0; i < n; i++)
        {
            if (ar[i] == x)
            {
                isExist = 1;
                break;
            }
        }

        if(isExist > 0)
        {
            printf("YES\n");
        }else{
             printf("NO\n");
        }
    }

    return 0;
}